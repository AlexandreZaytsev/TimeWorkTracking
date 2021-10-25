
namespace TimeWorkTracking
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.mainPanelUsers = new System.Windows.Forms.Panel();
            this.prBts = new System.Windows.Forms.Panel();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.rbInsert = new System.Windows.Forms.RadioButton();
            this.btImport = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.ImageList(this.components);
            this.btUpdate = new System.Windows.Forms.Button();
            this.lstwDataBaseUsers = new System.Windows.Forms.ListView();
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imglStatus = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.udAfterM = new System.Windows.Forms.DateTimePicker();
            this.udAfterH = new System.Windows.Forms.DateTimePicker();
            this.udBeforeM = new System.Windows.Forms.DateTimePicker();
            this.chUse = new System.Windows.Forms.CheckBox();
            this.udBeforeH = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.chbLunch = new System.Windows.Forms.CheckBox();
            this.cbSheme = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipMsg = new System.Windows.Forms.ToolTip(this.components);
            this.btInsert = new System.Windows.Forms.Button();
            this.mainPanelUsers.SuspendLayout();
            this.prBts.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelUsers
            // 
            this.mainPanelUsers.Controls.Add(this.btInsert);
            this.mainPanelUsers.Controls.Add(this.prBts);
            this.mainPanelUsers.Controls.Add(this.btImport);
            this.mainPanelUsers.Controls.Add(this.btUpdate);
            this.mainPanelUsers.Controls.Add(this.lstwDataBaseUsers);
            this.mainPanelUsers.Controls.Add(this.panel3);
            this.mainPanelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelUsers.Location = new System.Drawing.Point(0, 0);
            this.mainPanelUsers.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelUsers.Name = "mainPanelUsers";
            this.mainPanelUsers.Size = new System.Drawing.Size(669, 357);
            this.mainPanelUsers.TabIndex = 0;
            // 
            // prBts
            // 
            this.prBts.Controls.Add(this.rbUpdate);
            this.prBts.Controls.Add(this.rbInsert);
            this.prBts.Enabled = false;
            this.prBts.Location = new System.Drawing.Point(445, 312);
            this.prBts.Name = "prBts";
            this.prBts.Size = new System.Drawing.Size(184, 23);
            this.prBts.TabIndex = 27;
            // 
            // rbUpdate
            // 
            this.rbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Location = new System.Drawing.Point(121, 0);
            this.rbUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.Size = new System.Drawing.Size(83, 19);
            this.rbUpdate.TabIndex = 1;
            this.rbUpdate.Text = "Обновить";
            this.rbUpdate.UseVisualStyleBackColor = true;
            this.rbUpdate.CheckedChanged += new System.EventHandler(this.rbInsertUpdate_CheckedChanged);
            // 
            // rbInsert
            // 
            this.rbInsert.AutoSize = true;
            this.rbInsert.Checked = true;
            this.rbInsert.Location = new System.Drawing.Point(8, 4);
            this.rbInsert.Margin = new System.Windows.Forms.Padding(0);
            this.rbInsert.Name = "rbInsert";
            this.rbInsert.Size = new System.Drawing.Size(83, 19);
            this.rbInsert.TabIndex = 0;
            this.rbInsert.TabStop = true;
            this.rbInsert.Text = "Добавить";
            this.rbInsert.UseVisualStyleBackColor = true;
            this.rbInsert.CheckedChanged += new System.EventHandler(this.rbInsertUpdate_CheckedChanged);
            // 
            // btImport
            // 
            this.btImport.ImageIndex = 7;
            this.btImport.ImageList = this.imageButton;
            this.btImport.Location = new System.Drawing.Point(426, 261);
            this.btImport.Margin = new System.Windows.Forms.Padding(2);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(109, 26);
            this.btImport.TabIndex = 23;
            this.btImport.Text = "Импорт";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // imageButton
            // 
            this.imageButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageButton.ImageStream")));
            this.imageButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageButton.Images.SetKeyName(0, "db_48.png");
            this.imageButton.Images.SetKeyName(1, "db_add_48.png");
            this.imageButton.Images.SetKeyName(2, "db_edit_48.png");
            this.imageButton.Images.SetKeyName(3, "db_find_48.png");
            this.imageButton.Images.SetKeyName(4, "db_lock_48.png");
            this.imageButton.Images.SetKeyName(5, "db_unlock_48.png");
            this.imageButton.Images.SetKeyName(6, "db_upload_48.png");
            this.imageButton.Images.SetKeyName(7, "db_import_48.png");
            this.imageButton.Images.SetKeyName(8, "db_export_48.png");
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imageButton;
            this.btUpdate.Location = new System.Drawing.Point(556, 261);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(105, 26);
            this.btUpdate.TabIndex = 21;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // lstwDataBaseUsers
            // 
            this.lstwDataBaseUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.access,
            this.fio});
            this.lstwDataBaseUsers.HideSelection = false;
            this.lstwDataBaseUsers.LabelWrap = false;
            this.lstwDataBaseUsers.Location = new System.Drawing.Point(8, 10);
            this.lstwDataBaseUsers.Margin = new System.Windows.Forms.Padding(2);
            this.lstwDataBaseUsers.MultiSelect = false;
            this.lstwDataBaseUsers.Name = "lstwDataBaseUsers";
            this.lstwDataBaseUsers.Size = new System.Drawing.Size(281, 277);
            this.lstwDataBaseUsers.StateImageList = this.imglStatus;
            this.lstwDataBaseUsers.TabIndex = 18;
            this.lstwDataBaseUsers.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseUsers.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBaseUsers_ColumnClick);
            this.lstwDataBaseUsers.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBaseUsers_ColumnWidthChanging);
            this.lstwDataBaseUsers.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseUsers_SelectedIndexChanged);
            // 
            // access
            // 
            this.access.Text = "";
            this.access.Width = 29;
            // 
            // fio
            // 
            this.fio.Text = "ФИО";
            this.fio.Width = 300;
            // 
            // imglStatus
            // 
            this.imglStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglStatus.ImageStream")));
            this.imglStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imglStatus.Images.SetKeyName(0, "off5m.png");
            this.imglStatus.Images.SetKeyName(1, "on5m.png");
            this.imglStatus.Images.SetKeyName(2, "db_add_48x72.png");
            this.imglStatus.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tbNote);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.tbUserID);
            this.panel3.Controls.Add(this.udAfterM);
            this.panel3.Controls.Add(this.udAfterH);
            this.panel3.Controls.Add(this.udBeforeM);
            this.panel3.Controls.Add(this.chUse);
            this.panel3.Controls.Add(this.udBeforeH);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(292, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 248);
            this.panel3.TabIndex = 16;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(7, 54);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(357, 44);
            this.tbNote.TabIndex = 25;
            this.toolTipMsg.SetToolTip(this.tbNote, "Комментарии");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "id:";
            // 
            // tbName
            // 
            this.tbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.Location = new System.Drawing.Point(112, 29);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(246, 21);
            this.tbName.TabIndex = 20;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbUserID
            // 
            this.tbUserID.BackColor = System.Drawing.SystemColors.Control;
            this.tbUserID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserID.Enabled = false;
            this.tbUserID.Location = new System.Drawing.Point(23, 6);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(2);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(134, 14);
            this.tbUserID.TabIndex = 22;
            // 
            // udAfterM
            // 
            this.udAfterM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.CustomFormat = "mm";
            this.udAfterM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterM.Location = new System.Drawing.Point(306, 173);
            this.udAfterM.Margin = new System.Windows.Forms.Padding(2);
            this.udAfterM.Name = "udAfterM";
            this.udAfterM.ShowUpDown = true;
            this.udAfterM.Size = new System.Drawing.Size(43, 26);
            this.udAfterM.TabIndex = 19;
            this.udAfterM.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udAfterH
            // 
            this.udAfterH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.CustomFormat = "HH";
            this.udAfterH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterH.Location = new System.Drawing.Point(244, 173);
            this.udAfterH.Margin = new System.Windows.Forms.Padding(2);
            this.udAfterH.Name = "udAfterH";
            this.udAfterH.ShowUpDown = true;
            this.udAfterH.Size = new System.Drawing.Size(43, 26);
            this.udAfterH.TabIndex = 18;
            this.udAfterH.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udBeforeM
            // 
            this.udBeforeM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.CustomFormat = "mm";
            this.udBeforeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeM.Location = new System.Drawing.Point(181, 173);
            this.udBeforeM.Margin = new System.Windows.Forms.Padding(2);
            this.udBeforeM.Name = "udBeforeM";
            this.udBeforeM.ShowUpDown = true;
            this.udBeforeM.Size = new System.Drawing.Size(43, 26);
            this.udBeforeM.TabIndex = 17;
            this.udBeforeM.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
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
            this.chUse.ImageList = this.imglStatus;
            this.chUse.Location = new System.Drawing.Point(152, 2);
            this.chUse.Margin = new System.Windows.Forms.Padding(2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(214, 25);
            this.chUse.TabIndex = 19;
            this.chUse.Text = "Доступно для использования";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipMsg.SetToolTip(this.chUse, "Сотрудник активен");
            this.chUse.UseVisualStyleBackColor = true;
            this.chUse.CheckedChanged += new System.EventHandler(this.chUse_CheckedChanged);
            // 
            // udBeforeH
            // 
            this.udBeforeH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Checked = false;
            this.udBeforeH.CustomFormat = "HH";
            this.udBeforeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeH.Location = new System.Drawing.Point(120, 173);
            this.udBeforeH.Margin = new System.Windows.Forms.Padding(2);
            this.udBeforeH.Name = "udBeforeH";
            this.udBeforeH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udBeforeH.ShowUpDown = true;
            this.udBeforeH.Size = new System.Drawing.Size(43, 26);
            this.udBeforeH.TabIndex = 16;
            this.udBeforeH.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chbLunch);
            this.panel2.Controls.Add(this.cbSheme);
            this.panel2.Location = new System.Drawing.Point(7, 203);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 36);
            this.panel2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Тариф";
            // 
            // chbLunch
            // 
            this.chbLunch.AutoSize = true;
            this.chbLunch.Location = new System.Drawing.Point(206, 9);
            this.chbLunch.Margin = new System.Windows.Forms.Padding(2);
            this.chbLunch.Name = "chbLunch";
            this.chbLunch.Size = new System.Drawing.Size(144, 19);
            this.chbLunch.TabIndex = 14;
            this.chbLunch.Text = "Работает без обеда";
            this.chbLunch.UseVisualStyleBackColor = true;
            // 
            // cbSheme
            // 
            this.cbSheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheme.FormattingEnabled = true;
            this.cbSheme.Location = new System.Drawing.Point(104, 7);
            this.cbSheme.Margin = new System.Windows.Forms.Padding(2);
            this.cbSheme.Name = "cbSheme";
            this.cbSheme.Size = new System.Drawing.Size(98, 23);
            this.cbSheme.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbPost);
            this.panel1.Controls.Add(this.cbDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 65);
            this.panel1.TabIndex = 2;
            // 
            // cbPost
            // 
            this.cbPost.BackColor = System.Drawing.SystemColors.Control;
            this.cbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(104, 33);
            this.cbPost.Margin = new System.Windows.Forms.Padding(2);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(246, 23);
            this.cbPost.TabIndex = 6;
            this.cbPost.TextChanged += new System.EventHandler(this.cbPost_TextChanged);
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(104, 7);
            this.cbDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(246, 23);
            this.cbDepartment.TabIndex = 5;
            this.cbDepartment.TextChanged += new System.EventHandler(this.cbDepartment_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Департамент";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(290, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "График";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(227, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(165, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imageButton;
            this.btInsert.Location = new System.Drawing.Point(292, 261);
            this.btInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(105, 26);
            this.btInsert.TabIndex = 28;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            this.btInsert.MouseHover += new System.EventHandler(this.btInsert_MouseHover);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 357);
            this.Controls.Add(this.mainPanelUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUsers";
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.mainPanelUsers.ResumeLayout(false);
            this.prBts.ResumeLayout(false);
            this.prBts.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanelUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbLunch;
        private System.Windows.Forms.ComboBox cbSheme;
        private System.Windows.Forms.ListView lstwDataBaseUsers;
        private System.Windows.Forms.CheckBox chUse;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.DateTimePicker udBeforeH;
        private System.Windows.Forms.DateTimePicker udAfterM;
        private System.Windows.Forms.DateTimePicker udAfterH;
        private System.Windows.Forms.DateTimePicker udBeforeM;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.ColumnHeader access;
        private System.Windows.Forms.ColumnHeader fio;
        private System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.ImageList imglStatus;
        private System.Windows.Forms.ImageList imageButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.ToolTip toolTipMsg;
        private System.Windows.Forms.RadioButton rbUpdate;
        private System.Windows.Forms.RadioButton rbInsert;
        private System.Windows.Forms.Panel prBts;
        private System.Windows.Forms.Button btInsert;
    }
}