using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TimeWorkTracking
{
    public partial class frmSpecialMarks : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmSpecialMarks()
        {
            InitializeComponent();
        }

        private void frmSpecialMarks_Load(object sender, EventArgs e)
        {
            mainPanelSpecialMarks.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting);
            if (mainPanelSpecialMarks.Enabled) 
            {
                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From SpecialMarks"));
            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBaseSpecialMarks.View = View.Details;               // Set the view to show details.
            lstwDataBaseSpecialMarks.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseSpecialMarks.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseSpecialMarks.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseSpecialMarks.GridLines = true;                  // Display grid lines.
            lstwDataBaseSpecialMarks.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 5,// 1;// e.Column; (3 name)
                Order = SortOrder.Ascending
            };

            lstwDataBaseSpecialMarks.ListViewItemSorter = _lvwItemComparer;

        }

        // Load Data from the DataSet into the ListView
        private void LoadList(DataTable dtable)
        {
            lstwDataBaseSpecialMarks.Items.Clear();         // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseSpecialMarks.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["Uses"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["Uses"] ? 1 : 0
                        , StateImageIndex = (Boolean)drow["Uses"] ? 1 : 0
                        , Checked = (Boolean)drow["Uses"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    //    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                    lvi.SubItems.Add(drow["DigitalCode"].ToString());
                    lvi.SubItems.Add(drow["LetterCode"].ToString());
                    lvi.SubItems.Add(drow["Name"].ToString());
                    lvi.SubItems.Add(drow["Note"].ToString());
                    lvi.SubItems.Add(drow["id"].ToString().PadLeft(8, '0'));
                    lvi.SubItems.Add(drow["id"].ToString());
                    //  lvi.Checked = true;
                    // Add the list items to the ListView
                    lstwDataBaseSpecialMarks.Items.Add(lvi);
                }
            }
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseSpecialMarks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == SortOrder.Ascending)
                    _lvwItemComparer.Order = SortOrder.Descending;
                else
                    _lvwItemComparer.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstwDataBaseSpecialMarks.Sort();
        }
 
        //выбор значения из списка
        private void lstwDataBaseSpecialMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = lstwDataBaseSpecialMarks.SelectedIndex();
            if (ind >= 0) 
            {
                tbCodeDigital.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[1].Text;
                tbCodeLetter.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[2].Text;
                tbName.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[3].Text;
                tbNote.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[4].Text;
                chUse.Checked = lstwDataBaseSpecialMarks.Items[ind].Text=="True";
            }
        }

        //запретить изменение размеров
        private void lstwDataBaseSpecialMarks_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseSpecialMarks.Columns[e.ColumnIndex].Width;
        }

        //чекбокс
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chUse.Checked)
                chUse.ImageIndex = 1;
            else
                chUse.ImageIndex = 0;
        }

        //редактирование ключевого поля Имя
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (lstwDataBaseSpecialMarks.Items.Cast<ListViewItem>()
                .Where(x => (x.SubItems[3].Text == tbName.Text.Trim()))     //поиск по ключевому полю
                .FirstOrDefault() != null)
            {
                tbName.BackColor = System.Drawing.SystemColors.Control;
                lstwDataBaseSpecialMarks.HideSelection = false;
                btUpdate.Enabled = true;
                btInsert.Enabled = false;
            }
            else
            {
                tbName.BackColor = System.Drawing.SystemColors.Window;
                lstwDataBaseSpecialMarks.HideSelection = true;
                btUpdate.Enabled = false;
                btInsert.Enabled = tbName.Text.Trim().Length != 0;  //если поле пустое
            }
        }
    }
}
