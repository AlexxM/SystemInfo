/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 09.04.2015
 * Время: 10:57
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace SystemInfo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.listView1 = new System.Windows.Forms.ListView();
			this.HName = new System.Windows.Forms.ColumnHeader();
			this.HValue = new System.Windows.Forms.ColumnHeader();
			this.btnGetInfo = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Win32_ComputerSystem_TotalPhysicalMemory = new System.Windows.Forms.TextBox();
			this.lblMemory = new System.Windows.Forms.Label();
			this.btbApplyValFilter = new System.Windows.Forms.Button();
			this.Win32_Printer_Name = new System.Windows.Forms.TextBox();
			this.Win32_VideoController_Name = new System.Windows.Forms.TextBox();
			this.Win32_Processor_Name = new System.Windows.Forms.TextBox();
			this.Win32_BaseBoard_Product = new System.Windows.Forms.TextBox();
			this.lblPrinter = new System.Windows.Forms.Label();
			this.lblVideo = new System.Windows.Forms.Label();
			this.lblProc = new System.Windows.Forms.Label();
			this.lblMB = new System.Windows.Forms.Label();
			this.lblCompCount = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtComputerFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.HName,
									this.HValue});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(164, 29);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(423, 394);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// HName
			// 
			this.HName.Text = "Имя";
			this.HName.Width = 189;
			// 
			// HValue
			// 
			this.HValue.Text = "Значение";
			this.HValue.Width = 325;
			// 
			// btnGetInfo
			// 
			this.btnGetInfo.Location = new System.Drawing.Point(30, 8);
			this.btnGetInfo.Name = "btnGetInfo";
			this.btnGetInfo.Size = new System.Drawing.Size(81, 46);
			this.btnGetInfo.TabIndex = 3;
			this.btnGetInfo.Text = "Получить список";
			this.btnGetInfo.UseVisualStyleBackColor = true;
			this.btnGetInfo.Click += new System.EventHandler(this.BtnGetInfoClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1,
									this.toolStripStatusLabel2,
									this.toolStripStatusLabel3,
									this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 556);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(599, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(482, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(30, 70);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(81, 44);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.lblCompCount);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 426);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(599, 130);
			this.panel1.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Win32_ComputerSystem_TotalPhysicalMemory);
			this.groupBox1.Controls.Add(this.lblMemory);
			this.groupBox1.Controls.Add(this.btbApplyValFilter);
			this.groupBox1.Controls.Add(this.Win32_Printer_Name);
			this.groupBox1.Controls.Add(this.Win32_VideoController_Name);
			this.groupBox1.Controls.Add(this.Win32_Processor_Name);
			this.groupBox1.Controls.Add(this.Win32_BaseBoard_Product);
			this.groupBox1.Controls.Add(this.lblPrinter);
			this.groupBox1.Controls.Add(this.lblVideo);
			this.groupBox1.Controls.Add(this.lblProc);
			this.groupBox1.Controls.Add(this.lblMB);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 21);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(447, 106);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтры по характеристикам";
			// 
			// Win32_ComputerSystem_TotalPhysicalMemory
			// 
			this.Win32_ComputerSystem_TotalPhysicalMemory.Location = new System.Drawing.Point(334, 10);
			this.Win32_ComputerSystem_TotalPhysicalMemory.Name = "Win32_ComputerSystem_TotalPhysicalMemory";
			this.Win32_ComputerSystem_TotalPhysicalMemory.Size = new System.Drawing.Size(107, 20);
			this.Win32_ComputerSystem_TotalPhysicalMemory.TabIndex = 10;
			// 
			// lblMemory
			// 
			this.lblMemory.Location = new System.Drawing.Point(190, 13);
			this.lblMemory.Name = "lblMemory";
			this.lblMemory.Size = new System.Drawing.Size(153, 23);
			this.lblMemory.TabIndex = 9;
			this.lblMemory.Text = "Доступная память (ГБ)<=";
			// 
			// btbApplyValFilter
			// 
			this.btbApplyValFilter.Location = new System.Drawing.Point(327, 69);
			this.btbApplyValFilter.Name = "btbApplyValFilter";
			this.btbApplyValFilter.Size = new System.Drawing.Size(114, 32);
			this.btbApplyValFilter.TabIndex = 8;
			this.btbApplyValFilter.Text = "Применить фильтр";
			this.btbApplyValFilter.UseVisualStyleBackColor = true;
			this.btbApplyValFilter.Click += new System.EventHandler(this.BtbApplyValFilterClick);
			// 
			// Win32_Printer_Name
			// 
			this.Win32_Printer_Name.Location = new System.Drawing.Point(77, 66);
			this.Win32_Printer_Name.Name = "Win32_Printer_Name";
			this.Win32_Printer_Name.Size = new System.Drawing.Size(107, 20);
			this.Win32_Printer_Name.TabIndex = 7;
			// 
			// Win32_VideoController_Name
			// 
			this.Win32_VideoController_Name.Location = new System.Drawing.Point(334, 38);
			this.Win32_VideoController_Name.Name = "Win32_VideoController_Name";
			this.Win32_VideoController_Name.Size = new System.Drawing.Size(107, 20);
			this.Win32_VideoController_Name.TabIndex = 6;
			// 
			// Win32_Processor_Name
			// 
			this.Win32_Processor_Name.Location = new System.Drawing.Point(77, 38);
			this.Win32_Processor_Name.Name = "Win32_Processor_Name";
			this.Win32_Processor_Name.Size = new System.Drawing.Size(107, 20);
			this.Win32_Processor_Name.TabIndex = 5;
			// 
			// Win32_BaseBoard_Product
			// 
			this.Win32_BaseBoard_Product.Location = new System.Drawing.Point(77, 13);
			this.Win32_BaseBoard_Product.Name = "Win32_BaseBoard_Product";
			this.Win32_BaseBoard_Product.Size = new System.Drawing.Size(107, 20);
			this.Win32_BaseBoard_Product.TabIndex = 4;
			// 
			// lblPrinter
			// 
			this.lblPrinter.Location = new System.Drawing.Point(6, 69);
			this.lblPrinter.Name = "lblPrinter";
			this.lblPrinter.Size = new System.Drawing.Size(100, 15);
			this.lblPrinter.TabIndex = 3;
			this.lblPrinter.Text = "Принтер";
			// 
			// lblVideo
			// 
			this.lblVideo.Location = new System.Drawing.Point(190, 36);
			this.lblVideo.Name = "lblVideo";
			this.lblVideo.Size = new System.Drawing.Size(100, 15);
			this.lblVideo.TabIndex = 2;
			this.lblVideo.Text = "Видео";
			// 
			// lblProc
			// 
			this.lblProc.Location = new System.Drawing.Point(6, 41);
			this.lblProc.Name = "lblProc";
			this.lblProc.Size = new System.Drawing.Size(100, 15);
			this.lblProc.TabIndex = 1;
			this.lblProc.Text = "Процессор";
			// 
			// lblMB
			// 
			this.lblMB.Location = new System.Drawing.Point(6, 16);
			this.lblMB.Name = "lblMB";
			this.lblMB.Size = new System.Drawing.Size(100, 15);
			this.lblMB.TabIndex = 0;
			this.lblMB.Text = "Мат. плата";
			// 
			// lblCompCount
			// 
			this.lblCompCount.Location = new System.Drawing.Point(12, 2);
			this.lblCompCount.Name = "lblCompCount";
			this.lblCompCount.Size = new System.Drawing.Size(320, 16);
			this.lblCompCount.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnGetInfo);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(476, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(123, 130);
			this.panel2.TabIndex = 6;
			// 
			// txtComputerFilter
			// 
			this.txtComputerFilter.Location = new System.Drawing.Point(12, 42);
			this.txtComputerFilter.Name = "txtComputerFilter";
			this.txtComputerFilter.Size = new System.Drawing.Size(146, 20);
			this.txtComputerFilter.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 14);
			this.label1.TabIndex = 8;
			this.label1.Text = "Фильтр по компьютерам:";
			// 
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1});
			this.listView2.Location = new System.Drawing.Point(12, 68);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(146, 355);
			this.listView2.TabIndex = 1;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.SelectedIndexChanged += new System.EventHandler(this.ListView2SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Компьютеры";
			this.columnHeader1.Width = 147;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 578);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.txtComputerFilter);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Информация о компьютерах в сети";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblMemory;
		private System.Windows.Forms.TextBox Win32_ComputerSystem_TotalPhysicalMemory;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.Label lblMB;
		private System.Windows.Forms.Label lblProc;
		private System.Windows.Forms.Label lblVideo;
		private System.Windows.Forms.Label lblPrinter;
		private System.Windows.Forms.TextBox Win32_BaseBoard_Product;
		private System.Windows.Forms.TextBox Win32_Processor_Name;
		private System.Windows.Forms.TextBox Win32_VideoController_Name;
		private System.Windows.Forms.TextBox Win32_Printer_Name;
		private System.Windows.Forms.Button btbApplyValFilter;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblCompCount;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtComputerFilter;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button btnGetInfo;
		private System.Windows.Forms.ColumnHeader HValue;
		private System.Windows.Forms.ColumnHeader HName;
		private System.Windows.Forms.ListView listView1;
		
	
		
		
	}
}
