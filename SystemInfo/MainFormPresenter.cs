/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 10.04.2015
 * Время: 16:33
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;
using System.Management;
using System.Linq;
using System.Text.RegularExpressions;
namespace SystemInfo
{
	/// <summary>
	/// Description of MainFormPresenter.
	/// </summary>
	public class MainFormPresenter
	{

		MainForm _mf;
		private CancellationTokenSource _cts;
		private List<string> _computers;
		private Dictionary<string,ComputerDescription> _cDescriptions;
		
		public bool isRunning = false;
		
		private ConnectionOptions _co;
		
		public List<string> Computers
		{
			get{return _computers;}
		}
		
		public MainFormPresenter(MainForm mf,ConnectionOptions co)
		{
			_mf=mf;
			//получение списка компьютеров и сбор детальной информации о них 
			_mf.CollectComputerInfo+= CollectComputerInfo;
			//получение детальной информации о выбранном компьютере
			_mf.GetDetailComputerInfo+= new Func<string,ComputerDescription>(_mf_GetDetailComputerInfo);
			//попытка отмены фоновой задачи
			_mf.ButtonCancelClick+= new Action(_mf_ButtonCancelClick);
			//выборка компьютеров по свойствам
			_mf.FilterComputerByProp+= new Action<List<SearchingCriteria>>(_mf_FilterComputerByProp);
			_co=co;
			
		}

		void _mf_FilterComputerByProp(List<SearchingCriteria> arg)
		{
			if(_cDescriptions==null)
				return ;
			
			List<string> filterComp =new List<string>();
			foreach(SearchingCriteria sc in arg)
			{
				string targetProp = sc.nameElement.Substring(sc.nameElement.LastIndexOf('_')+1);
				string targetElem = sc.nameElement.Substring(0,sc.nameElement.LastIndexOf('_'));
				SearchingType st = sc.searchingType;
				
				
				foreach(var item0 in _cDescriptions)
				{
					string compName=item0.Key;
					
					foreach(KeyValuePair<string,List<Dictionary<string,string>>> item1 in item0.Value.Values)
					{
						if(item1.Key!=targetElem)
							continue;
						
						foreach(Dictionary<string,string> item2 in item1.Value)
						{
							string val;
							if(st==SearchingType.Contains)
							{	
								if(item2.TryGetValue(targetProp,out val))
								{
									if(val.Contains(sc.value))
									{
										filterComp.Add(compName);
									}
								}
							}
							else if(st==SearchingType.Gt)
							{
								if(item2.TryGetValue(targetProp,out val))
								{
									double curVal = double.Parse(val);
									double checkVal = double.Parse(sc.value);
									if(curVal>=checkVal)
										filterComp.Add(compName);
								}
							}
							else if(st==SearchingType.Lt)
							{
								if(item2.TryGetValue(targetProp,out val))
								{
									double curVal = double.Parse(val);
									double checkVal = double.Parse(sc.value);
									if(curVal<=checkVal)
										filterComp.Add(compName);
								}
							}
						}
					}
				}
				
			}
			filterComp = filterComp.Distinct().ToList();
			_mf.HighlightComputers(filterComp);
		}

		void _mf_ButtonCancelClick()
		{
			_cts.Cancel(true);
		}

		ComputerDescription _mf_GetDetailComputerInfo(string compName)
		{
			ComputerDescription cd =_cDescriptions.Where((e)=>e.Key==compName).Select((e)=>e.Value).FirstOrDefault();
			return cd;	
		}

		
		
		public void CollectComputerInfo()
		{
			
			_cts =new CancellationTokenSource();
			
			
			Task<List<string>> t =new Task<List<string>>(()=>{
				isRunning=true;
				_mf.FormatStatus("Получение списка компьютеров...");
			    List<string> comp = WinComputers.GetOnlineComputers();
			    return comp;             
			});
		
			
			Task t1 = t.ContinueWith((e)=>{
			               	
				if(e.Exception!=null)
					throw e.Exception;
			                         	
				List<string> res = ApplyFilterByCompName(e.Result);
			    _mf._mfp_ComputerListLoaded(res);
			    _computers=res; 	
			    _mf.FormatStatus("Получение информации о компьютерах...");
			             
				GetComputerDescription();
			    _mf.FormatStatus("Готово");
			    
			});
			
			
			t1.ContinueWith((e)=>{
			           if(e.Exception is AggregateException)
			           {
			           		AggregateException ae = ((AggregateException)e.Exception).Flatten();
			           		string output=string.Empty;
			           		foreach(Exception ex in ae.InnerExceptions)
			           		{
			           			if(ex is OperationCanceledException)
			           			{
			           				output="Отмена";
									break;
			           			}
			           		}
			           		
			           		if(output==String.Empty)
			           			output=ae.InnerExceptions[0].Message;
			           		_mf.FormatStatus(output);
			           }
			           
						isRunning=false;
						_mf.CollectionDataComplete();        	
			});
			
			t.Start();	
		}
		
		private List<string> ApplyFilterByCompName(List<string> input)
		{
			if(_mf.txtComputerFilter.Text!=String.Empty)
			{
				List<string> newList = new List<string>();
				Regex re = new Regex(_mf.txtComputerFilter.Text,RegexOptions.IgnoreCase);
				foreach(string str in input)
				{
					if(re.Match(str).Success)
					{
						newList.Add(str);
					}
				}
				return newList;
			}
			else
			{
				return input;
			}	
		}
		
		public void GetComputerDescription()
		{
		
			_cDescriptions = new Dictionary<string,ComputerDescription>();
			List<string> qString = new List<string>(){"select TotalPhysicalMemory from Win32_ComputerSystem","select Manufacturer,Product from Win32_BaseBoard","select Name,MaxClockSpeed,NumberOfCores,SocketDesignation from Win32_Processor","select AdapterRam,Name from Win32_VideoController","select Caption,InterfaceType,Size from Win32_DiskDrive","select Name,PortName from Win32_Printer"};
			
			ComputerDescriptionProvider cdp = new ComputerDescriptionProvider(qString,_co);
			Parallel.For(0,_computers.Count,new ParallelOptions(){MaxDegreeOfParallelism=4,CancellationToken=_cts.Token},(i, state)=>
			{
			    cdp.GetValues(_computers[i]);
			    _mf._mfp_UpdateProgress(cdp.ComputerDescription.Count*100/_computers.Count);
				//System.Diagnostics.Debugger.Log(0,"",string.Format("({0} {1})",i,cdp.ComputerDescription.Count));
			});
			_cDescriptions = cdp.ComputerDescription;
			
		}
	}
}
