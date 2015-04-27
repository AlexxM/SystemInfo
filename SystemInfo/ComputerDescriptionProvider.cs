/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 09.04.2015
 * Время: 16:10
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Management;
using System.Text.RegularExpressions;
namespace SystemInfo
{
	/// <summary>
	/// Description of ComputerDescription.
	/// </summary>
	public class ComputerDescriptionProvider
	{
	
		private ConnectionOptions _connectionOpts;
		private List<string> _queryStrings=new List<string>();
		
		public List<string> QueryStrings{ get{return _queryStrings;}}
		public Dictionary<string,ComputerDescription> ComputerDescription {get;set;}
		
		public ComputerDescriptionProvider(List<string> wmiQueryStrings,ConnectionOptions co)
		{
			_queryStrings=wmiQueryStrings;
			_connectionOpts=co;
			ComputerDescription=new Dictionary<string, ComputerDescription>();
		}
		
		public void GetValues(string compName)
		{
			ComputerDescription cd = new ComputerDescription(){Name=compName};
			try{
				
			
			foreach(string query in this.QueryStrings)
			{
				string winClass=string.Empty;
				
				ObjectQuery oq = new ObjectQuery(query);
				Regex r = new Regex(@"from ([\w\d_]+)");
				winClass = r.Match(query).Groups[1].Value; 
				
				ManagementScope ms = new ManagementScope("\\\\"+compName+"\\root\\cimv2",_connectionOpts);

				ManagementObjectSearcher mos = new ManagementObjectSearcher(ms,oq);
				
				ManagementObjectCollection data = mos.Get();
			
				List<Dictionary<string,string>> l = new List<Dictionary<string, string>>();
				foreach(ManagementObject obj in data)
				{
					Dictionary<string,string> dict = new Dictionary<string, string>();
					foreach(PropertyData pd in obj.Properties)
					{
						if(pd.Value==null)
						{
							dict[pd.Name]=string.Empty;
						}
						else if(pd.Value is IEnumerable)
						{
							dict[pd.Name]=String.Join("  ",pd.Value);
						}
						else
						{
							dict[pd.Name]=pd.Value.ToString();
						}
					}
					l.Add(dict);
				}
				cd.Values[winClass]=l;
			}
			ComputerDescription[compName]=cd;
			}
			catch(Exception ex)
			{
				cd.Exception=ex;
				ComputerDescription[compName]=cd;
			}
		}
	}
	
	
	public class ComputerDescription
	{	
		public string Name{get;set;}
		public Dictionary<string,List<Dictionary<string,string>>> Values{get;set;}
		public Exception Exception {get;set;}
		public ComputerDescription()
		{
			Values=new Dictionary<string, List<Dictionary<string, string>>>();
		}
	}
}
