
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtDataBaseSQL = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtDataBasePACS = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtGuideUsers = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtGuideMarks = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtGuideCalendar = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtFormHeatCheck = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtFormTimeCheck = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtReportTotal = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageListStrip = new System.Windows.Forms.ImageList(this.components);
            this.mainPanelRegistration = new System.Windows.Forms.Panel();
            this.btInsert = new System.Windows.Forms.Button();
            this.imgListButtonMain = new System.Windows.Forms.ImageList(this.components);
            this.btImport = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.imgListStatusMain = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbCrmID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbExtID = new System.Windows.Forms.TextBox();
            this.udAfterM = new System.Windows.Forms.DateTimePicker();
            this.udAfterH = new System.Windows.Forms.DateTimePicker();
            this.udBeforeM = new System.Windows.Forms.DateTimePicker();
            this.udBeforeH = new System.Windows.Forms.DateTimePicker();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lMsg = new System.Windows.Forms.Label();
            this.toolTipMsgMain = new System.Windows.Forms.ToolTip(this.components);
            this.gbNavigator = new System.Windows.Forms.GroupBox();
            this.grRegistrator = new System.Windows.Forms.GroupBox();
            this.grUsers = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbSatusList = new System.Windows.Forms.TextBox();
            this.cbDirect = new System.Windows.Forms.ComboBox();
            this.lstwDataBaseMain = new System.Windows.Forms.ListView();
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.statusStripMain.SuspendLayout();
            this.mainPanelRegistration.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grRegistrator.SuspendLayout();
            this.grUsers.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsbtDataBaseSQL,
            this.tsbtDataBasePACS,
            this.toolStripStatusLabel1,
            this.tsbtGuideUsers,
            this.tsbtGuideMarks,
            this.tsbtGuideCalendar,
            this.toolStripStatusLabel3,
            this.tsbtFormHeatCheck,
            this.tsbtFormTimeCheck,
            this.toolStripStatusLabel4,
            this.tsbtReportTotal,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStripMain.Location = new System.Drawing.Point(0, 0);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStripMain.ShowItemToolTips = true;
            this.statusStripMain.Size = new System.Drawing.Size(1342, 26);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 15;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 20);
            this.toolStripStatusLabel2.Text = "Статус:";
            this.toolStripStatusLabel2.ToolTipText = "12431234";
            // 
            // tsbtDataBaseSQL
            // 
            this.tsbtDataBaseSQL.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.tsbtDataBaseSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDataBaseSQL.Name = "tsbtDataBaseSQL";
            this.tsbtDataBaseSQL.ShowDropDownArrow = false;
            this.tsbtDataBaseSQL.Size = new System.Drawing.Size(82, 24);
            this.tsbtDataBaseSQL.Text = "БД SQL";
            this.tsbtDataBaseSQL.ToolTipText = "Подключение к SQL базе учета рабочего времени";
            this.tsbtDataBaseSQL.Click += new System.EventHandler(this.tsbtDataBaseSQL_Click);
            // 
            // tsbtDataBasePACS
            // 
            this.tsbtDataBasePACS.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.tsbtDataBasePACS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDataBasePACS.Name = "tsbtDataBasePACS";
            this.tsbtDataBasePACS.ShowDropDownArrow = false;
            this.tsbtDataBasePACS.Size = new System.Drawing.Size(93, 24);
            this.tsbtDataBasePACS.Text = "БД СКУД";
            this.tsbtDataBasePACS.ToolTipText = "Подключение к web сервису СКУД";
            this.tsbtDataBasePACS.Click += new System.EventHandler(this.tsbtDataBasePACS_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(356, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "    Справочники:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsbtGuideUsers
            // 
            this.tsbtGuideUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtGuideUsers.Image = global::TimeWorkTracking.Properties.Resources.users;
            this.tsbtGuideUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtGuideUsers.Name = "tsbtGuideUsers";
            this.tsbtGuideUsers.ShowDropDownArrow = false;
            this.tsbtGuideUsers.Size = new System.Drawing.Size(24, 24);
            this.tsbtGuideUsers.Text = "Сотрудники";
            this.tsbtGuideUsers.Click += new System.EventHandler(this.TsbtGuideUsers_Click);
            // 
            // tsbtGuideMarks
            // 
            this.tsbtGuideMarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtGuideMarks.Image = global::TimeWorkTracking.Properties.Resources.report;
            this.tsbtGuideMarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtGuideMarks.Name = "tsbtGuideMarks";
            this.tsbtGuideMarks.ShowDropDownArrow = false;
            this.tsbtGuideMarks.Size = new System.Drawing.Size(24, 24);
            this.tsbtGuideMarks.Text = "Специальные отметки";
            this.tsbtGuideMarks.Click += new System.EventHandler(this.tsbtGuideMarks_Click);
            // 
            // tsbtGuideCalendar
            // 
            this.tsbtGuideCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtGuideCalendar.Image = global::TimeWorkTracking.Properties.Resources.calendar;
            this.tsbtGuideCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtGuideCalendar.Name = "tsbtGuideCalendar";
            this.tsbtGuideCalendar.ShowDropDownArrow = false;
            this.tsbtGuideCalendar.Size = new System.Drawing.Size(24, 24);
            this.tsbtGuideCalendar.Text = "Производственный календарь";
            this.tsbtGuideCalendar.Click += new System.EventHandler(this.tsbtGuideCalendar_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel3.Text = "    Печатные Формы:";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsbtFormHeatCheck
            // 
            this.tsbtFormHeatCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtFormHeatCheck.Image = global::TimeWorkTracking.Properties.Resources.heat;
            this.tsbtFormHeatCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtFormHeatCheck.Name = "tsbtFormHeatCheck";
            this.tsbtFormHeatCheck.ShowDropDownArrow = false;
            this.tsbtFormHeatCheck.Size = new System.Drawing.Size(24, 24);
            this.tsbtFormHeatCheck.Text = "Бланк Учета температуры";
            // 
            // tsbtFormTimeCheck
            // 
            this.tsbtFormTimeCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtFormTimeCheck.Image = global::TimeWorkTracking.Properties.Resources.form;
            this.tsbtFormTimeCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtFormTimeCheck.Name = "tsbtFormTimeCheck";
            this.tsbtFormTimeCheck.ShowDropDownArrow = false;
            this.tsbtFormTimeCheck.Size = new System.Drawing.Size(24, 24);
            this.tsbtFormTimeCheck.Text = "Бланк Учета рабочего времени";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(67, 20);
            this.toolStripStatusLabel4.Text = "    Отчет:";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsbtReportTotal
            // 
            this.tsbtReportTotal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtReportTotal.Image = global::TimeWorkTracking.Properties.Resources.pass;
            this.tsbtReportTotal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtReportTotal.Name = "tsbtReportTotal";
            this.tsbtReportTotal.ShowDropDownArrow = false;
            this.tsbtReportTotal.Size = new System.Drawing.Size(24, 24);
            this.tsbtReportTotal.Text = "Итоговый отчет";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel6.Text = " ";
            // 
            // imageListStrip
            // 
            this.imageListStrip.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStrip.ImageStream")));
            this.imageListStrip.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStrip.Images.SetKeyName(0, "no.png");
            this.imageListStrip.Images.SetKeyName(1, "ok.png");
            // 
            // mainPanelRegistration
            // 
            this.mainPanelRegistration.Controls.Add(this.grUsers);
            this.mainPanelRegistration.Controls.Add(this.grRegistrator);
            this.mainPanelRegistration.Controls.Add(this.gbNavigator);
            this.mainPanelRegistration.Controls.Add(this.btInsert);
            this.mainPanelRegistration.Controls.Add(this.btImport);
            this.mainPanelRegistration.Controls.Add(this.btUpdate);
            this.mainPanelRegistration.Controls.Add(this.panel3);
            this.mainPanelRegistration.Controls.Add(this.lMsg);
            this.mainPanelRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelRegistration.Location = new System.Drawing.Point(0, 26);
            this.mainPanelRegistration.Name = "mainPanelRegistration";
            this.mainPanelRegistration.Size = new System.Drawing.Size(1342, 612);
            this.mainPanelRegistration.TabIndex = 16;
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imgListButtonMain;
            this.btInsert.Location = new System.Drawing.Point(471, 553);
            this.btInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(140, 40);
            this.btInsert.TabIndex = 34;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            // 
            // imgListButtonMain
            // 
            this.imgListButtonMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonMain.ImageStream")));
            this.imgListButtonMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonMain.Images.SetKeyName(0, "db_48.png");
            this.imgListButtonMain.Images.SetKeyName(1, "db_add_48.png");
            this.imgListButtonMain.Images.SetKeyName(2, "db_edit_48.png");
            this.imgListButtonMain.Images.SetKeyName(3, "db_find_48.png");
            this.imgListButtonMain.Images.SetKeyName(4, "db_lock_48.png");
            this.imgListButtonMain.Images.SetKeyName(5, "db_unlock_48.png");
            this.imgListButtonMain.Images.SetKeyName(6, "db_upload_48.png");
            this.imgListButtonMain.Images.SetKeyName(7, "db_import_48.png");
            this.imgListButtonMain.Images.SetKeyName(8, "db_export_48.png");
            this.imgListButtonMain.Images.SetKeyName(9, "attention_48.png");
            this.imgListButtonMain.Images.SetKeyName(10, "info_48.png");
            // 
            // btImport
            // 
            this.btImport.ImageIndex = 7;
            this.btImport.Location = new System.Drawing.Point(646, 553);
            this.btImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(149, 40);
            this.btImport.TabIndex = 33;
            this.btImport.Text = "Импорт";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imgListButtonMain;
            this.btUpdate.Location = new System.Drawing.Point(823, 553);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(140, 40);
            this.btUpdate.TabIndex = 32;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // imgListStatusMain
            // 
            this.imgListStatusMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatusMain.ImageStream")));
            this.imgListStatusMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatusMain.Images.SetKeyName(0, "off5m.png");
            this.imgListStatusMain.Images.SetKeyName(1, "on5m.png");
            this.imgListStatusMain.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatusMain.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tbCrmID);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbExtID);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(1000, 161);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 181);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(9, 38);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(475, 1);
            this.panel4.TabIndex = 28;
            // 
            // tbCrmID
            // 
            this.tbCrmID.BackColor = System.Drawing.SystemColors.Control;
            this.tbCrmID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCrmID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCrmID.Location = new System.Drawing.Point(93, 11);
            this.tbCrmID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCrmID.MaxLength = 18;
            this.tbCrmID.Name = "tbCrmID";
            this.tbCrmID.Size = new System.Drawing.Size(171, 21);
            this.tbCrmID.TabIndex = 27;
            this.tbCrmID.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "id СКУД:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 24);
            this.label10.TabIndex = 26;
            this.label10.Text = "id CRM:";
            // 
            // tbExtID
            // 
            this.tbExtID.BackColor = System.Drawing.SystemColors.Control;
            this.tbExtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExtID.Enabled = false;
            this.tbExtID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbExtID.Location = new System.Drawing.Point(347, 11);
            this.tbExtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbExtID.Name = "tbExtID";
            this.tbExtID.Size = new System.Drawing.Size(139, 21);
            this.tbExtID.TabIndex = 22;
            // 
            // udAfterM
            // 
            this.udAfterM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.CustomFormat = "mm";
            this.udAfterM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterM.Location = new System.Drawing.Point(386, 57);
            this.udAfterM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udAfterM.Name = "udAfterM";
            this.udAfterM.ShowUpDown = true;
            this.udAfterM.Size = new System.Drawing.Size(79, 53);
            this.udAfterM.TabIndex = 19;
            this.udAfterM.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udAfterH
            // 
            this.udAfterH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.CustomFormat = "HH";
            this.udAfterH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterH.Location = new System.Drawing.Point(274, 57);
            this.udAfterH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udAfterH.Name = "udAfterH";
            this.udAfterH.ShowUpDown = true;
            this.udAfterH.Size = new System.Drawing.Size(79, 53);
            this.udAfterH.TabIndex = 18;
            this.udAfterH.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // udBeforeM
            // 
            this.udBeforeM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.CustomFormat = "mm";
            this.udBeforeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeM.Location = new System.Drawing.Point(139, 57);
            this.udBeforeM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udBeforeM.Name = "udBeforeM";
            this.udBeforeM.ShowUpDown = true;
            this.udBeforeM.Size = new System.Drawing.Size(79, 53);
            this.udBeforeM.TabIndex = 17;
            this.udBeforeM.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // udBeforeH
            // 
            this.udBeforeH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Checked = false;
            this.udBeforeH.CustomFormat = "HH";
            this.udBeforeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeH.Location = new System.Drawing.Point(28, 57);
            this.udBeforeH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udBeforeH.Name = "udBeforeH";
            this.udBeforeH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udBeforeH.ShowUpDown = true;
            this.udBeforeH.Size = new System.Drawing.Size(79, 53);
            this.udBeforeH.TabIndex = 16;
            this.udBeforeH.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chbLunch);
            this.panel2.Controls.Add(this.cbSheme);
            this.panel2.Location = new System.Drawing.Point(7, 127);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 44);
            this.panel2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Тариф";
            // 
            // chbLunch
            // 
            this.chbLunch.AutoSize = true;
            this.chbLunch.Location = new System.Drawing.Point(275, 11);
            this.chbLunch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbLunch.Name = "chbLunch";
            this.chbLunch.Size = new System.Drawing.Size(214, 28);
            this.chbLunch.TabIndex = 14;
            this.chbLunch.Text = "Работает без обеда";
            this.chbLunch.UseVisualStyleBackColor = true;
            // 
            // cbSheme
            // 
            this.cbSheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheme.FormattingEnabled = true;
            this.cbSheme.Location = new System.Drawing.Point(139, 7);
            this.cbSheme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSheme.Name = "cbSheme";
            this.cbSheme.Size = new System.Drawing.Size(129, 30);
            this.cbSheme.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbPost);
            this.panel1.Controls.Add(this.cbDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 80);
            this.panel1.TabIndex = 2;
            // 
            // cbPost
            // 
            this.cbPost.BackColor = System.Drawing.SystemColors.Control;
            this.cbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(139, 41);
            this.cbPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(327, 30);
            this.cbPost.TabIndex = 6;
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(139, 9);
            this.cbDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(327, 30);
            this.cbDepartment.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Департамент";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(355, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 46);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(231, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(107, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 46);
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
            this.lMsg.Location = new System.Drawing.Point(747, 562);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(200, 20);
            this.lMsg.TabIndex = 29;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbNavigator
            // 
            this.gbNavigator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbNavigator.Location = new System.Drawing.Point(471, 6);
            this.gbNavigator.Name = "gbNavigator";
            this.gbNavigator.Size = new System.Drawing.Size(492, 92);
            this.gbNavigator.TabIndex = 36;
            this.gbNavigator.TabStop = false;
            this.gbNavigator.Text = "Навигатор";
            // 
            // grRegistrator
            // 
            this.grRegistrator.Controls.Add(this.panel7);
            this.grRegistrator.Controls.Add(this.panel6);
            this.grRegistrator.Controls.Add(this.tbNote);
            this.grRegistrator.Controls.Add(this.tbName);
            this.grRegistrator.Controls.Add(this.udBeforeH);
            this.grRegistrator.Controls.Add(this.udBeforeM);
            this.grRegistrator.Controls.Add(this.udAfterM);
            this.grRegistrator.Controls.Add(this.udAfterH);
            this.grRegistrator.Controls.Add(this.label5);
            this.grRegistrator.Controls.Add(this.label6);
            this.grRegistrator.Controls.Add(this.label7);
            this.grRegistrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grRegistrator.Location = new System.Drawing.Point(471, 104);
            this.grRegistrator.Name = "grRegistrator";
            this.grRegistrator.Size = new System.Drawing.Size(492, 443);
            this.grRegistrator.TabIndex = 37;
            this.grRegistrator.TabStop = false;
            this.grRegistrator.Text = "Регистратор";
            // 
            // grUsers
            // 
            this.grUsers.Controls.Add(this.panel5);
            this.grUsers.Controls.Add(this.lstwDataBaseMain);
            this.grUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grUsers.Location = new System.Drawing.Point(3, 6);
            this.grUsers.Name = "grUsers";
            this.grUsers.Size = new System.Drawing.Size(460, 593);
            this.grUsers.TabIndex = 38;
            this.grUsers.TabStop = false;
            this.grUsers.Text = "Сотрудники";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tbSatusList);
            this.panel5.Controls.Add(this.cbDirect);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel5.Location = new System.Drawing.Point(6, 547);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(444, 39);
            this.panel5.TabIndex = 37;
            // 
            // tbSatusList
            // 
            this.tbSatusList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSatusList.BackColor = System.Drawing.SystemColors.Control;
            this.tbSatusList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSatusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSatusList.Location = new System.Drawing.Point(190, 8);
            this.tbSatusList.Name = "tbSatusList";
            this.tbSatusList.ReadOnly = true;
            this.tbSatusList.Size = new System.Drawing.Size(244, 21);
            this.tbSatusList.TabIndex = 1;
            this.tbSatusList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbDirect
            // 
            this.cbDirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDirect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDirect.FormattingEnabled = true;
            this.cbDirect.Items.AddRange(new object[] {
            "сверху вниз",
            "слева направо"});
            this.cbDirect.Location = new System.Drawing.Point(5, 3);
            this.cbDirect.Name = "cbDirect";
            this.cbDirect.Size = new System.Drawing.Size(166, 30);
            this.cbDirect.TabIndex = 0;
            // 
            // lstwDataBaseMain
            // 
            this.lstwDataBaseMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.access,
            this.fio});
            this.lstwDataBaseMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBaseMain.HideSelection = false;
            this.lstwDataBaseMain.LabelWrap = false;
            this.lstwDataBaseMain.Location = new System.Drawing.Point(6, 26);
            this.lstwDataBaseMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstwDataBaseMain.MultiSelect = false;
            this.lstwDataBaseMain.Name = "lstwDataBaseMain";
            this.lstwDataBaseMain.Size = new System.Drawing.Size(444, 515);
            this.lstwDataBaseMain.StateImageList = this.imgListStatusMain;
            this.lstwDataBaseMain.TabIndex = 36;
            this.lstwDataBaseMain.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseMain.View = System.Windows.Forms.View.SmallIcon;
            // 
            // access
            // 
            this.access.Text = "";
            this.access.Width = 29;
            // 
            // fio
            // 
            this.fio.Text = "Фамилия Имя Отчество";
            this.fio.Width = 231;
            // 
            // tbName
            // 
            this.tbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(10, 22);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(475, 28);
            this.tbName.TabIndex = 21;
            // 
            // tbNote
            // 
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNote.Location = new System.Drawing.Point(10, 360);
            this.tbNote.Margin = new System.Windows.Forms.Padding(4);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(475, 76);
            this.tbNote.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(10, 120);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(474, 75);
            this.panel6.TabIndex = 27;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dateTimePicker1);
            this.panel7.Location = new System.Drawing.Point(9, 201);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(474, 152);
            this.panel7.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 638);
            this.Controls.Add(this.mainPanelRegistration);
            this.Controls.Add(this.statusStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(898, 497);
            this.Name = "frmMain";
            this.Text = "Учет рабочего времени";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.mainPanelRegistration.ResumeLayout(false);
            this.mainPanelRegistration.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grRegistrator.ResumeLayout(false);
            this.grRegistrator.PerformLayout();
            this.grUsers.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripDropDownButton tsbtGuideUsers;
        private System.Windows.Forms.ToolStripDropDownButton tsbtGuideMarks;
        private System.Windows.Forms.ToolStripDropDownButton tsbtGuideCalendar;
        private System.Windows.Forms.ToolStripDropDownButton tsbtFormHeatCheck;
        private System.Windows.Forms.ToolStripDropDownButton tsbtFormTimeCheck;
        private System.Windows.Forms.ToolStripDropDownButton tsbtReportTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripDropDownButton tsbtDataBaseSQL;
        private System.Windows.Forms.ToolStripDropDownButton tsbtDataBasePACS;
        public System.Windows.Forms.ImageList imageListStrip;
        private System.Windows.Forms.Panel mainPanelRegistration;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbCrmID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbExtID;
        private System.Windows.Forms.DateTimePicker udAfterM;
        private System.Windows.Forms.DateTimePicker udAfterH;
        private System.Windows.Forms.DateTimePicker udBeforeM;
        private System.Windows.Forms.DateTimePicker udBeforeH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbLunch;
        private System.Windows.Forms.ComboBox cbSheme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lMsg;
        private System.Windows.Forms.ImageList imgListButtonMain;
        public System.Windows.Forms.ImageList imgListStatusMain;
        private System.Windows.Forms.ToolTip toolTipMsgMain;
        private System.Windows.Forms.GroupBox grRegistrator;
        private System.Windows.Forms.GroupBox gbNavigator;
        private System.Windows.Forms.GroupBox grUsers;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbSatusList;
        private System.Windows.Forms.ComboBox cbDirect;
        private System.Windows.Forms.ListView lstwDataBaseMain;
        private System.Windows.Forms.ColumnHeader access;
        private System.Windows.Forms.ColumnHeader fio;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

