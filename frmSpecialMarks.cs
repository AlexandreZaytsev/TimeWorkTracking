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
    public partial class frmSpecialMarks : Form
    {
        ListViewItemComparer _lvwItemComparer;
        public frmSpecialMarks()
        {
            InitializeComponent();
        }

        private void frmSpecialMarks_Load(object sender, EventArgs e)
        {
            splitContainerEdit.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting);
            if (splitContainerEdit.Enabled) 
            {
                dgDataBase.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From SpecialMarks");

                lstDataBase.DisplayMember = "Name";
                lstDataBase.ValueMember = "Name";
                lstDataBase.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From SpecialMarks");

                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From SpecialMarks"));
             //   lstwDataBase.DataBindings

                /*
                                                            "Id int PRIMARY KEY IDENTITY, " +
                                        "DigitalCode NVARCHAR(4) NOT NULL, " +
                                        "LetterCode NVARCHAR(4) NOT NULL, " +
                                        "Name NVARCHAR(150) NOT NULL UNIQUE, " +
                                        "Note NVARCHAR(1024) NULL, " +
                                        "Uses bit NOT NULL " +
                */




            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBase.View = View.Details;               // Set the view to show details.
            lstwDataBase.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBase.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBase.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBase.GridLines = true;                  // Display grid lines.
            lstwDataBase.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.

/*
            // Attach Subitems to the ListView
            lstwDataBase.Columns.Add("Digital", 25, HorizontalAlignment.Left);
            lstwDataBase.Columns.Add("Letter", 35, HorizontalAlignment.Left);
            lstwDataBase.Columns.Add("Name", 100, HorizontalAlignment.Left);
            lstwDataBase.Columns.Add("FullName", 200, HorizontalAlignment.Left);
            lstwDataBase.Columns.Add("Use", 20, HorizontalAlignment.Left);
*/
            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer();
            this.lstwDataBase.ListViewItemSorter = _lvwItemComparer;
        }

        // Load Data from the DataSet into the ListView
        private void LoadList(DataTable dtable)
        {
            // Get the table from the data set
            //            DataTable dtable = _DataSet.Tables["Titles"];

            // Clear the ListView control
            lstwDataBase.Items.Clear();

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem("",0);
                    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                   // lvi.SubItems.Add(drow["id"].ToString());
                    lvi.SubItems.Add(drow["DigitalCode"].ToString());
                    lvi.SubItems.Add(drow["LetterCode"].ToString());
                    lvi.SubItems.Add(drow["Name"].ToString());
                    lvi.SubItems.Add(drow["Note"].ToString());
                    //  lvi.Checked = true;

                    // Add the list items to the ListView
                    lstwDataBase.Items.Add(lvi);
                }
            }
        }

        private void lstwDataBase_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lstwDataBase.Sort();
        }

        private void lstwDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(lstwDataBase.SelectedIndices[0].ToString());
            /*
              ListView.SelectedIndexCollection indices = lstwDataBase.SelectedIndices;
              MessageBox.Show(indices.ToString());
           */
            //    MessageBox.Show(lstwDataBase.Items.IndexOf(lstwDataBase.SelectedItems[0]).ToString());

            /*
            if (lstwDataBase.FocusedItem == null) return;
            int p = lstwDataBase.FocusedItem.Index;
            MessageBox.Show(p.ToString());
            */

            /*

                        int selectionindex = lstwDataBase.SelectedIndex();
            if (selectionindex != -1) 
            {
                ListViewItem seletedItem = lstwDataBase.Items[selectionindex];
                MessageBox.Show(selectionindex.ToString());
            }
            */
            int ind = lstwDataBase.SelectedIndex();
            if (ind >= 0)
                MessageBox.Show(ind.ToString()+"\n"+
                                lstwDataBase.Items[ind].SubItems[1].ToString() +"\n"+
                                lstwDataBase.Items[ind].SubItems[2].ToString() + "\n" +
                                lstwDataBase.Items[ind].SubItems[3].ToString() + "\n" +
                                lstwDataBase.Items[ind].SubItems[4].ToString() + "\n" //+
                            //    lstwDataBase.Items[ind].SubItems[5].ToString() + "\n" 
                                );

            //             lstwDataBase.DeleteItem(lstwDataBase.SelectedIndex);


        }

        private void lstwDataBase_ItemActivate(object sender, EventArgs e)
        {
   //         MessageBox.Show(lstwDataBase.FocusedItem.SubItems[3].Text);
        }


        //запретить изменение размеров
        private void lstwDataBase_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBase.Columns[e.ColumnIndex].Width;
        }
    }

    /*----------------------------------------------------------------------------------------------------------
     *  РАСШИРЕНИЯ
     -----------------------------------------------------------------------------------------------------------*/

    //получить номер выделенной строки
    public static class Extension
    {
        public static int SelectedIndex(this ListView listView)
        {
            if (listView.SelectedIndices.Count > 0)
                return listView.SelectedIndices[0];
            else
                return -1;
        }
    }
}
