﻿
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
            this.mainPanelSQL = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusTWT)).BeginInit();
            this.mainPanelSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 171);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 18);
            this.label14.TabIndex = 14;
            this.label14.Text = "Database";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Gainsboro;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(13, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(280, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "Подключение к SQL базе днных";
            // 
            // picStatusTWT
            // 
            this.picStatusTWT.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.picStatusTWT.Location = new System.Drawing.Point(414, 10);
            this.picStatusTWT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picStatusTWT.Name = "picStatusTWT";
            this.picStatusTWT.Size = new System.Drawing.Size(30, 28);
            this.picStatusTWT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusTWT.TabIndex = 12;
            this.picStatusTWT.TabStop = false;
            // 
            // btCreateDBTwt
            // 
            this.btCreateDBTwt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCreateDBTwt.Location = new System.Drawing.Point(13, 200);
            this.btCreateDBTwt.Margin = new System.Windows.Forms.Padding(4);
            this.btCreateDBTwt.Name = "btCreateDBTwt";
            this.btCreateDBTwt.Size = new System.Drawing.Size(122, 32);
            this.btCreateDBTwt.TabIndex = 11;
            this.btCreateDBTwt.Text = "Создать БД";
            this.btCreateDBTwt.UseVisualStyleBackColor = true;
            this.btCreateDBTwt.Click += new System.EventHandler(this.btCreateDBTwt_Click);
            // 
            // tbDatabaseTWT
            // 
            this.tbDatabaseTWT.BackColor = System.Drawing.Color.FloralWhite;
            this.tbDatabaseTWT.Location = new System.Drawing.Point(147, 168);
            this.tbDatabaseTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbDatabaseTWT.Name = "tbDatabaseTWT";
            this.tbDatabaseTWT.Size = new System.Drawing.Size(292, 24);
            this.tbDatabaseTWT.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "Server Name";
            // 
            // tbPasswordTWT
            // 
            this.tbPasswordTWT.Location = new System.Drawing.Point(147, 136);
            this.tbPasswordTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordTWT.Name = "tbPasswordTWT";
            this.tbPasswordTWT.PasswordChar = '*';
            this.tbPasswordTWT.Size = new System.Drawing.Size(293, 24);
            this.tbPasswordTWT.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Autentifiication";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 18);
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
            this.cbAutentificationTWT.Location = new System.Drawing.Point(148, 75);
            this.cbAutentificationTWT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAutentificationTWT.Name = "cbAutentificationTWT";
            this.cbAutentificationTWT.Size = new System.Drawing.Size(293, 26);
            this.cbAutentificationTWT.TabIndex = 4;
            this.cbAutentificationTWT.SelectedIndexChanged += new System.EventHandler(this.cbAutentificationTWT_SelectedIndexChanged);
            // 
            // tbServerTWT
            // 
            this.tbServerTWT.Location = new System.Drawing.Point(148, 45);
            this.tbServerTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbServerTWT.Name = "tbServerTWT";
            this.tbServerTWT.Size = new System.Drawing.Size(293, 24);
            this.tbServerTWT.TabIndex = 9;
            // 
            // tbUserNameTWT
            // 
            this.tbUserNameTWT.Location = new System.Drawing.Point(147, 106);
            this.tbUserNameTWT.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserNameTWT.Name = "tbUserNameTWT";
            this.tbUserNameTWT.Size = new System.Drawing.Size(293, 24);
            this.tbUserNameTWT.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Name";
            // 
            // btTestConnectionTwt
            // 
            this.btTestConnectionTwt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionTwt.Location = new System.Drawing.Point(146, 200);
            this.btTestConnectionTwt.Margin = new System.Windows.Forms.Padding(4);
            this.btTestConnectionTwt.Name = "btTestConnectionTwt";
            this.btTestConnectionTwt.Size = new System.Drawing.Size(293, 32);
            this.btTestConnectionTwt.TabIndex = 0;
            this.btTestConnectionTwt.Text = "Проверитиь соединение";
            this.btTestConnectionTwt.UseVisualStyleBackColor = true;
            this.btTestConnectionTwt.Click += new System.EventHandler(this.btTestConnectionTwt_Click);
            // 
            // mainPanelSQL
            // 
            this.mainPanelSQL.Controls.Add(this.label12);
            this.mainPanelSQL.Controls.Add(this.label14);
            this.mainPanelSQL.Controls.Add(this.label7);
            this.mainPanelSQL.Controls.Add(this.label5);
            this.mainPanelSQL.Controls.Add(this.picStatusTWT);
            this.mainPanelSQL.Controls.Add(this.cbAutentificationTWT);
            this.mainPanelSQL.Controls.Add(this.btTestConnectionTwt);
            this.mainPanelSQL.Controls.Add(this.tbPasswordTWT);
            this.mainPanelSQL.Controls.Add(this.btCreateDBTwt);
            this.mainPanelSQL.Controls.Add(this.tbServerTWT);
            this.mainPanelSQL.Controls.Add(this.label6);
            this.mainPanelSQL.Controls.Add(this.label11);
            this.mainPanelSQL.Controls.Add(this.tbDatabaseTWT);
            this.mainPanelSQL.Controls.Add(this.tbUserNameTWT);
            this.mainPanelSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSQL.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSQL.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelSQL.Name = "mainPanelSQL";
            this.mainPanelSQL.Size = new System.Drawing.Size(457, 245);
            this.mainPanelSQL.TabIndex = 15;
            // 
            // frmDataBaseSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 245);
            this.Controls.Add(this.mainPanelSQL);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataBaseSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Настройка соединения ";
            this.Load += new System.EventHandler(this.frmDataBaseSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusTWT)).EndInit();
            this.mainPanelSQL.ResumeLayout(false);
            this.mainPanelSQL.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel mainPanelSQL;
    }
}