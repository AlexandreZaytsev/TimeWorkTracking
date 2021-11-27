
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
            this.imgListButtonSetting = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.btImportUsers = new System.Windows.Forms.Button();
            this.btFileName = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.statusStripSetting = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarImport = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTipMsgSetting = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorkerSetting = new System.ComponentModel.BackgroundWorker();
            this.mainPanelSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesLunchBreakTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesChangingFullWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHoursInFullWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDaysInWorkWeek)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStripSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanelSetting
            // 
            this.mainPanelSetting.Controls.Add(this.groupBox3);
            this.mainPanelSetting.Controls.Add(this.groupBox2);
            this.mainPanelSetting.Controls.Add(this.statusStripSetting);
            this.mainPanelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainPanelSetting.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanelSetting.Name = "mainPanelSetting";
            this.mainPanelSetting.Size = new System.Drawing.Size(710, 346);
            this.mainPanelSetting.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.tbCompanyName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(9, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 122);
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
            this.groupBox4.Location = new System.Drawing.Point(9, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(675, 58);
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
            this.nMinutesLunchBreakTime.Location = new System.Drawing.Point(612, 27);
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
            this.nMinutesLunchBreakTime.Size = new System.Drawing.Size(51, 24);
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
            this.label12.Location = new System.Drawing.Point(519, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 18);
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
            this.nMinutesChangingFullWorkDay.Location = new System.Drawing.Point(457, 28);
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
            this.nMinutesChangingFullWorkDay.Size = new System.Drawing.Size(56, 24);
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
            this.label10.Location = new System.Drawing.Point(385, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 18);
            this.label10.TabIndex = 41;
            this.label10.Text = "+/- (мин)";
            // 
            // nHoursInFullWorkDay
            // 
            this.nHoursInFullWorkDay.Location = new System.Drawing.Point(332, 27);
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
            this.nHoursInFullWorkDay.Size = new System.Drawing.Size(40, 24);
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
            this.label9.Location = new System.Drawing.Point(179, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Полный день (час)";
            // 
            // nDaysInWorkWeek
            // 
            this.nDaysInWorkWeek.Location = new System.Drawing.Point(128, 27);
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
            this.nDaysInWorkWeek.Size = new System.Drawing.Size(41, 24);
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
            this.label8.Location = new System.Drawing.Point(7, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "Дней в неделе";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(137, 24);
            this.tbCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(544, 24);
            this.tbCompanyName.TabIndex = 1;
            this.toolTipMsgSetting.SetToolTip(this.tbCompanyName, "укажите диапазон НА ОДНУ СТРОЧКУ ВЫШЕ\r\nв формате -  Имя столбца : Номер строки\r\n(" +
        "без использования абсрлютной адресации $))");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Имя компании";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btFileName);
            this.groupBox2.Controls.Add(this.tbPath);
            this.groupBox2.Location = new System.Drawing.Point(9, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 166);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Импорт данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(675, 100);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инициализация БД";
            // 
            // tbRangePass
            // 
            this.tbRangePass.Location = new System.Drawing.Point(408, 60);
            this.tbRangePass.Margin = new System.Windows.Forms.Padding(4);
            this.tbRangePass.Name = "tbRangePass";
            this.tbRangePass.Size = new System.Drawing.Size(132, 24);
            this.tbRangePass.TabIndex = 12;
            this.toolTipMsgSetting.SetToolTip(this.tbRangePass, "укажите диапазон НА ОДНУ СТРОЧКУ ВЫШЕ\r\nв формате -  Имя столбца : Номер строки\r\n(" +
        "без использования абсрлютной адресации $))\r\n");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Диапазон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Лист";
            // 
            // cbSheetPass
            // 
            this.cbSheetPass.FormattingEnabled = true;
            this.cbSheetPass.Location = new System.Drawing.Point(169, 60);
            this.cbSheetPass.Margin = new System.Windows.Forms.Padding(4);
            this.cbSheetPass.Name = "cbSheetPass";
            this.cbSheetPass.Size = new System.Drawing.Size(136, 26);
            this.cbSheetPass.TabIndex = 11;
            // 
            // tbRangeUser
            // 
            this.tbRangeUser.Location = new System.Drawing.Point(408, 23);
            this.tbRangeUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbRangeUser.Name = "tbRangeUser";
            this.tbRangeUser.Size = new System.Drawing.Size(132, 24);
            this.tbRangeUser.TabIndex = 9;
            this.toolTipMsgSetting.SetToolTip(this.tbRangeUser, "укажите диапазон НА ОДНУ СТРОЧКУ ВЫШЕ\r\nв формате -  Имя столбца : Номер строки\r\n(" +
        "без использования абсрлютной адресации $))");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Диапазон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Лист";
            // 
            // cbSheetUser
            // 
            this.cbSheetUser.FormattingEnabled = true;
            this.cbSheetUser.Location = new System.Drawing.Point(169, 23);
            this.cbSheetUser.Margin = new System.Windows.Forms.Padding(4);
            this.cbSheetUser.Name = "cbSheetUser";
            this.cbSheetUser.Size = new System.Drawing.Size(136, 26);
            this.cbSheetUser.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Проходы";
            // 
            // btImportPass
            // 
            this.btImportPass.ImageIndex = 7;
            this.btImportPass.ImageList = this.imgListButtonSetting;
            this.btImportPass.Location = new System.Drawing.Point(551, 57);
            this.btImportPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btImportPass.Name = "btImportPass";
            this.btImportPass.Size = new System.Drawing.Size(112, 32);
            this.btImportPass.TabIndex = 13;
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
            this.label11.Location = new System.Drawing.Point(7, 27);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "Сотрудники";
            // 
            // btImportUsers
            // 
            this.btImportUsers.ImageIndex = 7;
            this.btImportUsers.ImageList = this.imgListButtonSetting;
            this.btImportUsers.Location = new System.Drawing.Point(551, 20);
            this.btImportUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btImportUsers.Name = "btImportUsers";
            this.btImportUsers.Size = new System.Drawing.Size(112, 32);
            this.btImportUsers.TabIndex = 10;
            this.btImportUsers.Text = "Импорт";
            this.btImportUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btImportUsers.UseVisualStyleBackColor = true;
            this.btImportUsers.Click += new System.EventHandler(this.btImportUsers_Click);
            // 
            // btFileName
            // 
            this.btFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFileName.Location = new System.Drawing.Point(642, 22);
            this.btFileName.Margin = new System.Windows.Forms.Padding(4);
            this.btFileName.Name = "btFileName";
            this.btFileName.Size = new System.Drawing.Size(39, 28);
            this.btFileName.TabIndex = 7;
            this.btFileName.Text = "...";
            this.btFileName.UseVisualStyleBackColor = true;
            this.btFileName.Click += new System.EventHandler(this.btFileName_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(84, 23);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(555, 24);
            this.tbPath.TabIndex = 6;
            // 
            // statusStripSetting
            // 
            this.statusStripSetting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripProgressBarImport});
            this.statusStripSetting.Location = new System.Drawing.Point(0, 316);
            this.statusStripSetting.Name = "statusStripSetting";
            this.statusStripSetting.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStripSetting.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripSetting.Size = new System.Drawing.Size(710, 30);
            this.statusStripSetting.SizingGrip = false;
            this.statusStripSetting.TabIndex = 25;
            this.statusStripSetting.Text = "statusStripSetting";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(334, 24);
            this.toolStripStatusLabelInfo.Spring = true;
            this.toolStripStatusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBarImport
            // 
            this.toolStripProgressBarImport.Name = "toolStripProgressBarImport";
            this.toolStripProgressBarImport.Size = new System.Drawing.Size(360, 22);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 346);
            this.Controls.Add(this.mainPanelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSetting";
            this.Text = "Импорт Экспорт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.mainPanelSetting.ResumeLayout(false);
            this.mainPanelSetting.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesLunchBreakTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinutesChangingFullWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHoursInFullWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDaysInWorkWeek)).EndInit();
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
    }
}