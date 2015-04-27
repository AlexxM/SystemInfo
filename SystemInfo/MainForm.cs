/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 09.04.2015
 * Время: 10:57
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System.Linq;
using System.Configuration;
using System.Resources;
namespace SystemInfo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public event Action CollectComputerInfo;
		public event Func<string,ComputerDescription> GetDetailComputerInfo;
		public event Action ButtonCancelClick;
		public event Action<List<SearchingCriteria>> FilterComputerByProp; 
		private DateTime startTime;
		MainFormPresenter _mfp;
		private static ResourceManager _rm;
		public MainForm()
		{
		
			InitializeComponent();
			
			
			
			_rm=new ResourceManager(typeof(MainForm));
			
			//окно для ввода логина/пароля административной учетной записи
			AdminForm af=new AdminForm();
			ConnectionOptions co=new ConnectionOptions();
			if(DialogResult.OK == af.ShowDialog())
			{
				co.Username=af.txtAdminLogin.Text;
				co.Password=af.txtAdminPass.Text;				
			}
			_mfp=new MainFormPresenter(this,co);
			timer1.Interval=100;
			
			timer1.Tick+= (e,a) => { toolStripStatusLabel3.Text=DateTime.Now.Subtract(startTime).ToString(@"hh\:mm\:ss");  };
		}

		public void _mfp_UpdateProgress(int obj)
		{
			this.Invoke(new Action(()=>{ 
			                       	toolStripProgressBar1.Value=obj;  
			                       }));
		}

		public void FormatStatus(string statusMsg)
		{
			this.Invoke(new Action(()=>{statusStrip1.Items["toolStripStatusLabel1"].Text=statusMsg;}));
		}
		
		
		public void _mfp_ComputerListLoaded(List<string> list)
		{
			this.Invoke(new Action(()=>{ 
			                       	
				foreach(string str in list)
				{
					listView2.Items.Add(str);
				}
				
				lblCompCount.Text=string.Format("Выбрано компьютеров: {0}",list.Count);
			}));
		}
		
		void BtnGetInfoClick(object sender, EventArgs e)
		{
			
			if(_mfp.isRunning==false && CollectComputerInfo!=null)
			{
				startTime=DateTime.Now;
				timer1.Start();
				listView2.Items.Clear();
				if(CollectComputerInfo!=null)
					CollectComputerInfo();
			}
		}
		
		public void CollectionDataComplete()
		{
			timer1.Stop();
		}
		
		public void HighlightComputers(List<string> listComp)
		{
			foreach(ListViewItem lvi in listView2.Items)
			{
				if(listComp.Any((i)=>{ return i==lvi.Text; }))
				{
					lvi.BackColor=Color.Green;
				}
				else
				{
					lvi.BackColor=Color.White;
				}
			}
		}
		
		
		string GetTextValFromResource(string key)
		{
			string val=null; 
				
			if(_rm!=null)
				val = _rm.GetString(key);
			
			if(val==null)
			{
				return key;
			}
			else
			{
				return val;
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			if(_mfp.isRunning==true && ButtonCancelClick!=null)
			{
				if(ButtonCancelClick!=null)
					ButtonCancelClick();
				FormatStatus("Подготовка к отмене...");
			}
		}
		
		//создание списка критериев для поиска
		void BtbApplyValFilterClick(object sender, EventArgs e)
		{
			if(_mfp.isRunning==true)
				return;
			
			List<SearchingCriteria> lst = new List<SearchingCriteria>();
			var cc = groupBox1.Controls;
			foreach (Control element in cc)
			{
				if(element is TextBox && element.Name.Contains("Win32") &&  element.Text.Trim()!=String.Empty)
				{
					if(element.Name=="Win32_ComputerSystem_TotalPhysicalMemory")
					{
						double d;
						if(double.TryParse(element.Text,out d))
						{
							d=d*1024*1024*1024;
							lst.Add(new SearchingCriteria(){nameElement=element.Name,value=d.ToString(),searchingType=SearchingType.Lt});
						}
					}
					else
					{
						lst.Add(new SearchingCriteria(){nameElement=element.Name,value=element.Text,searchingType=SearchingType.Contains});
					}
				}
			}	
		
			if(FilterComputerByProp!=null)
			{
				FilterComputerByProp(lst);
			}
		}
		
		//при нажатии на элемент списка компьютеров отображать детальную информацию о компьютере
		void ListView2SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_mfp.isRunning==true || listView2.SelectedItems.Count==0)
				return;
			
			listView1.Items.Clear();
			if(_mfp.isRunning==false && listView2.SelectedItems != null && GetDetailComputerInfo != null)
			{
				ComputerDescription cd = GetDetailComputerInfo(listView2.SelectedItems[0].Text);
				
				if(cd==null)
					return;
				
				
				if(cd.Values.Count()==0 && cd.Exception!=null)
				{	
					listView1.Items.Add(cd.Exception.Message);
					return;
				}
				
				
				foreach(KeyValuePair<string,List<Dictionary<string,string>>> item in cd.Values)
				{
					string textVal = GetTextValFromResource(item.Key);

					listView1.Items.Add(new ListViewItem(){Font=new Font("Microsoft Sans Serif",8.25f,FontStyle.Bold) ,Text=textVal,ForeColor=Color.Green});
					listView1.Items.Add(string.Empty);
					
					foreach(Dictionary<string,string> item1 in item.Value)
					{
						foreach(KeyValuePair<string,string> item2 in item1)
						{
							ListViewItem lvi = new ListViewItem(GetTextValFromResource(item2.Key));
							
							textVal=NumberFormatHelper.Format(item2.Key,item2.Value);
							lvi.SubItems.Add(textVal);
							listView1.Items.Add(lvi);
						}
						listView1.Items.Add(string.Empty);
					}
				}
			}
		}
	}
}
