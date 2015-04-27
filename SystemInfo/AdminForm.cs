/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.04.2015
 * Время: 15:42
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemInfo
{
	/// <summary>
	/// Description of AdminForm.
	/// </summary>
	public partial class AdminForm : Form
	{
		public AdminForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void BtnAcceptClick(object sender, EventArgs e)
		{
			if(txtAdminLogin.Text!=String.Empty)
			{
				DialogResult= DialogResult.OK;
				this.Close();
			}
		}
	}
}
