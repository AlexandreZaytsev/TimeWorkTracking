﻿
namespace TimeWorkTracking
{
    partial class frmMain
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
            this.tabForm = new System.Windows.Forms.TabControl();
            this.tabRegistration = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.picSetting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "FirstName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "LastName";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 34);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 78);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 124);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "INSERT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 73);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(316, 119);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "DELETE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 181);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(421, 347);
            this.dataGridView1.TabIndex = 9;
            // 
            // new_db
            // 
            this.new_db.Location = new System.Drawing.Point(979, 54);
            this.new_db.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.new_db.Name = "new_db";
            this.new_db.Size = new System.Drawing.Size(100, 28);
            this.new_db.TabIndex = 10;
            this.new_db.Text = "new_db";
            this.new_db.UseVisualStyleBackColor = true;
            this.new_db.Click += new System.EventHandler(this.button4_Click);
            // 
            // connect_db
            // 
            this.connect_db.Location = new System.Drawing.Point(704, 55);
            this.connect_db.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connect_db.Name = "connect_db";
            this.connect_db.Size = new System.Drawing.Size(100, 28);
            this.connect_db.TabIndex = 11;
            this.connect_db.Text = "connect_db";
            this.connect_db.UseVisualStyleBackColor = true;
            this.connect_db.Click += new System.EventHandler(this.connect_db_Click);
            // 
            // tabForm
            // 
            this.tabForm.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabForm.Controls.Add(this.tabRegistration);
            this.tabForm.Controls.Add(this.tabReport);
            this.tabForm.Controls.Add(this.tabSetting);
            this.tabForm.ItemSize = new System.Drawing.Size(120, 22);
            this.tabForm.Location = new System.Drawing.Point(551, 156);
            this.tabForm.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabForm.Name = "tabForm";
            this.tabForm.Padding = new System.Drawing.Point(1, 1);
            this.tabForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(617, 495);
            this.tabForm.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForm.TabIndex = 13;
            // 
            // tabRegistration
            // 
            this.tabRegistration.BackColor = System.Drawing.Color.Transparent;
            this.tabRegistration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegistration.Location = new System.Drawing.Point(4, 26);
            this.tabRegistration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabRegistration.Name = "tabRegistration";
            this.tabRegistration.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabRegistration.Size = new System.Drawing.Size(609, 465);
            this.tabRegistration.TabIndex = 0;
            this.tabRegistration.Text = "Регистрация";
            this.tabRegistration.Click += new System.EventHandler(this.tabRegistration_Click);
            // 
            // tabReport
            // 
            this.tabReport.BackColor = System.Drawing.Color.Transparent;
            this.tabReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabReport.Location = new System.Drawing.Point(4, 26);
            this.tabReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabReport.Size = new System.Drawing.Size(609, 465);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Отчеты";
            // 
            // tabSetting
            // 
            this.tabSetting.BackColor = System.Drawing.Color.Transparent;
            this.tabSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSetting.Location = new System.Drawing.Point(4, 26);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(1);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(1);
            this.tabSetting.Size = new System.Drawing.Size(609, 465);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Настройки";
            // 
            // picSetting
            // 
            this.picSetting.BackColor = System.Drawing.SystemColors.Control;
            this.picSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSetting.Image = global::TimeWorkTracking.Properties.Resources.setting;
            this.picSetting.Location = new System.Drawing.Point(1164, 34);
            this.picSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picSetting.Name = "picSetting";
            this.picSetting.Size = new System.Drawing.Size(39, 33);
            this.picSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSetting.TabIndex = 14;
            this.picSetting.TabStop = false;
            this.picSetting.Click += new System.EventHandler(this.picSetting_Click);
            this.picSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSetting_MouseDown);
            this.picSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSetting_MouseUp);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 721);
            this.Controls.Add(this.picSetting);
            this.Controls.Add(this.tabForm);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSetting)).EndInit();
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
        private System.Windows.Forms.TabControl tabForm;
        private System.Windows.Forms.TabPage tabRegistration;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.PictureBox picSetting;
    }
}

