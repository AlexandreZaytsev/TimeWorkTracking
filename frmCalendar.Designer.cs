﻿
namespace TimeWorkTracking
{
    partial class frmCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendar));
            this.mainPanelCalendar = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.imgListButtonCalendar = new System.Windows.Forms.ImageList(this.components);
            this.btInsert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstwDataBaseDaysCalendar = new System.Windows.Forms.ListView();
            this.tUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListStatusCalendar = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtSource = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtWork = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.lstwDataBaseCalendar = new System.Windows.Forms.ListView();
            this.used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dwork = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dref = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lMsg = new System.Windows.Forms.Label();
            this.toolTipMsgCalendar = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mainPanelCalendar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelCalendar
            // 
            this.mainPanelCalendar.Controls.Add(this.btUpdate);
            this.mainPanelCalendar.Controls.Add(this.btInsert);
            this.mainPanelCalendar.Controls.Add(this.panel1);
            this.mainPanelCalendar.Controls.Add(this.lstwDataBaseCalendar);
            this.mainPanelCalendar.Controls.Add(this.lMsg);
            this.mainPanelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelCalendar.Location = new System.Drawing.Point(0, 0);
            this.mainPanelCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelCalendar.Name = "mainPanelCalendar";
            this.mainPanelCalendar.Size = new System.Drawing.Size(740, 301);
            this.mainPanelCalendar.TabIndex = 3;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imgListButtonCalendar;
            this.btUpdate.Location = new System.Drawing.Point(627, 268);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(105, 26);
            this.btUpdate.TabIndex = 19;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // imgListButtonCalendar
            // 
            this.imgListButtonCalendar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonCalendar.ImageStream")));
            this.imgListButtonCalendar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonCalendar.Images.SetKeyName(0, "db_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(1, "db_add_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(2, "db_edit_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(3, "db_find_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(4, "db_lock_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(5, "db_unlock_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(6, "db_upload_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(7, "db_import_48.png");
            this.imgListButtonCalendar.Images.SetKeyName(8, "db_export_48.png");
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imgListButtonCalendar;
            this.btInsert.Location = new System.Drawing.Point(383, 268);
            this.btInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(105, 26);
            this.btInsert.TabIndex = 18;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbDataType);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbID);
            this.panel1.Controls.Add(this.chUse);
            this.panel1.Location = new System.Drawing.Point(383, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 253);
            this.panel1.TabIndex = 17;
            // 
            // lstwDataBaseDaysCalendar
            // 
            this.lstwDataBaseDaysCalendar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tUsed,
            this.tDate,
            this.tName});
            this.lstwDataBaseDaysCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstwDataBaseDaysCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBaseDaysCalendar.HideSelection = false;
            this.lstwDataBaseDaysCalendar.LabelWrap = false;
            this.lstwDataBaseDaysCalendar.Location = new System.Drawing.Point(3, 17);
            this.lstwDataBaseDaysCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.lstwDataBaseDaysCalendar.MultiSelect = false;
            this.lstwDataBaseDaysCalendar.Name = "lstwDataBaseDaysCalendar";
            this.lstwDataBaseDaysCalendar.ShowItemToolTips = true;
            this.lstwDataBaseDaysCalendar.Size = new System.Drawing.Size(332, 105);
            this.lstwDataBaseDaysCalendar.StateImageList = this.imgListStatusCalendar;
            this.lstwDataBaseDaysCalendar.TabIndex = 31;
            this.lstwDataBaseDaysCalendar.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseDaysCalendar.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseDaysCalendar.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBaseDaysCalendar_ColumnClick);
            this.lstwDataBaseDaysCalendar.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBaseDaysCalendar_ColumnWidthChanging);
            this.lstwDataBaseDaysCalendar.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseDaysCalendar_SelectedIndexChanged);
            // 
            // tUsed
            // 
            this.tUsed.Text = "";
            this.tUsed.Width = 29;
            // 
            // tDate
            // 
            this.tDate.Text = "Дата";
            this.tDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tDate.Width = 90;
            // 
            // tName
            // 
            this.tName.Text = "Наименование";
            this.tName.Width = 150;
            // 
            // imgListStatusCalendar
            // 
            this.imgListStatusCalendar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatusCalendar.ImageStream")));
            this.imgListStatusCalendar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatusCalendar.Images.SetKeyName(0, "off5m.png");
            this.imgListStatusCalendar.Images.SetKeyName(1, "on5m.png");
            this.imgListStatusCalendar.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatusCalendar.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 225);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Продолжительность дня";
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(182, 222);
            this.cbDataType.Margin = new System.Windows.Forms.Padding(2);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(155, 23);
            this.cbDataType.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtSource);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtWork);
            this.groupBox1.Location = new System.Drawing.Point(3, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 69);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата производственного календаря";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Фактическая";
            this.toolTipMsgCalendar.SetToolTip(this.label3, "Реальная дата (перенос даты)");
            // 
            // dtSource
            // 
            this.dtSource.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtSource.Location = new System.Drawing.Point(179, 40);
            this.dtSource.Name = "dtSource";
            this.dtSource.Size = new System.Drawing.Size(155, 21);
            this.dtSource.TabIndex = 25;
            this.toolTipMsgCalendar.SetToolTip(this.dtSource, "Оригинальная дата из календаря");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Исходная";
            // 
            // dtWork
            // 
            this.dtWork.Location = new System.Drawing.Point(6, 40);
            this.dtWork.Name = "dtWork";
            this.dtWork.Size = new System.Drawing.Size(155, 21);
            this.dtWork.TabIndex = 23;
            this.toolTipMsgCalendar.SetToolTip(this.dtWork, "Дата с учетом переносов");
            this.dtWork.ValueChanged += new System.EventHandler(this.dtWork_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "id:";
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.SystemColors.Control;
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(28, 7);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(36, 14);
            this.tbID.TabIndex = 21;
            // 
            // chUse
            // 
            this.chUse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chUse.AutoSize = true;
            this.chUse.FlatAppearance.BorderSize = 0;
            this.chUse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.chUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chUse.ImageIndex = 0;
            this.chUse.ImageList = this.imgListStatusCalendar;
            this.chUse.Location = new System.Drawing.Point(253, 2);
            this.chUse.Margin = new System.Windows.Forms.Padding(2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(84, 25);
            this.chUse.TabIndex = 16;
            this.chUse.Text = "Доступ";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipMsgCalendar.SetToolTip(this.chUse, "Дата активна");
            this.chUse.UseVisualStyleBackColor = true;
            // 
            // lstwDataBaseCalendar
            // 
            this.lstwDataBaseCalendar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.used,
            this.dwork,
            this.dref,
            this.name,
            this.type});
            this.lstwDataBaseCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBaseCalendar.HideSelection = false;
            this.lstwDataBaseCalendar.LabelWrap = false;
            this.lstwDataBaseCalendar.Location = new System.Drawing.Point(8, 10);
            this.lstwDataBaseCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.lstwDataBaseCalendar.MultiSelect = false;
            this.lstwDataBaseCalendar.Name = "lstwDataBaseCalendar";
            this.lstwDataBaseCalendar.Size = new System.Drawing.Size(370, 284);
            this.lstwDataBaseCalendar.StateImageList = this.imgListStatusCalendar;
            this.lstwDataBaseCalendar.TabIndex = 15;
            this.lstwDataBaseCalendar.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseCalendar.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseCalendar.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBaseCalendar_ColumnClick);
            this.lstwDataBaseCalendar.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBaseCalendar_ColumnWidthChanging);
            this.lstwDataBaseCalendar.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseCalendar_SelectedIndexChanged);
            // 
            // used
            // 
            this.used.Text = "";
            this.used.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.used.Width = 29;
            // 
            // dwork
            // 
            this.dwork.Text = "Дата";
            this.dwork.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dwork.Width = 80;
            // 
            // dref
            // 
            this.dref.Text = "Сссылка";
            this.dref.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dref.Width = 80;
            // 
            // name
            // 
            this.name.Text = "Наименование";
            this.name.Width = 200;
            // 
            // type
            // 
            this.type.Text = "Тип дня";
            // 
            // lMsg
            // 
            this.lMsg.AutoSize = true;
            this.lMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lMsg.ImageIndex = 6;
            this.lMsg.ImageList = this.imgListButtonCalendar;
            this.lMsg.Location = new System.Drawing.Point(570, 272);
            this.lMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(157, 17);
            this.lMsg.TabIndex = 20;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstwDataBaseDaysCalendar);
            this.groupBox2.Location = new System.Drawing.Point(3, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 125);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Календарь дат";
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 301);
            this.Controls.Add(this.mainPanelCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCalendar";
            this.Text = "Производственный календарь";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            this.mainPanelCalendar.ResumeLayout(false);
            this.mainPanelCalendar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelCalendar;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.ListView lstwDataBaseCalendar;
        private System.Windows.Forms.ColumnHeader used;
        private System.Windows.Forms.ColumnHeader dwork;
        private System.Windows.Forms.ColumnHeader dref;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Label lMsg;
        private System.Windows.Forms.ImageList imgListStatusCalendar;
        private System.Windows.Forms.ImageList imgListButtonCalendar;
        private System.Windows.Forms.ToolTip toolTipMsgCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.DateTimePicker dtWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstwDataBaseDaysCalendar;
        private System.Windows.Forms.ColumnHeader tUsed;
        private System.Windows.Forms.ColumnHeader tDate;
        private System.Windows.Forms.ColumnHeader tName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}