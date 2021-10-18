
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtDataBaseSQL = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbtDataBasePACS = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtUsers = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton5 = new System.Windows.Forms.ToolStripSplitButton();
            this.справочникСотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникСпециальныеОтметкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.производственныйКалендарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.енкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.укенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.укенToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.укенToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(316, 120);
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsbtDataBaseSQL,
            this.tsbtDataBasePACS,
            this.toolStripStatusLabel1,
            this.tsbtUsers,
            this.toolStripSplitButton3,
            this.toolStripSplitButton2,
            this.toolStripStatusLabel3,
            this.toolStripSplitButton1,
            this.toolStripSplitButton4,
            this.toolStripStatusLabel4,
            this.toolStripSplitButton5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(655, 26);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 21);
            this.toolStripStatusLabel2.Text = "Статус:";
            this.toolStripStatusLabel2.ToolTipText = "12431234";
            // 
            // tsbtDataBaseSQL
            // 
            this.tsbtDataBaseSQL.AutoToolTip = false;
            this.tsbtDataBaseSQL.DropDownButtonWidth = 0;
            this.tsbtDataBaseSQL.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.tsbtDataBaseSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDataBaseSQL.Name = "tsbtDataBaseSQL";
            this.tsbtDataBaseSQL.Size = new System.Drawing.Size(71, 24);
            this.tsbtDataBaseSQL.Text = "БД SQL";
            this.tsbtDataBaseSQL.ToolTipText = "Подключение к базе учета рабочего времениданных SQL";
            this.tsbtDataBaseSQL.ButtonClick += new System.EventHandler(this.tsbtDataBaseSQL_ButtonClick);
            // 
            // tsbtDataBasePACS
            // 
            this.tsbtDataBasePACS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtDataBasePACS.AutoToolTip = false;
            this.tsbtDataBasePACS.DropDownButtonWidth = 0;
            this.tsbtDataBasePACS.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.tsbtDataBasePACS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDataBasePACS.Name = "tsbtDataBasePACS";
            this.tsbtDataBasePACS.Size = new System.Drawing.Size(80, 24);
            this.tsbtDataBasePACS.Text = "БД СКУД";
            this.tsbtDataBasePACS.ToolTipText = "Подключение к web сервису СКУД";
            this.tsbtDataBasePACS.Click += new System.EventHandler(this.tsbtDataBasePACS_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 21);
            this.toolStripStatusLabel1.Text = "    Справочники:";
            // 
            // tsbtUsers
            // 
            this.tsbtUsers.AutoToolTip = false;
            this.tsbtUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtUsers.DropDownButtonWidth = 14;
            this.tsbtUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникСотрудникиToolStripMenuItem,
            this.справочникСпециальныеОтметкиToolStripMenuItem,
            this.производственныйКалендарьToolStripMenuItem});
            this.tsbtUsers.Image = global::TimeWorkTracking.Properties.Resources.users;
            this.tsbtUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtUsers.Name = "tsbtUsers";
            this.tsbtUsers.Size = new System.Drawing.Size(39, 24);
            this.tsbtUsers.Text = "Пользователи";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.AutoToolTip = false;
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.DropDownButtonWidth = 0;
            this.toolStripSplitButton3.Image = global::TimeWorkTracking.Properties.Resources.specmark;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(25, 24);
            this.toolStripSplitButton3.Text = "Пользователи";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoToolTip = false;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownButtonWidth = 0;
            this.toolStripSplitButton2.Image = global::TimeWorkTracking.Properties.Resources.calendar;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(25, 24);
            this.toolStripSplitButton2.Text = "Пользователи";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(121, 21);
            this.toolStripStatusLabel3.Text = "    Печатные Формы:";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.AutoToolTip = false;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownButtonWidth = 0;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(25, 24);
            this.toolStripSplitButton1.Text = "Посещаемость";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton4.AutoToolTip = false;
            this.toolStripSplitButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton4.DropDownButtonWidth = 0;
            this.toolStripSplitButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton4.Image")));
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(25, 24);
            this.toolStripSplitButton4.Text = "Посещаемость";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(54, 21);
            this.toolStripStatusLabel4.Text = "    Отчет:";
            // 
            // toolStripSplitButton5
            // 
            this.toolStripSplitButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton5.AutoToolTip = false;
            this.toolStripSplitButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton5.DropDownButtonWidth = 0;
            this.toolStripSplitButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton5.Image")));
            this.toolStripSplitButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton5.Name = "toolStripSplitButton5";
            this.toolStripSplitButton5.Size = new System.Drawing.Size(25, 24);
            this.toolStripSplitButton5.Text = "Посещаемость";
            // 
            // справочникСотрудникиToolStripMenuItem
            // 
            this.справочникСотрудникиToolStripMenuItem.Image = global::TimeWorkTracking.Properties.Resources.users;
            this.справочникСотрудникиToolStripMenuItem.Name = "справочникСотрудникиToolStripMenuItem";
            this.справочникСотрудникиToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.справочникСотрудникиToolStripMenuItem.Text = "Справочник Сотрудники";
            // 
            // справочникСпециальныеОтметкиToolStripMenuItem
            // 
            this.справочникСпециальныеОтметкиToolStripMenuItem.Image = global::TimeWorkTracking.Properties.Resources.specmark;
            this.справочникСпециальныеОтметкиToolStripMenuItem.Name = "справочникСпециальныеОтметкиToolStripMenuItem";
            this.справочникСпециальныеОтметкиToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.справочникСпециальныеОтметкиToolStripMenuItem.Text = "Справочник Специальные отметки";
            // 
            // производственныйКалендарьToolStripMenuItem
            // 
            this.производственныйКалендарьToolStripMenuItem.Image = global::TimeWorkTracking.Properties.Resources.calendar;
            this.производственныйКалендарьToolStripMenuItem.Name = "производственныйКалендарьToolStripMenuItem";
            this.производственныйКалендарьToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.производственныйКалендарьToolStripMenuItem.Text = "Производственный календарь";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.енкеToolStripMenuItem,
            this.укенToolStripMenuItem,
            this.укенToolStripMenuItem1,
            this.укенToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // енкеToolStripMenuItem
            // 
            this.енкеToolStripMenuItem.Name = "енкеToolStripMenuItem";
            this.енкеToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.енкеToolStripMenuItem.Text = "енке";
            // 
            // укенToolStripMenuItem
            // 
            this.укенToolStripMenuItem.Name = "укенToolStripMenuItem";
            this.укенToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.укенToolStripMenuItem.Text = "укен";
            this.укенToolStripMenuItem.ToolTipText = "цукецукецуке ";
            // 
            // укенToolStripMenuItem1
            // 
            this.укенToolStripMenuItem1.Name = "укенToolStripMenuItem1";
            this.укенToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.укенToolStripMenuItem1.Text = "укен";
            // 
            // укенToolStripMenuItem2
            // 
            this.укенToolStripMenuItem2.Name = "укенToolStripMenuItem2";
            this.укенToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.укенToolStripMenuItem2.Text = "укен";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 625);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Учет рабочего времени";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton tsbtDataBasePACS;
        private System.Windows.Forms.ToolStripSplitButton tsbtDataBaseSQL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSplitButton tsbtUsers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton5;
        private System.Windows.Forms.ToolStripMenuItem справочникСпециальныеОтметкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникСотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem производственныйКалендарьToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem енкеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem укенToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem укенToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem укенToolStripMenuItem2;
    }
}

