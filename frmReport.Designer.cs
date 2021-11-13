
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
            this.mcReport = new System.Windows.Forms.MonthCalendar();
            this.mainPanelReport = new System.Windows.Forms.Panel();
            this.mainPanelReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcReport
            // 
            this.mcReport.Location = new System.Drawing.Point(0, 0);
            this.mcReport.Name = "mcReport";
            this.mcReport.ShowWeekNumbers = true;
            this.mcReport.TabIndex = 0;
            this.mcReport.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcReport_DateChanged);
            // 
            // mainPanelReport
            // 
            this.mainPanelReport.Controls.Add(this.mcReport);
            this.mainPanelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelReport.Location = new System.Drawing.Point(0, 0);
            this.mainPanelReport.Name = "mainPanelReport";
            this.mainPanelReport.Size = new System.Drawing.Size(365, 209);
            this.mainPanelReport.TabIndex = 1;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 209);
            this.Controls.Add(this.mainPanelReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.mainPanelReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcReport;
        private System.Windows.Forms.Panel mainPanelReport;
    }
}