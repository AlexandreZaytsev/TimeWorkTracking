﻿
namespace TimeWorkTracking
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.new_db = new System.Windows.Forms.Button();
            this.connect_db = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.tabRegistration = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPasswordPASC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserNamePACS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHostNamePACS = new System.Windows.Forms.TextBox();
            this.btTestConnectionPacs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbServerTWT = new System.Windows.Forms.TextBox();
            this.tbPasswordTWT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbUserNameTWT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAutentificationTWT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDatabaseTWT = new System.Windows.Forms.TextBox();
            this.btTestConnectionTwt = new System.Windows.Forms.Button();
            this.btCreateDBTwt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabForm.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "FirstName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LastName";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "INSERT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(237, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "DELETE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(316, 282);
            this.dataGridView1.TabIndex = 9;
            // 
            // new_db
            // 
            this.new_db.Location = new System.Drawing.Point(734, 44);
            this.new_db.Name = "new_db";
            this.new_db.Size = new System.Drawing.Size(75, 23);
            this.new_db.TabIndex = 10;
            this.new_db.Text = "new_db";
            this.new_db.UseVisualStyleBackColor = true;
            this.new_db.Click += new System.EventHandler(this.button4_Click);
            // 
            // connect_db
            // 
            this.connect_db.Location = new System.Drawing.Point(528, 45);
            this.connect_db.Name = "connect_db";
            this.connect_db.Size = new System.Drawing.Size(75, 23);
            this.connect_db.TabIndex = 11;
            this.connect_db.Text = "connect_db";
            this.connect_db.UseVisualStyleBackColor = true;
            this.connect_db.Click += new System.EventHandler(this.connect_db_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(524, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "check_db";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // tabForm
            // 
            this.tabForm.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabForm.Controls.Add(this.tabRegistration);
            this.tabForm.Controls.Add(this.tabReport);
            this.tabForm.Controls.Add(this.tabSetting);
            this.tabForm.ItemSize = new System.Drawing.Size(120, 22);
            this.tabForm.Location = new System.Drawing.Point(437, 101);
            this.tabForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabForm.Name = "tabForm";
            this.tabForm.Padding = new System.Drawing.Point(1, 1);
            this.tabForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(463, 464);
            this.tabForm.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForm.TabIndex = 13;
            // 
            // tabRegistration
            // 
            this.tabRegistration.BackColor = System.Drawing.Color.Transparent;
            this.tabRegistration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegistration.Location = new System.Drawing.Point(4, 26);
            this.tabRegistration.Name = "tabRegistration";
            this.tabRegistration.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabRegistration.Size = new System.Drawing.Size(455, 434);
            this.tabRegistration.TabIndex = 0;
            this.tabRegistration.Text = "Регистрация";
            this.tabRegistration.Click += new System.EventHandler(this.tabRegistration_Click);
            // 
            // tabReport
            // 
            this.tabReport.BackColor = System.Drawing.Color.Transparent;
            this.tabReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabReport.Location = new System.Drawing.Point(4, 26);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabReport.Size = new System.Drawing.Size(455, 434);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Отчеты";
            // 
            // tabSetting
            // 
            this.tabSetting.BackColor = System.Drawing.Color.Transparent;
            this.tabSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSetting.Controls.Add(this.groupBox2);
            this.tabSetting.Controls.Add(this.groupBox1);
            this.tabSetting.Location = new System.Drawing.Point(4, 26);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(1);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(1);
            this.tabSetting.Size = new System.Drawing.Size(455, 434);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Настройки";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPasswordPASC);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbUserNamePACS);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbHostNamePACS);
            this.groupBox2.Controls.Add(this.btTestConnectionPacs);
            this.groupBox2.Location = new System.Drawing.Point(3, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 133);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Подключение к СКУД web Сервису";
            // 
            // tbPasswordPASC
            // 
            this.tbPasswordPASC.Location = new System.Drawing.Point(98, 75);
            this.tbPasswordPASC.Name = "tbPasswordPASC";
            this.tbPasswordPASC.Size = new System.Drawing.Size(197, 20);
            this.tbPasswordPASC.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Password";
            // 
            // tbUserNamePACS
            // 
            this.tbUserNamePACS.Location = new System.Drawing.Point(98, 52);
            this.tbUserNamePACS.Name = "tbUserNamePACS";
            this.tbUserNamePACS.Size = new System.Drawing.Size(197, 20);
            this.tbUserNamePACS.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "User Name";
            // 
            // label8
            // 
            this.label8.AccessibleName = "";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Database Name";
            // 
            // tbHostNamePACS
            // 
            this.tbHostNamePACS.AccessibleName = "";
            this.tbHostNamePACS.Location = new System.Drawing.Point(98, 29);
            this.tbHostNamePACS.Name = "tbHostNamePACS";
            this.tbHostNamePACS.Size = new System.Drawing.Size(197, 20);
            this.tbHostNamePACS.TabIndex = 3;
            // 
            // btTestConnectionPacs
            // 
            this.btTestConnectionPacs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionPacs.Location = new System.Drawing.Point(98, 101);
            this.btTestConnectionPacs.Name = "btTestConnectionPacs";
            this.btTestConnectionPacs.Size = new System.Drawing.Size(197, 23);
            this.btTestConnectionPacs.TabIndex = 1;
            this.btTestConnectionPacs.Text = "Проверитиь соединение";
            this.btTestConnectionPacs.UseVisualStyleBackColor = true;
            this.btTestConnectionPacs.Click += new System.EventHandler(this.btTestConnectionPacs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btCreateDBTwt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbPasswordTWT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbAutentificationTWT);
            this.groupBox1.Controls.Add(this.tbServerTWT);
            this.groupBox1.Controls.Add(this.tbUserNameTWT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbDatabaseTWT);
            this.groupBox1.Controls.Add(this.btTestConnectionTwt);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 179);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение к SQL базе днных";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Server Name";
            // 
            // tbServerTWT
            // 
            this.tbServerTWT.Location = new System.Drawing.Point(98, 19);
            this.tbServerTWT.Name = "tbServerTWT";
            this.tbServerTWT.Size = new System.Drawing.Size(197, 20);
            this.tbServerTWT.TabIndex = 9;
            // 
            // tbPasswordTWT
            // 
            this.tbPasswordTWT.Location = new System.Drawing.Point(98, 118);
            this.tbPasswordTWT.Name = "tbPasswordTWT";
            this.tbPasswordTWT.PasswordChar = '*';
            this.tbPasswordTWT.Size = new System.Drawing.Size(197, 20);
            this.tbPasswordTWT.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Password";
            // 
            // tbUserNameTWT
            // 
            this.tbUserNameTWT.Location = new System.Drawing.Point(98, 95);
            this.tbUserNameTWT.Name = "tbUserNameTWT";
            this.tbUserNameTWT.Size = new System.Drawing.Size(197, 20);
            this.tbUserNameTWT.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Name";
            // 
            // cbAutentificationTWT
            // 
            this.cbAutentificationTWT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutentificationTWT.FormattingEnabled = true;
            this.cbAutentificationTWT.Location = new System.Drawing.Point(98, 68);
            this.cbAutentificationTWT.Name = "cbAutentificationTWT";
            this.cbAutentificationTWT.Size = new System.Drawing.Size(197, 21);
            this.cbAutentificationTWT.TabIndex = 4;
            this.cbAutentificationTWT.SelectedIndexChanged += new System.EventHandler(this.cbAutentificationTWT_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Autentifiication";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Database Name";
            // 
            // tbDatabaseTWT
            // 
            this.tbDatabaseTWT.Location = new System.Drawing.Point(98, 42);
            this.tbDatabaseTWT.Name = "tbDatabaseTWT";
            this.tbDatabaseTWT.Size = new System.Drawing.Size(197, 20);
            this.tbDatabaseTWT.TabIndex = 1;
            // 
            // btTestConnectionTwt
            // 
            this.btTestConnectionTwt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btTestConnectionTwt.Location = new System.Drawing.Point(98, 144);
            this.btTestConnectionTwt.Name = "btTestConnectionTwt";
            this.btTestConnectionTwt.Size = new System.Drawing.Size(197, 23);
            this.btTestConnectionTwt.TabIndex = 0;
            this.btTestConnectionTwt.Text = "Проверитиь соединение";
            this.btTestConnectionTwt.UseVisualStyleBackColor = true;
            // 
            // btCreateDBTwt
            // 
            this.btCreateDBTwt.Enabled = false;
            this.btCreateDBTwt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCreateDBTwt.Location = new System.Drawing.Point(11, 144);
            this.btCreateDBTwt.Name = "btCreateDBTwt";
            this.btCreateDBTwt.Size = new System.Drawing.Size(81, 23);
            this.btCreateDBTwt.TabIndex = 11;
            this.btCreateDBTwt.Text = "Создать БД";
            this.btCreateDBTwt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 618);
            this.Controls.Add(this.tabForm);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.connect_db);
            this.Controls.Add(this.new_db);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabForm.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button new_db;
        private System.Windows.Forms.Button connect_db;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabForm;
        private System.Windows.Forms.TabPage tabRegistration;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPasswordPASC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserNamePACS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHostNamePACS;
        private System.Windows.Forms.Button btTestConnectionPacs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbServerTWT;
        private System.Windows.Forms.TextBox tbPasswordTWT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbUserNameTWT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAutentificationTWT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDatabaseTWT;
        private System.Windows.Forms.Button btTestConnectionTwt;
        private System.Windows.Forms.Button btCreateDBTwt;
    }
}

