
namespace TimeWorkTracking
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsbtDataBaseSQL = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsbtDataBasePACS = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsbtGuideUsers = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsbtGuideMarks = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsbtGuideCalendar = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsbtFormHeatCheck = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsbtFormTimeCheck = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsbtReportTotal = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 78);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 124);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
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
            this.button2.Margin = new System.Windows.Forms.Padding(4);
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
            this.button3.Margin = new System.Windows.Forms.Padding(4);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 181);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(869, 242);
            this.dataGridView1.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel2,
            this.TsbtDataBaseSQL,
            this.TsbtDataBasePACS,
            this.ToolStripStatusLabel1,
            this.TsbtGuideUsers,
            this.TsbtGuideMarks,
            this.TsbtGuideCalendar,
            this.ToolStripStatusLabel3,
            this.TsbtFormHeatCheck,
            this.TsbtFormTimeCheck,
            this.ToolStripStatusLabel4,
            this.TsbtReportTotal,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(884, 26);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(55, 20);
            this.ToolStripStatusLabel2.Text = "Статус:";
            this.ToolStripStatusLabel2.ToolTipText = "12431234";
            // 
            // TsbtDataBaseSQL
            // 
            this.TsbtDataBaseSQL.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.TsbtDataBaseSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtDataBaseSQL.Name = "TsbtDataBaseSQL";
            this.TsbtDataBaseSQL.ShowDropDownArrow = false;
            this.TsbtDataBaseSQL.Size = new System.Drawing.Size(82, 24);
            this.TsbtDataBaseSQL.Text = "БД SQL";
            this.TsbtDataBaseSQL.ToolTipText = "Подключение к SQL базе учета рабочего времени";
            this.TsbtDataBaseSQL.Click += new System.EventHandler(this.tsbtDataBaseSQL_Click);
            // 
            // TsbtDataBasePACS
            // 
            this.TsbtDataBasePACS.Image = global::TimeWorkTracking.Properties.Resources.no;
            this.TsbtDataBasePACS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtDataBasePACS.Name = "TsbtDataBasePACS";
            this.TsbtDataBasePACS.ShowDropDownArrow = false;
            this.TsbtDataBasePACS.Size = new System.Drawing.Size(93, 24);
            this.TsbtDataBasePACS.Text = "БД СКУД";
            this.TsbtDataBasePACS.ToolTipText = "Подключение к web сервису СКУД";
            this.TsbtDataBasePACS.Click += new System.EventHandler(this.tsbtDataBasePACS_Click);
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(225, 20);
            this.ToolStripStatusLabel1.Spring = true;
            this.ToolStripStatusLabel1.Text = "    Справочники:";
            this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TsbtGuideUsers
            // 
            this.TsbtGuideUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtGuideUsers.Image = global::TimeWorkTracking.Properties.Resources.users;
            this.TsbtGuideUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtGuideUsers.Name = "TsbtGuideUsers";
            this.TsbtGuideUsers.ShowDropDownArrow = false;
            this.TsbtGuideUsers.Size = new System.Drawing.Size(24, 24);
            this.TsbtGuideUsers.Text = "Сотрудники";
            this.TsbtGuideUsers.Click += new System.EventHandler(this.TsbtGuideUsers_Click);
            // 
            // TsbtGuideMarks
            // 
            this.TsbtGuideMarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtGuideMarks.Image = global::TimeWorkTracking.Properties.Resources.report;
            this.TsbtGuideMarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtGuideMarks.Name = "TsbtGuideMarks";
            this.TsbtGuideMarks.ShowDropDownArrow = false;
            this.TsbtGuideMarks.Size = new System.Drawing.Size(24, 24);
            this.TsbtGuideMarks.Text = "Специальные отметки";
            this.TsbtGuideMarks.Click += new System.EventHandler(this.tsbtGuideMarks_Click);
            // 
            // TsbtGuideCalendar
            // 
            this.TsbtGuideCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtGuideCalendar.Image = global::TimeWorkTracking.Properties.Resources.calendar;
            this.TsbtGuideCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtGuideCalendar.Name = "TsbtGuideCalendar";
            this.TsbtGuideCalendar.ShowDropDownArrow = false;
            this.TsbtGuideCalendar.Size = new System.Drawing.Size(24, 24);
            this.TsbtGuideCalendar.Text = "Производственный календарь";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(152, 20);
            this.ToolStripStatusLabel3.Text = "    Печатные Формы:";
            this.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TsbtFormHeatCheck
            // 
            this.TsbtFormHeatCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtFormHeatCheck.Image = global::TimeWorkTracking.Properties.Resources.heat;
            this.TsbtFormHeatCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtFormHeatCheck.Name = "TsbtFormHeatCheck";
            this.TsbtFormHeatCheck.ShowDropDownArrow = false;
            this.TsbtFormHeatCheck.Size = new System.Drawing.Size(24, 24);
            this.TsbtFormHeatCheck.Text = "Бланк Учета температуры";
            // 
            // TsbtFormTimeCheck
            // 
            this.TsbtFormTimeCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtFormTimeCheck.Image = global::TimeWorkTracking.Properties.Resources.form;
            this.TsbtFormTimeCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtFormTimeCheck.Name = "TsbtFormTimeCheck";
            this.TsbtFormTimeCheck.ShowDropDownArrow = false;
            this.TsbtFormTimeCheck.Size = new System.Drawing.Size(24, 24);
            this.TsbtFormTimeCheck.Text = "Бланк Учета рабочего времени";
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(67, 20);
            this.ToolStripStatusLabel4.Text = "    Отчет:";
            this.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TsbtReportTotal
            // 
            this.TsbtReportTotal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtReportTotal.Image = global::TimeWorkTracking.Properties.Resources.pass;
            this.TsbtReportTotal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtReportTotal.Name = "TsbtReportTotal";
            this.TsbtReportTotal.ShowDropDownArrow = false;
            this.TsbtReportTotal.Size = new System.Drawing.Size(24, 24);
            this.TsbtReportTotal.Text = "Итоговый отчет";
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.statusStrip1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(899, 499);
            this.Name = "FrmMain";
            this.Text = "Учет рабочего времени";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmMain_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
        private System.Windows.Forms.ToolStripDropDownButton TsbtGuideUsers;
        private System.Windows.Forms.ToolStripDropDownButton TsbtGuideMarks;
        private System.Windows.Forms.ToolStripDropDownButton TsbtGuideCalendar;
        private System.Windows.Forms.ToolStripDropDownButton TsbtFormHeatCheck;
        private System.Windows.Forms.ToolStripDropDownButton TsbtFormTimeCheck;
        private System.Windows.Forms.ToolStripDropDownButton TsbtReportTotal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripDropDownButton TsbtDataBaseSQL;
        private System.Windows.Forms.ToolStripDropDownButton TsbtDataBasePACS;
    }
}

