
namespace TimeWorkTracking
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.mcReport = new System.Windows.Forms.MonthCalendar();
            this.mainPanelReport = new System.Windows.Forms.Panel();
            this.chRange = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btFormHeatPrint = new System.Windows.Forms.Button();
            this.imgListButtonReport = new System.Windows.Forms.ImageList(this.components);
            this.btFormTimePrint = new System.Windows.Forms.Button();
            this.btReportTotalPrint = new System.Windows.Forms.Button();
            this.toolTipMsgReport = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanelReport.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcReport
            // 
            this.mcReport.Location = new System.Drawing.Point(0, 0);
            this.mcReport.Margin = new System.Windows.Forms.Padding(7);
            this.mcReport.Name = "mcReport";
            this.mcReport.ShowWeekNumbers = true;
            this.mcReport.TabIndex = 0;
            this.mcReport.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcReport_DateChanged);
            // 
            // mainPanelReport
            // 
            this.mainPanelReport.Controls.Add(this.chRange);
            this.mainPanelReport.Controls.Add(this.flowLayoutPanel1);
            this.mainPanelReport.Controls.Add(this.mcReport);
            this.mainPanelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelReport.Location = new System.Drawing.Point(0, 0);
            this.mainPanelReport.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanelReport.Name = "mainPanelReport";
            this.mainPanelReport.Size = new System.Drawing.Size(346, 164);
            this.mainPanelReport.TabIndex = 1;
            // 
            // chRange
            // 
            this.chRange.AutoSize = true;
            this.chRange.Checked = true;
            this.chRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chRange.Location = new System.Drawing.Point(187, 142);
            this.chRange.Name = "chRange";
            this.chRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chRange.Size = new System.Drawing.Size(154, 17);
            this.chRange.TabIndex = 31;
            this.chRange.Text = "дииапазон по умолчанию";
            this.toolTipMsgReport.SetToolTip(this.chRange, "использовать  диапазон дат\r\n(фиксированной длины)\r\nзаданный по умолчанию");
            this.chRange.UseVisualStyleBackColor = true;
            this.chRange.CheckedChanged += new System.EventHandler(this.chRange_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btFormHeatPrint);
            this.flowLayoutPanel1.Controls.Add(this.btFormTimePrint);
            this.flowLayoutPanel1.Controls.Add(this.btReportTotalPrint);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(187, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 136);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // btFormHeatPrint
            // 
            this.btFormHeatPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFormHeatPrint.ImageIndex = 0;
            this.btFormHeatPrint.ImageList = this.imgListButtonReport;
            this.btFormHeatPrint.Location = new System.Drawing.Point(2, 2);
            this.btFormHeatPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btFormHeatPrint.Name = "btFormHeatPrint";
            this.btFormHeatPrint.Size = new System.Drawing.Size(152, 29);
            this.btFormHeatPrint.TabIndex = 29;
            this.btFormHeatPrint.Text = "Бланк Температуры";
            this.btFormHeatPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFormHeatPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFormHeatPrint.UseVisualStyleBackColor = true;
            this.btFormHeatPrint.Click += new System.EventHandler(this.btFormHeatPrint_Click);
            // 
            // imgListButtonReport
            // 
            this.imgListButtonReport.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListButtonReport.ImageStream")));
            this.imgListButtonReport.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListButtonReport.Images.SetKeyName(0, "heat.png");
            this.imgListButtonReport.Images.SetKeyName(1, "form.png");
            this.imgListButtonReport.Images.SetKeyName(2, "pass_.png");
            this.imgListButtonReport.Images.SetKeyName(3, "db_48.png");
            this.imgListButtonReport.Images.SetKeyName(4, "db_add_48.png");
            this.imgListButtonReport.Images.SetKeyName(5, "db_edit_48.png");
            this.imgListButtonReport.Images.SetKeyName(6, "db_del_48.png");
            this.imgListButtonReport.Images.SetKeyName(7, "db_find_48.png");
            this.imgListButtonReport.Images.SetKeyName(8, "db_lock_48.png");
            this.imgListButtonReport.Images.SetKeyName(9, "db_unlock_48.png");
            this.imgListButtonReport.Images.SetKeyName(10, "db_upload_48.png");
            this.imgListButtonReport.Images.SetKeyName(11, "db_import_48.png");
            this.imgListButtonReport.Images.SetKeyName(12, "db_export_48.png");
            this.imgListButtonReport.Images.SetKeyName(13, "attention_48.png");
            this.imgListButtonReport.Images.SetKeyName(14, "info_48.png");
            this.imgListButtonReport.Images.SetKeyName(15, "holiday_48.png");
            // 
            // btFormTimePrint
            // 
            this.btFormTimePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFormTimePrint.ImageIndex = 1;
            this.btFormTimePrint.ImageList = this.imgListButtonReport;
            this.btFormTimePrint.Location = new System.Drawing.Point(2, 35);
            this.btFormTimePrint.Margin = new System.Windows.Forms.Padding(2);
            this.btFormTimePrint.Name = "btFormTimePrint";
            this.btFormTimePrint.Size = new System.Drawing.Size(152, 29);
            this.btFormTimePrint.TabIndex = 30;
            this.btFormTimePrint.Text = "Бланк Проходов";
            this.btFormTimePrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFormTimePrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btFormTimePrint.UseVisualStyleBackColor = true;
            this.btFormTimePrint.Click += new System.EventHandler(this.btFormTimePrint_Click);
            // 
            // btReportTotalPrint
            // 
            this.btReportTotalPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReportTotalPrint.ImageIndex = 2;
            this.btReportTotalPrint.ImageList = this.imgListButtonReport;
            this.btReportTotalPrint.Location = new System.Drawing.Point(2, 68);
            this.btReportTotalPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btReportTotalPrint.Name = "btReportTotalPrint";
            this.btReportTotalPrint.Size = new System.Drawing.Size(152, 29);
            this.btReportTotalPrint.TabIndex = 31;
            this.btReportTotalPrint.Text = "Итоговый отчет";
            this.btReportTotalPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReportTotalPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btReportTotalPrint.UseVisualStyleBackColor = true;
            this.btReportTotalPrint.Click += new System.EventHandler(this.btReportTotalPrint_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 164);
            this.Controls.Add(this.mainPanelReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.mainPanelReport.ResumeLayout(false);
            this.mainPanelReport.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcReport;
        private System.Windows.Forms.Panel mainPanelReport;
        private System.Windows.Forms.Button btFormHeatPrint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btFormTimePrint;
        private System.Windows.Forms.Button btReportTotalPrint;
        private System.Windows.Forms.ImageList imgListButtonReport;
        private System.Windows.Forms.ToolTip toolTipMsgReport;
        private System.Windows.Forms.CheckBox chRange;
    }
}