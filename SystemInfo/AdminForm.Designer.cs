/*
 * Сделано в SharpDevelop.
 * Пользователь: 055makarov
 * Дата: 20.04.2015
 * Время: 15:42
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace SystemInfo
{
	partial class AdminForm
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
			this.btnAccept = new System.Windows.Forms.Button();
			this.txtAdminLogin = new System.Windows.Forms.TextBox();
			this.txtAdminPass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(104, 112);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(102, 29);
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "Подтвердить";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.BtnAcceptClick);
			// 
			// txtAdminLogin
			// 
			this.txtAdminLogin.Location = new System.Drawing.Point(67, 35);
			this.txtAdminLogin.Name = "txtAdminLogin";
			this.txtAdminLogin.Size = new System.Drawing.Size(177, 20);
			this.txtAdminLogin.TabIndex = 1;
			// 
			// txtAdminPass
			// 
			this.txtAdminPass.Location = new System.Drawing.Point(67, 81);
			this.txtAdminPass.Name = "txtAdminPass";
			this.txtAdminPass.PasswordChar = '*';
			this.txtAdminPass.Size = new System.Drawing.Size(177, 20);
			this.txtAdminPass.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(44, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Учетная запись администратора";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(67, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Пароль";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 153);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAdminPass);
			this.Controls.Add(this.txtAdminLogin);
			this.Controls.Add(this.btnAccept);
			this.Name = "AdminForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtAdminPass;
		public System.Windows.Forms.TextBox txtAdminLogin;
		private System.Windows.Forms.Button btnAccept;
	}
}
