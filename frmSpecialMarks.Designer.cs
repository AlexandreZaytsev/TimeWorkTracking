﻿
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialMarks));
            this.dgDataBase = new System.Windows.Forms.DataGridView();
            this.splitContainerEdit = new System.Windows.Forms.SplitContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lstwDataBase = new System.Windows.Forms.ListView();
            this.used = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDataBase = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.dgDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.dgDataBase.Name = "dgDataBase";
            this.dgDataBase.RowHeadersWidth = 51;
            this.dgDataBase.Size = new System.Drawing.Size(433, 209);
            this.dgDataBase.TabIndex = 0;
            // 
            // splitContainerEdit
            // 
            this.splitContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEdit.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEdit.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainerEdit.Size = new System.Drawing.Size(1443, 539);
            this.splitContainerEdit.SplitterDistance = 433;
            this.splitContainerEdit.SplitterWidth = 5;
            this.splitContainerEdit.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(93, 239);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown1.TabIndex = 1;
            // 
            // lstwDataBase
            // 
            this.lstwDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstwDataBase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.used,
            this.num,
            this.code,
            this.name,
            this.note});
            this.lstwDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstwDataBase.HideSelection = false;
            this.lstwDataBase.Location = new System.Drawing.Point(28, 167);
            this.lstwDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.lstwDataBase.MultiSelect = false;
            this.lstwDataBase.Name = "lstwDataBase";
            this.lstwDataBase.Size = new System.Drawing.Size(959, 356);
            this.lstwDataBase.TabIndex = 1;
            this.lstwDataBase.UseCompatibleStateImageBehavior = false;
            this.lstwDataBase.View = System.Windows.Forms.View.SmallIcon;
            this.lstwDataBase.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstwDataBase_ColumnClick);
            this.lstwDataBase.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstwDataBase_ColumnWidthChanging);
            this.lstwDataBase.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstwDataBase_DrawColumnHeader);
            this.lstwDataBase.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstwDataBase_DrawItem);
            this.lstwDataBase.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstwDataBase_DrawSubItem);
            this.lstwDataBase.ItemActivate += new System.EventHandler(this.lstwDataBase_ItemActivate);
            this.lstwDataBase.SelectedIndexChanged += new System.EventHandler(this.lstwDataBase_SelectedIndexChanged);
            // 
            // used
            // 
            this.used.Text = "";
            this.used.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.used.Width = 29;
            // 
            // num
            // 
            this.num.Text = "№";
            this.num.Width = 25;
            // 
            // code
            // 
            this.code.Text = "Код";
            this.code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.code.Width = 35;
            // 
            // name
            // 
            this.name.Text = "Наименование";
            this.name.Width = 200;
            // 
            // note
            // 
            this.note.Text = "Расшифровка";
            this.note.Width = 250;
            // 
            // lstDataBase
            // 
            this.lstDataBase.FormattingEnabled = true;
            this.lstDataBase.ItemHeight = 16;
            this.lstDataBase.Location = new System.Drawing.Point(4, 15);
            this.lstDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.lstDataBase.Name = "lstDataBase";
            this.lstDataBase.Size = new System.Drawing.Size(308, 116);
            this.lstDataBase.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "setting.ico");
            this.imageList1.Images.SetKeyName(1, "on1_.png");
            this.imageList1.Images.SetKeyName(2, "off_.png");
            this.imageList1.Images.SetKeyName(3, "on3.png");
            this.imageList1.Images.SetKeyName(4, "off3.png");
            this.imageList1.Images.SetKeyName(5, "on2.png");
            this.imageList1.Images.SetKeyName(6, "off2.png");
            this.imageList1.Images.SetKeyName(7, "off1_.png");
            this.imageList1.Images.SetKeyName(8, "on_.png");
            this.imageList1.Images.SetKeyName(9, "on.png");
            this.imageList1.Images.SetKeyName(10, "off.png");
            this.imageList1.Images.SetKeyName(11, "sel_.png");
            this.imageList1.Images.SetKeyName(12, "twt.ico");
            this.imageList1.Images.SetKeyName(13, "sel.png");
            this.imageList1.Images.SetKeyName(14, "ok.png");
            // 
            // frmSpecialMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 539);
            this.Controls.Add(this.splitContainerEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ColumnHeader num;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader note;
        private System.Windows.Forms.ColumnHeader used;
        private System.Windows.Forms.ImageList imageList1;
    }
}