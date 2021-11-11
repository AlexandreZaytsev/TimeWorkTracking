
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
            this.SuspendLayout();
            // 
            // mcReport
            // 
            this.mcReport.Location = new System.Drawing.Point(4, 4);
            this.mcReport.Name = "mcReport";
            this.mcReport.ShowWeekNumbers = true;
            this.mcReport.TabIndex = 0;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 217);
            this.Controls.Add(this.mcReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcReport;
    }
}