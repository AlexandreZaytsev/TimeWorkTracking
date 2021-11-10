﻿
namespace TimeWorkTracking
{
    partial class frmSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.mainPanelSetting = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btFileName = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRangePass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSheetPass = new System.Windows.Forms.ComboBox();
            this.tbRangeUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSheetUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btImportPass = new System.Windows.Forms.Button();
            this.imgListButtonSetting = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.btImportUsers = new System.Windows.Forms.Button();
            this.statusStripSetting = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarImport = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTipMsgSetting = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorkerSetting = new System.ComponentModel.BackgroundWorker();
            this.mainPanelSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStripSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelSetting
            // 
            this.mainPanelSetting.Controls.Add(this.label2);
            this.mainPanelSetting.Controls.Add(this.btFileName);
            this.mainPanelSetting.Controls.Add(this.tbPath);
            this.mainPanelSetting.Controls.Add(this.groupBox1);
            this.mainPanelSetting.Controls.Add(this.statusStripSetting);
            this.mainPanelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelSetting.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSetting.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelSetting.Name = "mainPanelSetting";
            this.mainPanelSetting.Size = new System.Drawing.Size(518, 141);
            this.mainPanelSetting.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Файл";
            // 
            // btFileName
            // 
            this.btFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFileName.Location = new System.Drawing.Point(481, 5);
            this.btFileName.Name = "btFileName";
            this.btFileName.Size = new System.Drawing.Size(29, 23);
            this.btFileName.TabIndex = 28;
            this.btFileName.Text = "...";
            this.btFileName.UseVisualStyleBackColor = true;
            this.btFileName.Click += new System.EventHandler(this.btFileName_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(55, 6);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(425, 21);
            this.tbPath.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRangePass);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbSheetPass);
            this.groupBox1.Controls.Add(this.tbRangeUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbSheetUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btImportPass);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btImportUsers);
            this.groupBox1.Location = new System.Drawing.Point(6, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(506, 81);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инициализация БД";
            // 
            // tbRangePass
            // 
            this.tbRangePass.Location = new System.Drawing.Point(306, 49);
            this.tbRangePass.Name = "tbRangePass";
            this.tbRangePass.Size = new System.Drawing.Size(100, 21);
            this.tbRangePass.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Диапазон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Лист";
            // 
            // cbSheetPass
            // 
            this.cbSheetPass.FormattingEnabled = true;
            this.cbSheetPass.Location = new System.Drawing.Point(127, 49);
            this.cbSheetPass.Name = "cbSheetPass";
            this.cbSheetPass.Size = new System.Drawing.Size(103, 23);
            this.cbSheetPass.TabIndex = 34;
            // 
            // tbRangeUser
            // 
            this.tbRangeUser.Location = new System.Drawing.Point(306, 19);
            this.tbRangeUser.Name = "tbRangeUser";
            this.tbRangeUser.Size = new System.Drawing.Size(100, 21);
            this.tbRangeUser.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Диапазон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Лист";
            // 
            // cbSheetUser
            // 
            this.cbSheetUser.FormattingEnabled = true;
            this.cbSheetUser.Location = new System.Drawing.Point(127, 19);
            this.cbSheetUser.Name = "cbSheetUser";
            this.cbSheetUser.Size = new System.Drawing.Size(103, 23);
            this.cbSheetUser.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Проходы";
            // 
            // btImportPass
            // 
            this.btImportPass.ImageIndex = 7;
            this.btImportPass.ImageList = this.imgListButtonSetting;
            this.btImportPass.Location = new System.Drawing.Point(413, 46);
            this.btImportPass.Margin = new System.Windows.Forms.Padding(2);
            this.btImportPass.Name = "btImportPass";
            this.btImportPass.Size = new System.Drawing.Size(84, 26);
            this.btImportPass.TabIndex = 26;
            this.btImportPass.Text = "Импорт";
            this.btImportPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportPass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImportPass.UseVisualStyleBackColor = true;
            this.btImportPass.Click += new System.EventHandler(this.btImportPass_Click);
            // 
            // imgListButtonSetting
            // 
            this.imgListButtonSetting.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonSetting.ImageStream")));
            this.imgListButtonSetting.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonSetting.Images.SetKeyName(0, "db_48.png");
            this.imgListButtonSetting.Images.SetKeyName(1, "db_add_48.png");
            this.imgListButtonSetting.Images.SetKeyName(2, "db_edit_48.png");
            this.imgListButtonSetting.Images.SetKeyName(3, "db_find_48.png");
            this.imgListButtonSetting.Images.SetKeyName(4, "db_lock_48.png");
            this.imgListButtonSetting.Images.SetKeyName(5, "db_unlock_48.png");
            this.imgListButtonSetting.Images.SetKeyName(6, "db_upload_48.png");
            this.imgListButtonSetting.Images.SetKeyName(7, "db_import_48.png");
            this.imgListButtonSetting.Images.SetKeyName(8, "db_export_48.png");
            this.imgListButtonSetting.Images.SetKeyName(9, "attention_48.png");
            this.imgListButtonSetting.Images.SetKeyName(10, "info_48.png");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Сотрудники";
            // 
            // btImportUsers
            // 
            this.btImportUsers.ImageIndex = 7;
            this.btImportUsers.ImageList = this.imgListButtonSetting;
            this.btImportUsers.Location = new System.Drawing.Point(413, 16);
            this.btImportUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btImportUsers.Name = "btImportUsers";
            this.btImportUsers.Size = new System.Drawing.Size(84, 26);
            this.btImportUsers.TabIndex = 24;
            this.btImportUsers.Text = "Импорт";
            this.btImportUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImportUsers.UseVisualStyleBackColor = true;
            this.btImportUsers.Click += new System.EventHandler(this.btImportUsers_Click);
            // 
            // statusStripSetting
            // 
            this.statusStripSetting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripProgressBarImport});
            this.statusStripSetting.Location = new System.Drawing.Point(0, 117);
            this.statusStripSetting.Name = "statusStripSetting";
            this.statusStripSetting.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStripSetting.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripSetting.Size = new System.Drawing.Size(518, 24);
            this.statusStripSetting.SizingGrip = false;
            this.statusStripSetting.TabIndex = 25;
            this.statusStripSetting.Text = "statusStripSetting";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(204, 19);
            this.toolStripStatusLabelInfo.Spring = true;
            this.toolStripStatusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBarImport
            // 
            this.toolStripProgressBarImport.Name = "toolStripProgressBarImport";
            this.toolStripProgressBarImport.Size = new System.Drawing.Size(270, 18);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 141);
            this.Controls.Add(this.mainPanelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSetting";
            this.Text = "Импорт Экспорт";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.mainPanelSetting.ResumeLayout(false);
            this.mainPanelSetting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStripSetting.ResumeLayout(false);
            this.statusStripSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelSetting;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ImageList imgListButtonSetting;
        private System.Windows.Forms.ToolTip toolTipMsgSetting;
        private System.Windows.Forms.Button btImportUsers;
        private System.Windows.Forms.StatusStrip statusStripSetting;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btImportPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFileName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbRangePass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSheetPass;
        private System.Windows.Forms.TextBox tbRangeUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSheetUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSetting;
    }
}