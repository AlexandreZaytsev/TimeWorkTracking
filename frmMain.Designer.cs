
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(882, 26);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(262, 20);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
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
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmMain";
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
    }
}

