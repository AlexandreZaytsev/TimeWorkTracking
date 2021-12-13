
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
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nMinutesLunchBreakTime = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nMinutesChangingFullWorkDay = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nHoursInFullWorkDay = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nDaysInWorkWeek = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btMainExport = new System.Windows.Forms.Button();
            this.imgListButtonSetting = new System.Windows.Forms.ImageList(this.components);
            this.btMainExportPathSave = new System.Windows.Forms.Button();
            this.tbMainExportPath = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chAllData = new System.Windows.Forms.CheckBox();
            this.chDeleteOnly = new System.Windows.Forms.CheckBox();
            this.cbSheetTable = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btMainImport = new System.Windows.Forms.Button();
            this.btMainImportPathOpen = new System.Windows.Forms.Button();
            this.tbMainImportPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label11 = new System.Windows.Forms.Label();
            this.btImportUsers = new System.Windows.Forms.Button();
            this.btFileNameOpen = new System.Windows.Forms.Button();
            this.tbPathImport = new System.Windows.Forms.TextBox();
            this.statusStripSetting = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarImport = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTipMsgSetting = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorkerSetting = new System.ComponentModel.BackgroundWorker();
            this.openFileDialogSetting = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSetting = new System.Windows.Forms.SaveFileDialog();
            this.timerImportExport = new System.Windows.Forms.Timer(this.components);
            this.mainPanelSetting.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesLunchBreakTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesChangingFullWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHoursInFullWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDaysInWorkWeek)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStripSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelSetting
            // 
            this.mainPanelSetting.Controls.Add(this.tabSetting);
            this.mainPanelSetting.Controls.Add(this.statusStripSetting);
            this.mainPanelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelSetting.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSetting.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelSetting.Name = "mainPanelSetting";
            this.mainPanelSetting.Size = new System.Drawing.Size(530, 176);
            this.mainPanelSetting.TabIndex = 16;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.tabPage1);
            this.tabSetting.Controls.Add(this.tabPage3);
            this.tabSetting.Controls.Add(this.tabPage2);
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetting.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(2);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(530, 152);
            this.tabSetting.TabIndex = 32;
            this.tabSetting.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabSetting_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(522, 124);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.tbCompanyName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(518, 120);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Общие настройки";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nMinutesLunchBreakTime);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.nMinutesChangingFullWorkDay);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.nHoursInFullWorkDay);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.nDaysInWorkWeek);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(7, 45);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(506, 53);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройки рабочего времени (дни часы минуты)";
            // 
            // nMinutesLunchBreakTime
            // 
            this.nMinutesLunchBreakTime.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nMinutesLunchBreakTime.Location = new System.Drawing.Point(459, 22);
            this.nMinutesLunchBreakTime.Margin = new System.Windows.Forms.Padding(2);
            this.nMinutesLunchBreakTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nMinutesLunchBreakTime.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nMinutesLunchBreakTime.Name = "nMinutesLunchBreakTime";
            this.nMinutesLunchBreakTime.Size = new System.Drawing.Size(38, 21);
            this.nMinutesLunchBreakTime.TabIndex = 5;
            this.toolTipMsgSetting.SetToolTip(this.nMinutesLunchBreakTime, "Количество минут на обед");
            this.nMinutesLunchBreakTime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(389, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = "Обед (мин)";
            // 
            // nMinutesChangingFullWorkDay
            // 
            this.nMinutesChangingFullWorkDay.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nMinutesChangingFullWorkDay.Location = new System.Drawing.Point(343, 23);
            this.nMinutesChangingFullWorkDay.Margin = new System.Windows.Forms.Padding(2);
            this.nMinutesChangingFullWorkDay.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nMinutesChangingFullWorkDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nMinutesChangingFullWorkDay.Name = "nMinutesChangingFullWorkDay";
            this.nMinutesChangingFullWorkDay.Size = new System.Drawing.Size(42, 21);
            this.nMinutesChangingFullWorkDay.TabIndex = 4;
            this.toolTipMsgSetting.SetToolTip(this.nMinutesChangingFullWorkDay, "Количество минут сокращения и(или) увеличения полного рабочего дня");
            this.nMinutesChangingFullWorkDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 41;
            this.label10.Text = "+/- (мин)";
            // 
            // nHoursInFullWorkDay
            // 
            this.nHoursInFullWorkDay.Location = new System.Drawing.Point(249, 22);
            this.nHoursInFullWorkDay.Margin = new System.Windows.Forms.Padding(2);
            this.nHoursInFullWorkDay.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nHoursInFullWorkDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nHoursInFullWorkDay.Name = "nHoursInFullWorkDay";
            this.nHoursInFullWorkDay.Size = new System.Drawing.Size(30, 21);
            this.nHoursInFullWorkDay.TabIndex = 3;
            this.toolTipMsgSetting.SetToolTip(this.nHoursInFullWorkDay, "Количество часов в полном рабочем дне");
            this.nHoursInFullWorkDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = "Полный день (час)";
            // 
            // nDaysInWorkWeek
            // 
            this.nDaysInWorkWeek.Location = new System.Drawing.Point(96, 22);
            this.nDaysInWorkWeek.Margin = new System.Windows.Forms.Padding(2);
            this.nDaysInWorkWeek.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nDaysInWorkWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nDaysInWorkWeek.Name = "nDaysInWorkWeek";
            this.nDaysInWorkWeek.Size = new System.Drawing.Size(31, 21);
            this.nDaysInWorkWeek.TabIndex = 2;
            this.toolTipMsgSetting.SetToolTip(this.nDaysInWorkWeek, "Количество дней в рабочей неделе");
            this.nDaysInWorkWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Дней в неделе";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(103, 20);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(409, 21);
            this.tbCompanyName.TabIndex = 1;
            this.toolTipMsgSetting.SetToolTip(this.tbCompanyName, "используется в отчетвх");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Имя компании";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(522, 124);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Экспорт Импорт";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btMainExport);
            this.groupBox6.Controls.Add(this.btMainExportPathSave);
            this.groupBox6.Controls.Add(this.tbMainExportPath);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 76);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(522, 48);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Экспорт данных";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "Файл";
            // 
            // btMainExport
            // 
            this.btMainExport.ImageIndex = 7;
            this.btMainExport.ImageList = this.imgListButtonSetting;
            this.btMainExport.Location = new System.Drawing.Point(427, 16);
            this.btMainExport.Margin = new System.Windows.Forms.Padding(2);
            this.btMainExport.Name = "btMainExport";
            this.btMainExport.Size = new System.Drawing.Size(93, 26);
            this.btMainExport.TabIndex = 10;
            this.btMainExport.Text = "Экспорт";
            this.btMainExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMainExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMainExport.UseVisualStyleBackColor = true;
            this.btMainExport.Click += new System.EventHandler(this.btMainExport_Click);
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
            // btMainExportPathSave
            // 
            this.btMainExportPathSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMainExportPathSave.Location = new System.Drawing.Point(389, 18);
            this.btMainExportPathSave.Name = "btMainExportPathSave";
            this.btMainExportPathSave.Size = new System.Drawing.Size(29, 23);
            this.btMainExportPathSave.TabIndex = 7;
            this.btMainExportPathSave.Text = "...";
            this.btMainExportPathSave.UseVisualStyleBackColor = true;
            this.btMainExportPathSave.Click += new System.EventHandler(this.btMainExportPathSave_Click);
            // 
            // tbMainExportPath
            // 
            this.tbMainExportPath.Location = new System.Drawing.Point(63, 19);
            this.tbMainExportPath.Name = "tbMainExportPath";
            this.tbMainExportPath.ReadOnly = true;
            this.tbMainExportPath.Size = new System.Drawing.Size(321, 21);
            this.tbMainExportPath.TabIndex = 6;
            this.toolTipMsgSetting.SetToolTip(this.tbMainExportPath, "путь к файлу данных для экспорта");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chAllData);
            this.groupBox5.Controls.Add(this.chDeleteOnly);
            this.groupBox5.Controls.Add(this.cbSheetTable);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.btMainImport);
            this.groupBox5.Controls.Add(this.btMainImportPathOpen);
            this.groupBox5.Controls.Add(this.tbMainImportPath);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(522, 74);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Импорт данных";
            // 
            // chAllData
            // 
            this.chAllData.AutoSize = true;
            this.chAllData.Location = new System.Drawing.Point(15, 46);
            this.chAllData.Margin = new System.Windows.Forms.Padding(2);
            this.chAllData.Name = "chAllData";
            this.chAllData.Size = new System.Drawing.Size(100, 19);
            this.chAllData.TabIndex = 35;
            this.chAllData.Text = "все таблицы";
            this.toolTipMsgSetting.SetToolTip(this.chAllData, "обработать все таблицы");
            this.chAllData.UseVisualStyleBackColor = true;
            this.chAllData.CheckedChanged += new System.EventHandler(this.chAllData_CheckedChanged);
            // 
            // chDeleteOnly
            // 
            this.chDeleteOnly.AutoSize = true;
            this.chDeleteOnly.Location = new System.Drawing.Point(302, 47);
            this.chDeleteOnly.Margin = new System.Windows.Forms.Padding(2);
            this.chDeleteOnly.Name = "chDeleteOnly";
            this.chDeleteOnly.Size = new System.Drawing.Size(124, 19);
            this.chDeleteOnly.TabIndex = 34;
            this.chDeleteOnly.Text = "только очистить";
            this.chDeleteOnly.UseVisualStyleBackColor = true;
            // 
            // cbSheetTable
            // 
            this.cbSheetTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheetTable.FormattingEnabled = true;
            this.cbSheetTable.Location = new System.Drawing.Point(121, 45);
            this.cbSheetTable.Name = "cbSheetTable";
            this.cbSheetTable.Size = new System.Drawing.Size(164, 23);
            this.cbSheetTable.TabIndex = 32;
            this.toolTipMsgSetting.SetToolTip(this.cbSheetTable, "имена листов(таблиц) в файле импорта");
            this.cbSheetTable.SelectedIndexChanged += new System.EventHandler(this.cbSheetTable_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "Файл";
            // 
            // btMainImport
            // 
            this.btMainImport.ImageIndex = 6;
            this.btMainImport.ImageList = this.imgListButtonSetting;
            this.btMainImport.Location = new System.Drawing.Point(427, 42);
            this.btMainImport.Margin = new System.Windows.Forms.Padding(2);
            this.btMainImport.Name = "btMainImport";
            this.btMainImport.Size = new System.Drawing.Size(93, 26);
            this.btMainImport.TabIndex = 10;
            this.btMainImport.Text = "Обновить";
            this.btMainImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMainImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMainImport.UseVisualStyleBackColor = true;
            this.btMainImport.Click += new System.EventHandler(this.btMainImport_Click);
            // 
            // btMainImportPathOpen
            // 
            this.btMainImportPathOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMainImportPathOpen.Location = new System.Drawing.Point(490, 17);
            this.btMainImportPathOpen.Name = "btMainImportPathOpen";
            this.btMainImportPathOpen.Size = new System.Drawing.Size(29, 23);
            this.btMainImportPathOpen.TabIndex = 7;
            this.btMainImportPathOpen.Text = "...";
            this.btMainImportPathOpen.UseVisualStyleBackColor = true;
            this.btMainImportPathOpen.Click += new System.EventHandler(this.btMainImportPathOpen_Click);
            // 
            // tbMainImportPath
            // 
            this.tbMainImportPath.Location = new System.Drawing.Point(63, 19);
            this.tbMainImportPath.Name = "tbMainImportPath";
            this.tbMainImportPath.ReadOnly = true;
            this.tbMainImportPath.Size = new System.Drawing.Size(422, 21);
            this.tbMainImportPath.TabIndex = 6;
            this.toolTipMsgSetting.SetToolTip(this.tbMainImportPath, "путь к файлу данных для импорта");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(522, 124);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Начальное заполнение данных";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btFileNameOpen);
            this.groupBox2.Controls.Add(this.tbPathImport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(518, 120);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Импорт данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Файл";
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
            this.groupBox1.Location = new System.Drawing.Point(7, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(506, 72);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инициализация БД";
            // 
            // tbRangePass
            // 
            this.tbRangePass.Location = new System.Drawing.Point(306, 46);
            this.tbRangePass.Name = "tbRangePass";
            this.tbRangePass.Size = new System.Drawing.Size(100, 21);
            this.tbRangePass.TabIndex = 12;
            this.toolTipMsgSetting.SetToolTip(this.tbRangePass, "укажите диапазон НА ОДНУ СТРОЧКУ ВЫШЕ\r\nв формате -  Имя столбца : Номер строки\r\n(" +
        "без использования абсрлютной адресации $))\r\n");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Диапазон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Лист";
            // 
            // cbSheetPass
            // 
            this.cbSheetPass.FormattingEnabled = true;
            this.cbSheetPass.Location = new System.Drawing.Point(127, 46);
            this.cbSheetPass.Name = "cbSheetPass";
            this.cbSheetPass.Size = new System.Drawing.Size(103, 23);
            this.cbSheetPass.TabIndex = 11;
            this.toolTipMsgSetting.SetToolTip(this.cbSheetPass, "имена листов(таблиц) в файле импорта");
            // 
            // tbRangeUser
            // 
            this.tbRangeUser.Location = new System.Drawing.Point(306, 19);
            this.tbRangeUser.Name = "tbRangeUser";
            this.tbRangeUser.Size = new System.Drawing.Size(100, 21);
            this.tbRangeUser.TabIndex = 9;
            this.toolTipMsgSetting.SetToolTip(this.tbRangeUser, "укажите диапазон НА ОДНУ СТРОЧКУ ВЫШЕ\r\nв формате -  Имя столбца : Номер строки\r\n(" +
        "без использования абсрлютной адресации $))");
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
            this.cbSheetUser.TabIndex = 8;
            this.toolTipMsgSetting.SetToolTip(this.cbSheetUser, "имена листов(таблиц) в файле импорта");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Проходы";
            // 
            // btImportPass
            // 
            this.btImportPass.ImageIndex = 7;
            this.btImportPass.ImageList = this.imgListButtonSetting;
            this.btImportPass.Location = new System.Drawing.Point(413, 43);
            this.btImportPass.Margin = new System.Windows.Forms.Padding(2);
            this.btImportPass.Name = "btImportPass";
            this.btImportPass.Size = new System.Drawing.Size(84, 26);
            this.btImportPass.TabIndex = 13;
            this.btImportPass.Text = "Импорт";
            this.btImportPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportPass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImportPass.UseVisualStyleBackColor = true;
            this.btImportPass.Click += new System.EventHandler(this.btImportPass_Click);
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
            this.btImportUsers.TabIndex = 10;
            this.btImportUsers.Text = "Импорт";
            this.btImportUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImportUsers.UseVisualStyleBackColor = true;
            this.btImportUsers.Click += new System.EventHandler(this.btImportUsers_Click);
            // 
            // btFileNameOpen
            // 
            this.btFileNameOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFileNameOpen.Location = new System.Drawing.Point(482, 18);
            this.btFileNameOpen.Name = "btFileNameOpen";
            this.btFileNameOpen.Size = new System.Drawing.Size(29, 23);
            this.btFileNameOpen.TabIndex = 7;
            this.btFileNameOpen.Text = "...";
            this.btFileNameOpen.UseVisualStyleBackColor = true;
            this.btFileNameOpen.Click += new System.EventHandler(this.btFileName_Click);
            // 
            // tbPathImport
            // 
            this.tbPathImport.Location = new System.Drawing.Point(63, 19);
            this.tbPathImport.Name = "tbPathImport";
            this.tbPathImport.ReadOnly = true;
            this.tbPathImport.Size = new System.Drawing.Size(417, 21);
            this.tbPathImport.TabIndex = 6;
            this.tbPathImport.Text = "путь к файлу данных для импорта";
            // 
            // statusStripSetting
            // 
            this.statusStripSetting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripProgressBarImport});
            this.statusStripSetting.Location = new System.Drawing.Point(0, 152);
            this.statusStripSetting.Name = "statusStripSetting";
            this.statusStripSetting.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStripSetting.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripSetting.Size = new System.Drawing.Size(530, 24);
            this.statusStripSetting.SizingGrip = false;
            this.statusStripSetting.TabIndex = 25;
            this.statusStripSetting.Text = "statusStripSetting";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(329, 19);
            this.toolStripStatusLabelInfo.Spring = true;
            this.toolStripStatusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBarImport
            // 
            this.toolStripProgressBarImport.Name = "toolStripProgressBarImport";
            this.toolStripProgressBarImport.Size = new System.Drawing.Size(188, 18);
            // 
            // openFileDialogSetting
            // 
            this.openFileDialogSetting.FileName = "openFileDialog1";
            // 
            // timerImportExport
            // 
            this.timerImportExport.Interval = 1000;
            this.timerImportExport.Tick += new System.EventHandler(this.timerImportExport_Tick);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 176);
            this.Controls.Add(this.mainPanelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSetting";
            this.Text = "Общиен настройки Импорт Экспорт данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.mainPanelSetting.ResumeLayout(false);
            this.mainPanelSetting.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesLunchBreakTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesChangingFullWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHoursInFullWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDaysInWorkWeek)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btFileNameOpen;
        private System.Windows.Forms.TextBox tbPathImport;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nDaysInWorkWeek;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nHoursInFullWorkDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nMinutesChangingFullWorkDay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nMinutesLunchBreakTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialogSetting;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSetting;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btMainImport;
        private System.Windows.Forms.Button btMainImportPathOpen;
        private System.Windows.Forms.TextBox tbMainImportPath;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btMainExport;
        private System.Windows.Forms.Button btMainExportPathSave;
        private System.Windows.Forms.TextBox tbMainExportPath;
        private System.Windows.Forms.Timer timerImportExport;
        private System.Windows.Forms.ComboBox cbSheetTable;
        private System.Windows.Forms.CheckBox chAllData;
        private System.Windows.Forms.CheckBox chDeleteOnly;
    }
}