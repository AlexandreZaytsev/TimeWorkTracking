
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.grUsers = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbSatusList = new System.Windows.Forms.TextBox();
            this.cbDirect = new System.Windows.Forms.ComboBox();
            this.lstwDataBaseMain = new System.Windows.Forms.ListView();
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListStatusMain = new System.Windows.Forms.ImageList(this.components);
            this.grRegistrator = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbSMarks = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.smTStop = new System.Windows.Forms.DateTimePicker();
            this.lbSmarkStop = new System.Windows.Forms.Label();
            this.smDStop = new System.Windows.Forms.DateTimePicker();
            this.smTStart = new System.Windows.Forms.DateTimePicker();
            this.lbSmarkStart = new System.Windows.Forms.Label();
            this.smDStart = new System.Windows.Forms.DateTimePicker();
            this.pPacs = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPacsOut = new System.Windows.Forms.TextBox();
            this.tbPacsIn = new System.Windows.Forms.TextBox();
            this.chPacsOut = new System.Windows.Forms.CheckBox();
            this.chPacsIn = new System.Windows.Forms.CheckBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.udBeforeH = new System.Windows.Forms.DateTimePicker();
            this.udBeforeM = new System.Windows.Forms.DateTimePicker();
            this.udAfterM = new System.Windows.Forms.DateTimePicker();
            this.udAfterH = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbNavigator = new System.Windows.Forms.GroupBox();
            this.mcRegDate = new System.Windows.Forms.MonthCalendar();
            this.btInsert = new System.Windows.Forms.Button();
            this.imgListButtonMain = new System.Windows.Forms.ImageList(this.components);
            this.btUpdate = new System.Windows.Forms.Button();
            this.lMsg = new System.Windows.Forms.Label();
            this.toolTipMsgMain = new System.Windows.Forms.ToolTip(this.components);
            this.webInfoDay = new System.Windows.Forms.WebBrowser();
            this.statusStripMain.SuspendLayout();
            this.mainPanelRegistration.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grUsers.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grRegistrator.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pPacs.SuspendLayout();
            this.gbNavigator.SuspendLayout();
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
            this.statusStripMain.Size = new System.Drawing.Size(974, 26);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(354, 20);
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
            this.mainPanelRegistration.Controls.Add(this.btUpdate);
            this.mainPanelRegistration.Controls.Add(this.lMsg);
            this.mainPanelRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelRegistration.Location = new System.Drawing.Point(0, 26);
            this.mainPanelRegistration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanelRegistration.Name = "mainPanelRegistration";
            this.mainPanelRegistration.Size = new System.Drawing.Size(974, 696);
            this.mainPanelRegistration.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.webInfoDay);
            this.panel3.Location = new System.Drawing.Point(243, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 200);
            this.panel3.TabIndex = 39;
            // 
            // grUsers
            // 
            this.grUsers.Controls.Add(this.panel5);
            this.grUsers.Controls.Add(this.lstwDataBaseMain);
            this.grUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grUsers.Location = new System.Drawing.Point(3, 6);
            this.grUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grUsers.Name = "grUsers";
            this.grUsers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grUsers.Size = new System.Drawing.Size(460, 670);
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
            this.panel5.Location = new System.Drawing.Point(5, 629);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(445, 39);
            this.panel5.TabIndex = 37;
            // 
            // tbSatusList
            // 
            this.tbSatusList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSatusList.BackColor = System.Drawing.SystemColors.Control;
            this.tbSatusList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSatusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSatusList.Location = new System.Drawing.Point(189, 7);
            this.tbSatusList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cbDirect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDirect.FormattingEnabled = true;
            this.cbDirect.Items.AddRange(new object[] {
            "сверху вниз",
            "слева направо"});
            this.cbDirect.Location = new System.Drawing.Point(5, 2);
            this.cbDirect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDirect.Name = "cbDirect";
            this.cbDirect.Size = new System.Drawing.Size(167, 32);
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
            this.lstwDataBaseMain.Location = new System.Drawing.Point(5, 26);
            this.lstwDataBaseMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstwDataBaseMain.MultiSelect = false;
            this.lstwDataBaseMain.Name = "lstwDataBaseMain";
            this.lstwDataBaseMain.Size = new System.Drawing.Size(444, 598);
            this.lstwDataBaseMain.StateImageList = this.imgListStatusMain;
            this.lstwDataBaseMain.TabIndex = 36;
            this.lstwDataBaseMain.UseCompatibleStateImageBehavior = false;
            this.lstwDataBaseMain.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBaseMain.SelectedIndexChanged += new System.EventHandler(this.lstwDataBaseMain_SelectedIndexChanged);
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
            // imgListStatusMain
            // 
            this.imgListStatusMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListStatusMain.ImageStream")));
            this.imgListStatusMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListStatusMain.Images.SetKeyName(0, "off5m.png");
            this.imgListStatusMain.Images.SetKeyName(1, "on5m.png");
            this.imgListStatusMain.Images.SetKeyName(2, "db_add_48x72.png");
            this.imgListStatusMain.Images.SetKeyName(3, "db_edit_48x72.png");
            // 
            // grRegistrator
            // 
            this.grRegistrator.Controls.Add(this.panel7);
            this.grRegistrator.Controls.Add(this.pPacs);
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
            this.grRegistrator.Location = new System.Drawing.Point(471, 240);
            this.grRegistrator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grRegistrator.Name = "grRegistrator";
            this.grRegistrator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grRegistrator.Size = new System.Drawing.Size(492, 387);
            this.grRegistrator.TabIndex = 37;
            this.grRegistrator.TabStop = false;
            this.grRegistrator.Text = "Регистратор";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cbSMarks);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.smTStop);
            this.panel7.Controls.Add(this.lbSmarkStop);
            this.panel7.Controls.Add(this.smDStop);
            this.panel7.Controls.Add(this.smTStart);
            this.panel7.Controls.Add(this.lbSmarkStart);
            this.panel7.Controls.Add(this.smDStart);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel7.Location = new System.Drawing.Point(9, 174);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(474, 120);
            this.panel7.TabIndex = 28;
            // 
            // cbSMarks
            // 
            this.cbSMarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSMarks.FormattingEnabled = true;
            this.cbSMarks.Location = new System.Drawing.Point(205, 6);
            this.cbSMarks.Margin = new System.Windows.Forms.Padding(4);
            this.cbSMarks.Name = "cbSMarks";
            this.cbSMarks.Size = new System.Drawing.Size(261, 32);
            this.cbSMarks.TabIndex = 19;
            this.cbSMarks.SelectedIndexChanged += new System.EventHandler(this.cbSMarks_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(5, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Специальные отметки";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smTStop
            // 
            this.smTStop.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smTStop.CustomFormat = "HH:mm";
            this.smTStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smTStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.smTStop.Location = new System.Drawing.Point(380, 80);
            this.smTStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.smTStop.Name = "smTStop";
            this.smTStop.ShowUpDown = true;
            this.smTStop.Size = new System.Drawing.Size(87, 30);
            this.smTStop.TabIndex = 17;
            this.smTStop.ValueChanged += new System.EventHandler(this.checkDateSpecialMarks);
            // 
            // lbSmarkStop
            // 
            this.lbSmarkStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSmarkStop.Location = new System.Drawing.Point(5, 85);
            this.lbSmarkStop.Name = "lbSmarkStop";
            this.lbSmarkStop.Size = new System.Drawing.Size(193, 22);
            this.lbSmarkStop.TabIndex = 16;
            this.lbSmarkStop.Text = "Окончание периода";
            this.lbSmarkStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smDStop
            // 
            this.smDStop.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smDStop.CustomFormat = "dd.MM.yyyy";
            this.smDStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smDStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.smDStop.Location = new System.Drawing.Point(205, 80);
            this.smDStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.smDStop.Name = "smDStop";
            this.smDStop.Size = new System.Drawing.Size(164, 30);
            this.smDStop.TabIndex = 15;
            this.smDStop.ValueChanged += new System.EventHandler(this.checkDateSpecialMarks);
            // 
            // smTStart
            // 
            this.smTStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smTStart.CustomFormat = "HH:mm";
            this.smTStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smTStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.smTStart.Location = new System.Drawing.Point(380, 43);
            this.smTStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.smTStart.Name = "smTStart";
            this.smTStart.ShowUpDown = true;
            this.smTStart.Size = new System.Drawing.Size(87, 30);
            this.smTStart.TabIndex = 14;
            this.smTStart.ValueChanged += new System.EventHandler(this.checkDateSpecialMarks);
            // 
            // lbSmarkStart
            // 
            this.lbSmarkStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSmarkStart.Location = new System.Drawing.Point(5, 48);
            this.lbSmarkStart.Name = "lbSmarkStart";
            this.lbSmarkStart.Size = new System.Drawing.Size(193, 22);
            this.lbSmarkStart.TabIndex = 13;
            this.lbSmarkStart.Text = "Начало периода";
            this.lbSmarkStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smDStart
            // 
            this.smDStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smDStart.CustomFormat = "dd.MM.yyyy";
            this.smDStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smDStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.smDStart.Location = new System.Drawing.Point(205, 43);
            this.smDStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.smDStart.Name = "smDStart";
            this.smDStart.Size = new System.Drawing.Size(164, 30);
            this.smDStart.TabIndex = 0;
            this.smDStart.ValueChanged += new System.EventHandler(this.checkDateSpecialMarks);
            // 
            // pPacs
            // 
            this.pPacs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPacs.Controls.Add(this.panel1);
            this.pPacs.Controls.Add(this.tbPacsOut);
            this.pPacs.Controls.Add(this.tbPacsIn);
            this.pPacs.Controls.Add(this.chPacsOut);
            this.pPacs.Controls.Add(this.chPacsIn);
            this.pPacs.Enabled = false;
            this.pPacs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pPacs.Location = new System.Drawing.Point(11, 120);
            this.pPacs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pPacs.Name = "pPacs";
            this.pPacs.Size = new System.Drawing.Size(474, 46);
            this.pPacs.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(235, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 25);
            this.panel1.TabIndex = 4;
            // 
            // tbPacsOut
            // 
            this.tbPacsOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPacsOut.Location = new System.Drawing.Point(263, 4);
            this.tbPacsOut.Margin = new System.Windows.Forms.Padding(4);
            this.tbPacsOut.Name = "tbPacsOut";
            this.tbPacsOut.Size = new System.Drawing.Size(79, 34);
            this.tbPacsOut.TabIndex = 3;
            this.tbPacsOut.Text = "00:00";
            this.tbPacsOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPacsIn
            // 
            this.tbPacsIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPacsIn.Location = new System.Drawing.Point(127, 4);
            this.tbPacsIn.Margin = new System.Windows.Forms.Padding(4);
            this.tbPacsIn.Name = "tbPacsIn";
            this.tbPacsIn.Size = new System.Drawing.Size(79, 34);
            this.tbPacsIn.TabIndex = 2;
            this.tbPacsIn.Text = "00:00";
            this.tbPacsIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chPacsOut
            // 
            this.chPacsOut.AutoSize = true;
            this.chPacsOut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chPacsOut.Location = new System.Drawing.Point(375, 10);
            this.chPacsOut.Margin = new System.Windows.Forms.Padding(4);
            this.chPacsOut.Name = "chPacsOut";
            this.chPacsOut.Size = new System.Drawing.Size(76, 28);
            this.chPacsOut.TabIndex = 1;
            this.chPacsOut.Text = "вход";
            this.chPacsOut.UseVisualStyleBackColor = true;
            // 
            // chPacsIn
            // 
            this.chPacsIn.AutoSize = true;
            this.chPacsIn.Location = new System.Drawing.Point(16, 10);
            this.chPacsIn.Margin = new System.Windows.Forms.Padding(4);
            this.chPacsIn.Name = "chPacsIn";
            this.chPacsIn.Size = new System.Drawing.Size(76, 28);
            this.chPacsIn.TabIndex = 0;
            this.chPacsIn.Text = "вход";
            this.chPacsIn.UseVisualStyleBackColor = true;
            // 
            // tbNote
            // 
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNote.Location = new System.Drawing.Point(9, 301);
            this.tbNote.Margin = new System.Windows.Forms.Padding(4);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(476, 75);
            this.tbNote.TabIndex = 26;
            // 
            // tbName
            // 
            this.tbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbName.BackColor = System.Drawing.SystemColors.Control;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(11, 22);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(475, 30);
            this.tbName.TabIndex = 21;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // udBeforeH
            // 
            this.udBeforeH.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Checked = false;
            this.udBeforeH.CustomFormat = "HH";
            this.udBeforeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeH.Location = new System.Drawing.Point(28, 59);
            this.udBeforeH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udBeforeH.Name = "udBeforeH";
            this.udBeforeH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udBeforeH.ShowUpDown = true;
            this.udBeforeH.Size = new System.Drawing.Size(79, 53);
            this.udBeforeH.TabIndex = 16;
            this.udBeforeH.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // udBeforeM
            // 
            this.udBeforeM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.CustomFormat = "mm";
            this.udBeforeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udBeforeM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udBeforeM.Location = new System.Drawing.Point(139, 59);
            this.udBeforeM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udBeforeM.Name = "udBeforeM";
            this.udBeforeM.ShowUpDown = true;
            this.udBeforeM.Size = new System.Drawing.Size(79, 53);
            this.udBeforeM.TabIndex = 17;
            this.udBeforeM.Value = new System.DateTime(2021, 10, 21, 9, 0, 0, 0);
            // 
            // udAfterM
            // 
            this.udAfterM.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.CustomFormat = "mm";
            this.udAfterM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.udAfterM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.udAfterM.Location = new System.Drawing.Point(387, 59);
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
            this.udAfterH.Location = new System.Drawing.Point(275, 59);
            this.udAfterH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udAfterH.Name = "udAfterH";
            this.udAfterH.ShowUpDown = true;
            this.udAfterH.Size = new System.Drawing.Size(79, 53);
            this.udAfterH.TabIndex = 18;
            this.udAfterH.Value = new System.DateTime(2021, 10, 21, 18, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(107, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 46);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(231, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(355, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 46);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // gbNavigator
            // 
            this.gbNavigator.Controls.Add(this.panel3);
            this.gbNavigator.Controls.Add(this.mcRegDate);
            this.gbNavigator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbNavigator.Location = new System.Drawing.Point(471, 6);
            this.gbNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNavigator.Name = "gbNavigator";
            this.gbNavigator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNavigator.Size = new System.Drawing.Size(492, 233);
            this.gbNavigator.TabIndex = 36;
            this.gbNavigator.TabStop = false;
            this.gbNavigator.Text = "Производственный каледнарь";
            // 
            // mcRegDate
            // 
            this.mcRegDate.BackColor = System.Drawing.SystemColors.Window;
            this.mcRegDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mcRegDate.Location = new System.Drawing.Point(7, 26);
            this.mcRegDate.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.mcRegDate.Name = "mcRegDate";
            this.mcRegDate.ShowWeekNumbers = true;
            this.mcRegDate.TabIndex = 2;
            this.mcRegDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcRegDate_DateChanged);
            this.mcRegDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcRegDate_DateSelected);
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.ImageIndex = 1;
            this.btInsert.ImageList = this.imgListButtonMain;
            this.btInsert.Location = new System.Drawing.Point(471, 635);
            this.btInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(140, 39);
            this.btInsert.TabIndex = 34;
            this.btInsert.Text = "Добавить";
            this.btInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
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
            this.imgListButtonMain.Images.SetKeyName(11, "holiday_48.png");
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.ImageIndex = 2;
            this.btUpdate.ImageList = this.imgListButtonMain;
            this.btUpdate.Location = new System.Drawing.Point(823, 635);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(140, 39);
            this.btUpdate.TabIndex = 32;
            this.btUpdate.Text = "Обновить";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // lMsg
            // 
            this.lMsg.AutoSize = true;
            this.lMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lMsg.ImageIndex = 6;
            this.lMsg.Location = new System.Drawing.Point(747, 645);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(200, 20);
            this.lMsg.TabIndex = 29;
            this.lMsg.Text = "      Новая запись в БД";
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // webInfoDay
            // 
            this.webInfoDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webInfoDay.Location = new System.Drawing.Point(0, 0);
            this.webInfoDay.Margin = new System.Windows.Forms.Padding(0);
            this.webInfoDay.MinimumSize = new System.Drawing.Size(20, 20);
            this.webInfoDay.Name = "webInfoDay";
            this.webInfoDay.ScrollBarsEnabled = false;
            this.webInfoDay.Size = new System.Drawing.Size(241, 198);
            this.webInfoDay.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(974, 722);
            this.Controls.Add(this.mainPanelRegistration);
            this.Controls.Add(this.statusStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(898, 493);
            this.Name = "frmMain";
            this.Text = "Учет рабочего времени";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.mainPanelRegistration.ResumeLayout(false);
            this.mainPanelRegistration.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.grUsers.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.grRegistrator.ResumeLayout(false);
            this.grRegistrator.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.pPacs.ResumeLayout(false);
            this.pPacs.PerformLayout();
            this.gbNavigator.ResumeLayout(false);
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
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DateTimePicker udAfterM;
        private System.Windows.Forms.DateTimePicker udAfterH;
        private System.Windows.Forms.DateTimePicker udBeforeM;
        private System.Windows.Forms.DateTimePicker udBeforeH;
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
        private System.Windows.Forms.Panel pPacs;
        private System.Windows.Forms.DateTimePicker smDStart;
        private System.Windows.Forms.Label lbSmarkStart;
        private System.Windows.Forms.DateTimePicker smTStart;
        private System.Windows.Forms.ComboBox cbSMarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker smTStop;
        private System.Windows.Forms.Label lbSmarkStop;
        private System.Windows.Forms.DateTimePicker smDStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPacsOut;
        private System.Windows.Forms.TextBox tbPacsIn;
        private System.Windows.Forms.CheckBox chPacsOut;
        private System.Windows.Forms.CheckBox chPacsIn;
        private System.Windows.Forms.MonthCalendar mcRegDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser webInfoDay;
    }
}

