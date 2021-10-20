
namespace TimeWorkTracking
{
    partial class frmSpecialMarks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialMarks));
            this.dgDataBase = new System.Windows.Forms.DataGridView();
            this.splitContainerEdit = new System.Windows.Forms.SplitContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lstDataBase = new System.Windows.Forms.ListBox();
            this.lstwDataBase = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataBase)).BeginInit();
            this.splitContainerEdit.Panel1.SuspendLayout();
            this.splitContainerEdit.Panel2.SuspendLayout();
            this.splitContainerEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDataBase
            // 
            this.dgDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgDataBase.Location = new System.Drawing.Point(0, 0);
            this.dgDataBase.Name = "dgDataBase";
            this.dgDataBase.Size = new System.Drawing.Size(325, 170);
            this.dgDataBase.TabIndex = 0;
            // 
            // splitContainerEdit
            // 
            this.splitContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEdit.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEdit.Name = "splitContainerEdit";
            // 
            // splitContainerEdit.Panel1
            // 
            this.splitContainerEdit.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainerEdit.Panel1.Controls.Add(this.dgDataBase);
            // 
            // splitContainerEdit.Panel2
            // 
            this.splitContainerEdit.Panel2.Controls.Add(this.lstwDataBase);
            this.splitContainerEdit.Panel2.Controls.Add(this.lstDataBase);
            this.splitContainerEdit.Size = new System.Drawing.Size(1082, 438);
            this.splitContainerEdit.SplitterDistance = 325;
            this.splitContainerEdit.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(70, 194);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // lstDataBase
            // 
            this.lstDataBase.FormattingEnabled = true;
            this.lstDataBase.Location = new System.Drawing.Point(3, 12);
            this.lstDataBase.Name = "lstDataBase";
            this.lstDataBase.Size = new System.Drawing.Size(232, 95);
            this.lstDataBase.TabIndex = 0;
            // 
            // lstwDataBase
            // 
            this.lstwDataBase.HideSelection = false;
            this.lstwDataBase.Location = new System.Drawing.Point(21, 136);
            this.lstwDataBase.Name = "lstwDataBase";
            this.lstwDataBase.Size = new System.Drawing.Size(720, 290);
            this.lstwDataBase.TabIndex = 1;
            this.lstwDataBase.UseCompatibleStateImageBehavior = false;
            this.lstwDataBase.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBase_ColumnClick);
            // 
            // frmSpecialMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 438);
            this.Controls.Add(this.splitContainerEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpecialMarks";
            this.Text = "Специальные отметки";
            this.Load += new System.EventHandler(this.frmSpecialMarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataBase)).EndInit();
            this.splitContainerEdit.Panel1.ResumeLayout(false);
            this.splitContainerEdit.Panel2.ResumeLayout(false);
            this.splitContainerEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDataBase;
        private System.Windows.Forms.SplitContainer splitContainerEdit;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox lstDataBase;
        private System.Windows.Forms.ListView lstwDataBase;
    }
}