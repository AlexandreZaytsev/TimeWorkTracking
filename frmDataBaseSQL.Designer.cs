
namespace TimeWorkTracking
{
    partial class frmDataBaseSQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataBaseSQL));
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.picStatusTWT = new System.Windows.Forms.PictureBox();
            this.btCreateDBTwt = new System.Windows.Forms.Button();
            this.tbDatabaseTWT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPasswordTWT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAutentificationTWT = new System.Windows.Forms.ComboBox();
            this.tbServerTWT = new System.Windows.Forms.TextBox();
            this.tbUserNameTWT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btTestConnectionTwt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusTWT)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 168);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Database";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(13, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Подключение к SQL базе днных";
            // 
            // picStatusTWT
            // 
            this.picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.picStatusTWT.Location = new System.Drawing.Point(370, 8);
            this.picStatusTWT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picStatusTWT.Name = "picStatusTWT";
            this.picStatusTWT.Size = new System.Drawing.Size(27, 25);
            this.picStatusTWT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusTWT.TabIndex = 12;
            this.picStatusTWT.TabStop = false;
            // 
            // btCreateDBTwt
            // 
            this.btCreateDBTwt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCreateDBTwt.Location = new System.Drawing.Point(17, 193);
            this.btCreateDBTwt.Margin = new System.Windows.Forms.Padding(4);
            this.btCreateDBTwt.Name = "btCreateDBTwt";
            this.btCreateDBTwt.Size = new System.Drawing.Size(108, 28);
            this.btCreateDBTwt.TabIndex = 11;
            this.btCreateDBTwt.Text = "Создать БД";
            this.btCreateDBTwt.UseVisualStyleBackColor = true;
            this.btCreateDBTwt.Click += new System.EventHandler(this.btCreateDBTwt_Click);
            // 
            // tbDatabaseTWT
            // 
            this.tbDatabaseTWT.BackColor = System.Drawing.Color.FloralWhite;
            this.tbDatabaseTWT.Location = new System.Drawing.Point(134, 165);
            this.tbDatabaseTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbDatabaseTWT.Name = "tbDatabaseTWT";
            this.tbDatabaseTWT.Size = new System.Drawing.Size(260, 22);
            this.tbDatabaseTWT.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Server Name";
            // 
            // tbPasswordTWT
            // 
            this.tbPasswordTWT.Location = new System.Drawing.Point(133, 133);
            this.tbPasswordTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordTWT.Name = "tbPasswordTWT";
            this.tbPasswordTWT.PasswordChar = '*';
            this.tbPasswordTWT.Size = new System.Drawing.Size(261, 22);
            this.tbPasswordTWT.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Autentifiication";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Password";
            // 
            // cbAutentificationTWT
            // 
            this.cbAutentificationTWT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutentificationTWT.FormattingEnabled = true;
            this.cbAutentificationTWT.Items.AddRange(new object[] {
            "SQL Server Autentification",
            "Windows Autentification"});
            this.cbAutentificationTWT.Location = new System.Drawing.Point(134, 72);
            this.cbAutentificationTWT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAutentificationTWT.Name = "cbAutentificationTWT";
            this.cbAutentificationTWT.Size = new System.Drawing.Size(261, 24);
            this.cbAutentificationTWT.TabIndex = 4;
            this.cbAutentificationTWT.SelectedIndexChanged += new System.EventHandler(this.cbAutentificationTWT_SelectedIndexChanged);
            // 
            // tbServerTWT
            // 
            this.tbServerTWT.Location = new System.Drawing.Point(133, 39);
            this.tbServerTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbServerTWT.Name = "tbServerTWT";
            this.tbServerTWT.Size = new System.Drawing.Size(261, 22);
            this.tbServerTWT.TabIndex = 9;
            // 
            // tbUserNameTWT
            // 
            this.tbUserNameTWT.Location = new System.Drawing.Point(133, 104);
            this.tbUserNameTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserNameTWT.Name = "tbUserNameTWT";
            this.tbUserNameTWT.Size = new System.Drawing.Size(261, 22);
            this.tbUserNameTWT.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Name";
            // 
            // btTestConnectionTwt
            // 
            this.btTestConnectionTwt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionTwt.Location = new System.Drawing.Point(133, 193);
            this.btTestConnectionTwt.Margin = new System.Windows.Forms.Padding(4);
            this.btTestConnectionTwt.Name = "btTestConnectionTwt";
            this.btTestConnectionTwt.Size = new System.Drawing.Size(263, 28);
            this.btTestConnectionTwt.TabIndex = 0;
            this.btTestConnectionTwt.Text = "Проверитиь соединение";
            this.btTestConnectionTwt.UseVisualStyleBackColor = true;
            this.btTestConnectionTwt.Click += new System.EventHandler(this.btTestConnectionTwt_Click);
            // 
            // frmDataBaseSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 230);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.picStatusTWT);
            this.Controls.Add(this.btTestConnectionTwt);
            this.Controls.Add(this.btCreateDBTwt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDatabaseTWT);
            this.Controls.Add(this.tbUserNameTWT);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbServerTWT);
            this.Controls.Add(this.tbPasswordTWT);
            this.Controls.Add(this.cbAutentificationTWT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataBaseSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Настройка соединения ";
            this.Load += new System.EventHandler(this.frmDataBaseSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusTWT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox picStatusTWT;
        private System.Windows.Forms.Button btCreateDBTwt;
        private System.Windows.Forms.TextBox tbDatabaseTWT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbPasswordTWT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAutentificationTWT;
        private System.Windows.Forms.TextBox tbServerTWT;
        private System.Windows.Forms.TextBox tbUserNameTWT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btTestConnectionTwt;
    }
}