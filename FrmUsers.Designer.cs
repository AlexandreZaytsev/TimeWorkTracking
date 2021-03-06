
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
            this.btInsert = new System.Windows.Forms.Button();
            this.imgListButtonUsers = new System.Windows.Forms.ImageList(this.components);
            this.btUpdate = new System.Windows.Forms.Button();
            this.lstwDataBaseUsers = new System.Windows.Forms.ListView();
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListStatusUsers = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.udAfterM = new System.Windows.Forms.DateTimePicker();
            this.udAfterH = new System.Windows.Forms.DateTimePicker();
            this.udBeforeM = new System.Windows.Forms.DateTimePicker();
            this.udBeforeH = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbCrmID = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbExtID = new System.Windows.Forms.TextBox();
            this.chUse = new System.Windows.Forms.CheckBox();
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
            this.lMsg = new System.Windows.Forms.Label();
            this.toolTipMsgUsers = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanelUsers.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelUsers
            // 
            this.mainPanelUsers.Controls.Add(this.btInsert);
            this.mainPanelUsers.Controls.Add(this.btUpdate);
            this.mainPanelUsers.Controls.Add(this.lstwDataBaseUsers);
            this.mainPanelUsers.Controls.Add(this.panel3);
            this.mainPanelUsers.Controls.Add(this.lMsg);
            this.mainPanelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelUsers.Location = new System.Drawing.Point(0, 0);
            this.mainPanelUsers.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelUsers.Name = "mainPanelUsers";
            this.mainPanelUsers.Size = new System.Drawing.Size(669, 314);
            this.mainPanelUsers.TabIndex = 0;
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imgListButtonUsers;
            this.btInsert.Location = new System.Drawing.Point(292, 281);
            this.btInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(105, 26);
            this.btInsert.TabIndex = 28;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            this.btInsert.MouseLeave += new System.EventHandler(this.btInsert_MouseLeave);
            this.btInsert.MouseHover += new System.EventHandler(this.btInsert_MouseHover);
            // 
            // imgListButtonUsers
            // 
            this.imgListButtonUsers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonUsers.ImageStream")));
            this.imgListButtonUsers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonUsers.Images.SetKeyName(0, "db_48.png");
            this.imgListButtonUsers.Images.SetKeyName(1, "db_add_48.png");
            this.imgListButtonUsers.Images.SetKeyName(2, "db_edit_48.png");
            this.imgListButtonUsers.Images.SetKeyName(3, "db_find_48.png");
            this.imgListButtonUsers.Images.SetKeyName(4, "db_lock_48.png");
            this.imgListButtonUsers.Images.SetKeyName(5, "db_unlock_48.png");
            this.imgListButtonUsers.Images.SetKeyName(6, "db_upload_48.png");
            this.imgListButtonUsers.Images.SetKeyName(7, "db_import_48.png");
            this.imgListButtonUsers.Images.SetKeyName(8, "db_export_48.png");
            this.imgListButtonUsers.Images.SetKeyName(9, "attention_48.png");
            this.imgListButtonUsers.Images.SetKeyName(10, "info_48.png");
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imgListButtonUsers;
            this.btUpdate.Location = new System.Drawing.Point(556, 281);
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
            this.lstwDataBaseUsers.Size = new System.Drawing.Size(281, 296);
            this.lstwDataBaseUsers.StateImageList = this.imgListStatusUsers;
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
            this.fio.Width = 231;
            // 
            // imgListStatusUsers
            // 
            this.imgListStatusUsers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatusUsers.ImageStream")));
            this.imgListStatusUsers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatusUsers.Images.SetKeyName(0, "off5m.png");
            this.imgListStatusUsers.Images.SetKeyName(1, "on5m.png");
            this.imgListStatusUsers.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatusUsers.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.udAfterM);
            this.panel3.Controls.Add(this.udAfterH);
            this.panel3.Controls.Add(this.udBeforeM);
            this.panel3.Controls.Add(this.udBeforeH);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tbCrmID);
            this.panel3.Controls.Add(this.tbNote);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.tbExtID);
            this.panel3.Controls.Add(this.chUse);
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
            this.panel3.Size = new System.Drawing.Size(370, 266);
            this.panel3.TabIndex = 16;
            // 
            // udAfterM
            // 
            this.udAfterM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.CustomFormat = "mm";
            this.udAfterM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterM.Location = new System.Drawing.Point(306, 189);
            this.udAfterM.Margin = new System.Windows.Forms.Padding(2);
            this.udAfterM.Name = "udAfterM";
            this.udAfterM.ShowUpDown = true;
            this.udAfterM.Size = new System.Drawing.Size(43, 29);
            this.udAfterM.TabIndex = 19;
            this.udAfterM.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udAfterH
            // 
            this.udAfterH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.CustomFormat = "HH";
            this.udAfterH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterH.Location = new System.Drawing.Point(244, 189);
            this.udAfterH.Margin = new System.Windows.Forms.Padding(2);
            this.udAfterH.Name = "udAfterH";
            this.udAfterH.ShowUpDown = true;
            this.udAfterH.Size = new System.Drawing.Size(43, 29);
            this.udAfterH.TabIndex = 18;
            this.udAfterH.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udBeforeM
            // 
            this.udBeforeM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.CustomFormat = "mm";
            this.udBeforeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeM.Location = new System.Drawing.Point(181, 189);
            this.udBeforeM.Margin = new System.Windows.Forms.Padding(2);
            this.udBeforeM.Name = "udBeforeM";
            this.udBeforeM.ShowUpDown = true;
            this.udBeforeM.Size = new System.Drawing.Size(43, 29);
            this.udBeforeM.TabIndex = 17;
            this.udBeforeM.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // udBeforeH
            // 
            this.udBeforeH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Checked = false;
            this.udBeforeH.CustomFormat = "HH";
            this.udBeforeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeH.Location = new System.Drawing.Point(120, 189);
            this.udBeforeH.Margin = new System.Windows.Forms.Padding(2);
            this.udBeforeH.Name = "udBeforeH";
            this.udBeforeH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udBeforeH.ShowUpDown = true;
            this.udBeforeH.Size = new System.Drawing.Size(43, 29);
            this.udBeforeH.TabIndex = 16;
            this.udBeforeH.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(7, 31);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(357, 1);
            this.panel4.TabIndex = 28;
            // 
            // tbCrmID
            // 
            this.tbCrmID.BackColor = System.Drawing.SystemColors.Control;
            this.tbCrmID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCrmID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCrmID.Location = new System.Drawing.Point(70, 9);
            this.tbCrmID.Margin = new System.Windows.Forms.Padding(2);
            this.tbCrmID.MaxLength = 18;
            this.tbCrmID.Name = "tbCrmID";
            this.tbCrmID.Size = new System.Drawing.Size(128, 14);
            this.tbCrmID.TabIndex = 27;
            this.tbCrmID.Text = "0";
            this.tbCrmID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCrmID_KeyPress);
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(7, 67);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(357, 44);
            this.tbNote.TabIndex = 25;
            this.toolTipMsgUsers.SetToolTip(this.tbNote, "Комментарий");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "id СКУД:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "id CRM:";
            // 
            // tbName
            // 
            this.tbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.Location = new System.Drawing.Point(50, 40);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(236, 21);
            this.tbName.TabIndex = 20;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbExtID
            // 
            this.tbExtID.BackColor = System.Drawing.SystemColors.Control;
            this.tbExtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExtID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbExtID.Location = new System.Drawing.Point(260, 9);
            this.tbExtID.Margin = new System.Windows.Forms.Padding(2);
            this.tbExtID.Name = "tbExtID";
            this.tbExtID.ReadOnly = true;
            this.tbExtID.Size = new System.Drawing.Size(104, 14);
            this.tbExtID.TabIndex = 22;
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
            this.chUse.ImageList = this.imgListStatusUsers;
            this.chUse.Location = new System.Drawing.Point(285, 37);
            this.chUse.Margin = new System.Windows.Forms.Padding(2);
            this.chUse.Name = "chUse";
            this.chUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chUse.Size = new System.Drawing.Size(84, 25);
            this.chUse.TabIndex = 19;
            this.chUse.Text = "Доступ";
            this.chUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipMsgUsers.SetToolTip(this.chUse, "Сотрудник активен");
            this.chUse.UseVisualStyleBackColor = true;
            this.chUse.CheckedChanged += new System.EventHandler(this.chUse_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 43);
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
            this.panel2.Location = new System.Drawing.Point(7, 222);
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
            this.cbSheme.Location = new System.Drawing.Point(104, 6);
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
            this.panel1.Location = new System.Drawing.Point(7, 118);
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
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Департамент";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(288, 191);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "График работы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(227, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(163, 191);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // lMsg
            // 
            this.lMsg.AutoSize = true;
            this.lMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lMsg.ImageIndex = 6;
            this.lMsg.ImageList = this.imgListButtonUsers;
            this.lMsg.Location = new System.Drawing.Point(499, 285);
            this.lMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(157, 17);
            this.lMsg.TabIndex = 0;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 314);
            this.Controls.Add(this.mainPanelUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUsers";
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.mainPanelUsers.ResumeLayout(false);
            this.mainPanelUsers.PerformLayout();
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
        private System.Windows.Forms.TextBox tbExtID;
        private System.Windows.Forms.DateTimePicker udBeforeH;
        private System.Windows.Forms.DateTimePicker udAfterM;
        private System.Windows.Forms.DateTimePicker udAfterH;
        private System.Windows.Forms.DateTimePicker udBeforeM;
        private System.Windows.Forms.ColumnHeader access;
        private System.Windows.Forms.ColumnHeader fio;
        private System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.ImageList imgListStatusUsers;
        private System.Windows.Forms.ImageList imgListButtonUsers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.ToolTip toolTipMsgUsers;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.TextBox tbCrmID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lMsg;
    }
}