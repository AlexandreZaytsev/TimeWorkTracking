using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    public partial class frmUsers : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            mainPanelUsers.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting);
            if (mainPanelUsers.Enabled)
            {
                cbDepartment.DisplayMember = "Name";
                cbDepartment.ValueMember = "id";
                cbDepartment.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserDepartment");

                cbPost.DisplayMember = "Name";
                cbPost.ValueMember = "id";
                cbPost.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserPost");

                cbSheme.DisplayMember = "Name";
                cbSheme.ValueMember = "id";
                cbSheme.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserWorkScheme");

                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From Users"));

                udBeforeH.Value = new DateTime(1965, 7, 28, 9, 0, 0);
                udBeforeM.Value = new DateTime(1965, 7, 28, 9, 0, 0);
                udAfterH.Value = new DateTime(1965, 7, 28, 18, 0, 0);
                udAfterH.Value = new DateTime(1965, 7, 28, 18, 0, 0);
            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBaseUsers.View = View.Details;               // Set the view to show details.
            lstwDataBaseUsers.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseUsers.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseUsers.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseUsers.GridLines = true;                  // Display grid lines.
            lstwDataBaseUsers.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 5,// 1;// e.Column; (3 name)
                Order = SortOrder.Ascending
            };

            lstwDataBaseUsers.ListViewItemSorter = _lvwItemComparer;

        }

        // Load Data from the DataSet into the ListView
        private void LoadList(DataTable dtable)
        {
            // Get the table from the data set
            //            DataTable dtable = _DataSet.Tables["Titles"];

            // Clear the ListView control
            lstwDataBaseUsers.Items.Clear();

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    //                    listView1.Items[0].ImageIndex = 3;
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(drow["Uses"].ToString(), 0)
                    {
                        ImageIndex = (Boolean)drow["Uses"] ? 1 : 2
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
                    lstwDataBaseUsers.Items.Add(lvi);
                }
            }
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == _lvwItemComparer.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (_lvwItemComparer.Order == SortOrder.Ascending)
                    {
                        _lvwItemComparer.Order = SortOrder.Descending;
                    }
                    else
                    {
                        _lvwItemComparer.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    _lvwItemComparer.SortColumn = e.Column;
                    _lvwItemComparer.Order = SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                this.lstwDataBaseUsers.Sort();
            }
        }
        //выбор значения из списка
        private void lstwDataBaseUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = lstwDataBaseUsers.SelectedIndex();
            if (ind >= 0)
            {
                /*
                tbCodeDigital.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[1].Text;
                tbCodeLetter.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[2].Text;
                tbName.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[3].Text;
                tbNote.Text = lstwDataBaseSpecialMarks.Items[ind].SubItems[4].Text;
                chUse.Checked = lstwDataBaseSpecialMarks.Items[ind].Text == "True";
           */
             }
        }
        //запретить изменение размеров
        private void lstwDataBaseUsers_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseUsers.Columns[e.ColumnIndex].Width;
        }

        //чекбокс
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chUse.Checked)
                chUse.ImageIndex = 1;
            else
                chUse.ImageIndex = 2;
        }

    }
}
