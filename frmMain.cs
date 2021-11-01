using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * tooltip for split
https://stackoverflow.com/questions/4657394/is-it-possible-to-change-toolstripmenuitem-tooltip-font/4669343#4669343

*/

namespace TimeWorkTracking
{
    public partial class frmMain : Form
    {
        ListViewItemComparer _lvwItemComparer;                              //объект сортировки по колонкам
        DateTime smDtStart;                                                 //дата/время начала специальных отметок
        DateTime smDtStop;                                                  //дата/время окончания специальных отметок

        public frmMain()
        {
            //подписка события внешних форм 
            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler = new CallBack_FrmDataBaseSQL_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler = new CallBack_FrmDataBasePACS_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification

            InitializeComponent();
            lMsg.Visible = false;                                           //погасить сообщение о записи в БД
            cbDirect.SelectedIndex = 0;

            smDStart.Value = DateTime.Now;
            smTStart.Value = DateTime.Now;
            smDStop.Value = DateTime.Now;
            smTStop.Value = DateTime.Now.AddHours(1);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            CheckConnects();        //проверить соединение с базами
            if (mainPanelRegistration.Enabled)
            {
                cbSMarks.DisplayMember = "Name";
                cbSMarks.ValueMember = "id";
                cbSMarks.DataSource = MsSqlDatabase.TableRequest(cs, "Select id, name From SpecialMarks where uses=1");

                InitializeListView();
                LoadList(MsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('','') order by fio"));
                                                      //   select * from twt_GetPassFormData('2021.01.01', '') order by fio
            }

        }

        // Initialize ListView
        private void InitializeListView()
        {
            lstwDataBaseMain.View = View.Details;               // Set the view to show details.
            lstwDataBaseMain.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseMain.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseMain.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseMain.GridLines = true;                  // Display grid lines.
            lstwDataBaseMain.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.
            lstwDataBaseMain.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец

            //            lstwDataBaseUsers.StateImageList=
            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer
            {
                SortColumn = 1,// 1;// e.Column; (3 name)       //сортировка по ФИО
                Order = SortOrder.Ascending
            };
            lstwDataBaseMain.ListViewItemSorter = _lvwItemComparer;
        }
        //Загрузить Data из DataSet в ListView
        private void LoadList(DataTable dtable)
        {
            lstwDataBaseMain.Items.Clear();                // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseMain.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["used"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (int)drow["used"]
                        , StateImageIndex = (int)drow["used"]
                        , Checked = (int)drow["used"]==1
                        //                        , UseItemStyleForSubItems = true
                    };
                    lvi.SubItems.Add(drow["fio"].ToString());
                    lvi.SubItems.Add(drow["extId"].ToString());
                    /*
                    lvi.SubItems.Add(drow["department"].ToString());
                    lvi.SubItems.Add(drow["post"].ToString());
                    lvi.SubItems.Add(drow["startTime"].ToString());
                    lvi.SubItems.Add(drow["stopTime"].ToString());
                    lvi.SubItems.Add(drow["noLunch"].ToString());
                    lvi.SubItems.Add(drow["work"].ToString());
                    lvi.SubItems.Add(drow["note"].ToString());
                    lvi.SubItems.Add(drow["crmId"].ToString());
                    */
                    lstwDataBaseMain.Items.Add(lvi);       // Add the list items to the ListView
                }
            }
            tbSatusList.Text=getPassCount();
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseUsers_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lstwDataBaseMain.Sort();
        }



        //проверить соединение с базами
        private bool CheckConnects()
        {
            //проверка соединения с SQL
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            bool conSQL = MsSqlDatabase.CheckConnectWithConnectionStr(cs);
            this.tsbtDataBaseSQL.Image = conSQL ? Properties.Resources.ok : Properties.Resources.no;
            mainPanelRegistration.Enabled = conSQL;
            return conSQL;
        }

        //прочитать количество обраюотанных строк
        private string getPassCount()
        {
            int count = 0;    
            if (lstwDataBaseMain.Items.Count > 0)
            {
                for (int index = 0; index <= lstwDataBaseMain.Items.Count - 1; index++)
                {
                    if (lstwDataBaseMain.Items[index].Text == "1")
                        count++;    
                }
            }
            return "обработано "+ count.ToString()+" из " + lstwDataBaseMain.Items.Count.ToString();
        }

        //STATUS STRIP------------------------------------------------------------------- 
        //кнока help
        private void frmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            frmAbout aboutBox = new frmAbout();
            aboutBox.ShowDialog(this);
        }
        //кнопка настройки базы SQL
        private void tsbtDataBaseSQL_Click(object sender, EventArgs e)
        {
            frmDataBaseSQL frm = new frmDataBaseSQL {Owner = this};
            CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
            frm.ShowDialog();
        }
        //кнопка настройки базы СКУД
        private void tsbtDataBasePACS_Click(object sender, EventArgs e)
        {
            frmDataBasePACS frm = new frmDataBasePACS {Owner = this};
            CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
            frm.ShowDialog();
        }
        //кнопка настройки специальныз отметок
        private void tsbtGuideMarks_Click(object sender, EventArgs e)
        {
            frmSpecialMarks frm = new frmSpecialMarks { Owner = this };
            frm.ShowDialog();
        }
        //кнопка настройки сотрудников
        private void TsbtGuideUsers_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers { Owner = this };
            frm.ShowDialog();
        }
        //кнопка настройки календаря
        private void tsbtGuideCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar frm = new frmCalendar { Owner = this };
            frm.ShowDialog();
        }


        /*--------------------------------------------------------------------------------------------  
        CALLBACK InPut (подписка на внешние сообщения)
        --------------------------------------------------------------------------------------------*/
        /// <summary>
        /// Callbacks the reload.
        /// входящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="param">параметры ключ-значение.</param>
        private void CallbackReload(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            CheckConnects();        //проверить соединение с базами
            /*
            if (param.Count() != 0)
            {
                Control[] cntrl = this.FilterControls(c => c.Name != null && c.Name.Equals(controlName) && c is DataGridView);
                ((DataGridView)cntrl[0]).DataSource = param;
            }
            */
        }

        //изменение специальных отметок
        private void cbSMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            smDStart.Enabled = cbSMarks.Text != "-";
            smTStart.Enabled = cbSMarks.Text != "-";
            smDStop.Enabled = cbSMarks.Text != "-";
            smTStop.Enabled = cbSMarks.Text != "-";
        }

        //проверка дат в специальных отметках
        private void checkDateSpecialMarks(object sender, EventArgs e)//DateTime dStart, DateTime tStart, DateTime dStop, DateTime tStop)
        {
            if ((cbSMarks.Text != "-" && cbSMarks.Text != "") && mainPanelRegistration.Enabled) 
            { 
                if (DateTime.Compare(DateTime.Parse(smDStart.Value.ToString("yyyy-MM-dd ") + smTStart.Value.ToString("HH:mm ")),
                                     DateTime.Parse(smDStop.Value.ToString("yyyy-MM-dd ") + smTStop.Value.ToString("HH:mm ")))>0)
                {
                    //                    MessageBox.Show("Дата/Время окончания периода должно быть боольше Даты/Времени начала периода","Ошибка установки диапазона дат",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                     smDStop.Value = smDStart.Value;
                    smTStop.Value = smDStart.Value.AddHours(1);
                }
            }
        }

        private void smDStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }

    /*--------------------------------------------------------------------------------------------  
        CALLBACK OutPut (собственные сообщения)
    --------------------------------------------------------------------------------------------*/
    //general notification
    /// <summary>
    /// CallBack_GetParam
    /// исходящее асинхронное сообщение для подписанных слушателей с передачей текущих параметров 
    /// </summary>
    public static class CallBack_FrmMain_outEvent
    {
        /// <summary>
        /// Delegate callbackEvent
        /// </summary>
        /// <param name="controlName">имя CTRL</param>
        /// <param name="controlParentName">имя родителя CNTRL</param>
        /// <param name="parameterPairs">параметры ключ-значение</param>
        public delegate void callbackEvent(string controlName, string controlParentName, Dictionary<String, String> parameterPairs);
        /// <summary>
        /// The callback event handler
        /// </summary>
        public static callbackEvent callbackEventHandler;
    }
}
