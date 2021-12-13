using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    public partial class frmCalendar : Form
    {
        clListViewItemComparer _lvwItemComparer;
        public frmCalendar()
        {
            InitializeComponent();
            lMsg.Visible = false;               //погасить сообщение о записи в БД
 //           tbID.Visible = false;
        }

        /// <summary>
        /// загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCalendar_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelCalendar.Enabled = clMsSqlDatabase.sqlConnectSimple(cs);
            if (mainPanelCalendar.Enabled)
            {
                //сначала вспомогательные данные
                cbDataType.DisplayMember = "Name";
                cbDataType.ValueMember = "id";
                cbDataType.DataSource = clMsSqlDatabase.TableRequest(cs, "Select id, name From CalendarLengthDay where uses=1");
                cbDataType.SelectedValue = "2";

                //таблица типа дня
                InitializeListViewDaysCalendar();
                LoadListDaysCalendar(clMsSqlDatabase.TableRequest(cs, "Select * From CalendarDateName where uses=1"));     //сортировка по рабочей (перенос) дате
//                lstwDataBaseDaysCalendar.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец
                if (lstwDataBaseDaysCalendar.Items.Count != 0)
                    lstwDataBaseDaysCalendar.Items[0].Selected = true;     //выделить элемент по индексу

                //потом основную таблицу
                //таблица календаря
                InitializeListViewCalendar();
                LoadListCalendar(clMsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('','') order by dWork"));     //сортировка по рабочей (перенос) дате
                if (lstwDataBaseCalendar.Items.Count != 0)
                {
                    lstwDataBaseCalendar.Items[0].Selected = true;     //выделить элемент по индексу
                    lstwDataBaseCalendar_SelectedIndexChanged(null,null);
                } 
            }
        }

        #region//Список(Таблица) данных ПРОИЗВОДСТВЕННЫЕ КАЛЕНДАРИ (данные)

        /// <summary>
        /// Инициализация списка(таблицы) данных
        /// </summary>
        private void InitializeListViewCalendar()
        {
            lstwDataBaseCalendar.View = View.Details;               // Set the view to show details.
//            lstwDataBaseCalendar.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseCalendar.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseCalendar.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseCalendar.GridLines = true;                  // Display grid lines.
            lstwDataBaseCalendar.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.
            lstwDataBaseCalendar.LabelEdit = false;                 //запрет редактирования item
//            lstwDataBaseCalendar.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец
//            lstwDataBaseCalendar.HideSelection = false;             //оставить выделение строки при потере фокуса ListView


            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new clListViewItemComparer
            {
                SortColumn = 2,                             //сортировка по рабочей дате
                Order = SortOrder.Ascending
            };
            lstwDataBaseCalendar.ListViewItemSorter = _lvwItemComparer;
        }

        /// <summary>
        /// Загрузка списка(таблицы) данных (Data из DataSet в ListView)
        /// </summary>
        /// <param name="dtable"></param>
        private void LoadListCalendar(DataTable dtable)
        {
            lstwDataBaseCalendar.Items.Clear();             //очистить коллекцию элементов
            lstwDataBaseCalendar.Groups.Clear();            //очистить коллекцию группы

            for (int i = 0; i < dtable.Rows.Count; i++)     //цикл по DataTable и заполнение ListView 
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    //Определим группы
                    string name = ((DateTime)drow["dWork"]).ToString("yyyy");
                    ListViewGroup lvg = new ListViewGroup(name, "Календарь за " + name+"г.");//, HorizontalAlignment.Left);

                    //Определим элементы
                    ListViewItem lvi = new ListViewItem(drow["access"].ToString(), 0) //имя для сортировки
                    {
                        ImageIndex = (Boolean)drow["access"] ? 1 : 0,
                        StateImageIndex = (Boolean)drow["access"] ? 1 : 0,
                        Checked = (Boolean)drow["access"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    lvi.SubItems.Add(((DateTime)drow["dWork"]).ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(((DateTime)drow["dSource"]).ToString("yyyy-MM-dd"));
                    lvi.SubItems.Add(drow["dName"].ToString());
                    lvi.SubItems.Add(drow["dLength"].ToString());
                    lvi.SubItems.Add(drow["id"].ToString());

                    //                https://stackoverflow.com/questions/39428698/adding-groups-and-items-to-listview-in-c-sharp-windows-form

                    //проверим есть ли потенциальная группа в коллекции групп если нет добавим
                    if (lstwDataBaseCalendar.Groups.Cast<ListViewGroup>().Count(x => (x.Name == lvg.Name))==0)
                        lstwDataBaseCalendar.Groups.Add(lvg);

                    //найдем группу среди групп
                    lvi.Group = lstwDataBaseCalendar.Groups.Cast<ListViewGroup>()
                            .Where(x => (x.Name == lvg.Name))                   
                            .FirstOrDefault();

                    //создадим элемент
                    lstwDataBaseCalendar.Items.Add(lvi);                        // Add the list items to the ListView
                    //добавим его в группу
                }
            }
            //после загрузки списка установить авторазмер последней колонки
            lstwDataBaseCalendar.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец
        }

        /// <summary>
        /// Сортировка списка(таблицы) данных по заголовкам столбцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseCalendar_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lstwDataBaseCalendar.Sort();
        }

        /// <summary>
        /// Выбор значения в списке(таблице) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstwDataBaseCalendar.Focused || lstwDataBaseCalendar.SelectedItems.Count>0)                      //если календарь активен (в фокусе)
            {
                int ind = lstwDataBaseCalendar.extSelectedIndex();
                if (ind >= 0)
                {

                    dtSource.Value = DateTime.Parse(lstwDataBaseCalendar.Items[ind].SubItems[2].Text);
                    //засветить строку из списка
                    for (int index = 0; index <= lstwDataBaseDaysCalendar.Items.Count - 1; index++)
                    {
                        if (lstwDataBaseDaysCalendar.Items[index].SubItems[2].Text == lstwDataBaseCalendar.Items[ind].SubItems[3].Text)
                        {
                            lstwDataBaseDaysCalendar.Items[index].Selected = true;
                            lstwDataBaseDaysCalendar.EnsureVisible(index);  //показать в области видимости окна
                            break;
                        }
                    }
                    dtWork.Value = DateTime.Parse(lstwDataBaseCalendar.Items[ind].SubItems[1].Text);
                    
                    tbID.Text = lstwDataBaseCalendar.Items[ind].SubItems[5].Text;               //id базы данных    
                    cbDataType.Text = lstwDataBaseCalendar.Items[ind].SubItems[4].Text;         //тип дня
                    chUse.Checked = lstwDataBaseCalendar.Items[ind].Text == "True";

                }
            }
        }

        /// <summary>
        /// Запрет изменения размеров ширины колонок списка(таблицы) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseCalendar_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseCalendar.Columns[e.ColumnIndex].Width;
        }

        #endregion

        #region//Список(Таблица) данных ПРОИЗВОДСТВЕННЫЙ КАЛЕНДАРЬ (настройка)

        /// <summary>
        /// Инициализация списка(таблицы) данных
        /// </summary>
        private void InitializeListViewDaysCalendar()
        {
            lstwDataBaseDaysCalendar.View = View.Details;               // Set the view to show details.
            lstwDataBaseDaysCalendar.LabelEdit = true;                  // Allow the user to edit item text.
            lstwDataBaseDaysCalendar.AllowColumnReorder = true;         // Allow the user to rearrange columns.
            lstwDataBaseDaysCalendar.FullRowSelect = true;              // Select the item and subitems when selection is made.
            lstwDataBaseDaysCalendar.GridLines = true;                  // Display grid lines.

            //            lstwDataBaseDaysCalendar.Sorting = SortOrder.Ascending;     // Sort the items in the list in ascending order.
        }

        /// <summary>
        /// Загрузка списка(таблицы) данных (Data из DataSet в ListView)
        /// </summary>
        /// <param name="dtable"></param>
        private void LoadListDaysCalendar(DataTable dtable)
        {
            lstwDataBaseDaysCalendar.Items.Clear();         // Clear the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)     // Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    // Define the list items
                    lstwDataBaseDaysCalendar.LabelEdit = false;      //запрет редактирования item
                    ListViewItem lvi = new ListViewItem(drow["uses"].ToString(), 0) //имя для сортировки
                    {
//                        ImageIndex = (int)drow["dateTypeId"] == 1 ? 2 : 3,
                        StateImageIndex = (int)drow["dateTypeId"]== 1 ? 2 : 3,
//                        Checked = (Boolean)drow["uses"]
                        //                        , UseItemStyleForSubItems = true
                    };

                    //    lvi.Checked = (Boolean)drow["Uses"];
                    //       lvi.SubItems.Add(drow["Uses"].ToString());
                    lvi.SubItems.Add(drow["date"].ToString() == "" ? "-" : ((DateTime)drow["date"]).ToString("d MMMMM"));
                    lvi.SubItems.Add(drow["name"].ToString());
                    lvi.SubItems.Add(drow["id"].ToString().PadLeft(8, '0'));        //используется для строковой сортировки по колонке
                    lvi.SubItems.Add(drow["id"].ToString());
                    lvi.SubItems.Add(drow["date"].ToString() == "" ? DateTime.Today.ToString("d") : ((DateTime)drow["date"]).ToString("dd.MM.")+ DateTime.Now.Year.ToString());
                    lstwDataBaseDaysCalendar.Items.Add(lvi);                        // Add the list items to the ListView
                }
            }
            //после загрузки списка установить авторазмер последней колонки
            lstwDataBaseDaysCalendar.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец
        }

        /// <summary>
        /// Выбор значения в списке(таблице) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseDaysCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstwDataBaseDaysCalendar.Focused)                      //если календарь дат активен (в фокусе)
            {     
                int ind = lstwDataBaseDaysCalendar.extSelectedIndex();             //индекс выделенной строки
                lbdtSource.Font = new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Regular);
                if (ind >= 0)                                                    //если есть выделенная строка
                {
                    if (lstwDataBaseDaysCalendar.Items[ind].SubItems[1].Text != "-")
                    {                                                           //установить дату из списка    
                        dtSource.Value = DateTime.Parse(lstwDataBaseDaysCalendar.Items[ind].SubItems[5].Text);
                        lbdtSource.Font = new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {                                                           //установить текущую дату
                        dtSource.Value = DateTime.Today;
                    }
                }
            }
        }

        /// <summary>
        /// Запрет изменения размеров ширины колонок списка(таблицы) данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstwDataBaseDaysCalendar_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseDaysCalendar.Columns[e.ColumnIndex].Width;
        }

        #endregion
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// редактирование поля Исходная дата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtSource_ValueChanged(object sender, EventArgs e)
        {
            lbDirect.Text = dtWork.Value != dtSource.Value ? "ï" : "ó";
            bool selDate = false;
            dtWork.Value = dtSource.Value;                              //установить реальную дату по исходной
            string fd = ((DateTime)dtSource.Value).ToString("d MMMMM");

            if (!lstwDataBaseDaysCalendar.Focused)                      //если календарь дат не активен (не в фокусе)   
            {
                for (int index = 0; index <= lstwDataBaseDaysCalendar.Items.Count - 1; index++)
                {                                                       //цикл по календарю дат
                    if (lstwDataBaseDaysCalendar.Items[index].SubItems[1].Text == fd)   
                    {                                                   //если день найден
                        selDate = true;
                        lstwDataBaseDaysCalendar.Items[index].Selected = true;
                        lstwDataBaseDaysCalendar.EnsureVisible(index);  //показать в области видимости окна
                    }
                    else                                                //если день не найден и имеет дату
                    {
                        if (lstwDataBaseDaysCalendar.Items[index].SubItems[1].Text!="-")
                            lstwDataBaseDaysCalendar.Items[index].Selected = false;
                    }
                }
                lbdtSource.Font = selDate? new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Bold):new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Regular);
            }
        }

        /// <summary>
        /// Редактирование ключевого поля (Реальная дата)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtWork_ValueChanged(object sender, EventArgs e)
        {
            lbDirect.Text = dtWork.Value != dtSource.Value ? "ï" : "ó";
            if (lstwDataBaseCalendar.extFindListByColValue(1, dtWork.Value.ToString("yyyy-MM-dd")) >= 0) 
            {
                lbdtWork.Font = new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Bold);
                btInsert.Enabled = false;                               //заблокировать кнопку INSERT    
                btUpdate.Enabled = true;                                //разблокировать кнопку UPDATE    
                btDelete.Enabled = true;                                //разблокировать кнопку DELETE    
            }
            else 
            {
                lbdtWork.Font = new System.Drawing.Font(lbdtSource.Font, System.Drawing.FontStyle.Regular);
                btInsert.Enabled = true;// lstwDataBaseDaysCalendar.SelectedItems.Count > 0;    //кнопка INSERT (если есть выделенная строка в Календаре Дат)
                btUpdate.Enabled = false;                               //разблокировать кнопку UPDATE    
                btDelete.Enabled = false;                               //разблокировать кнопку UPDATE    
            }
        }

        /// <summary>
        /// запись доступна для использования (чекбокс)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chUse_CheckedChanged_1(object sender, EventArgs e)
        {
            chUse.ImageIndex = chUse.Checked ? 1 : 0;
        }

        #region//Запись в БД 

        /// <summary>
        /// кнопка Добавить запись в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_Click(object sender, EventArgs e)
        {
            string key = dtWork.Value.ToString("yyyy-MM-dd");               //ключевое поле
            string keySQL = dtWork.Value.ToString("yyyyMMdd");              //ключевое поле для БД

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "INSERT INTO Calendars(" +
                "originalDate, " +
                "transferDate, " +
                "dateNameId, " +
                "dayLengthId, " +
                "uses) " +
              "VALUES ( " +
                "'" + dtSource.Value.ToString("yyyyMMdd") + "', " +       //оригинальная дата
                "'" + keySQL + "', " +                                    //*рабочая дата (дата переноса)
                lstwDataBaseDaysCalendar.Items[lstwDataBaseDaysCalendar.extSelectedIndex()].SubItems[4].Text + ", " +
                ((DataRowView)cbDataType.SelectedItem).Row["id"] + ", " +
                (chUse.Checked ? 1 : 0) +
                ")";
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadListCalendar(clMsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('','') order by dWork"));     //сортировка по рабочей (перенос) дате
            lstwDataBaseCalendar.extFindListByColValue(1, key);                //найти и выделить позицию
            dtWork_ValueChanged(null,null);                                 //обновить статус кнопок
        }

        /// <summary>
        /// кнопка Обновить запись в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string key = dtWork.Value.ToString("yyyy-MM-dd");               //ключевое поле
            string keySQL = dtWork.Value.ToString("yyyyMMdd");              //ключевое поле для БД

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "UPDATE Calendars Set " +
                "originalDate = '" + dtSource.Value.ToString("yyyyMMdd") + "', " +
                "transferDate = '" + keySQL + "', " +
                "dateNameId = " + lstwDataBaseDaysCalendar.Items[lstwDataBaseDaysCalendar.extSelectedIndex()].SubItems[4].Text + ", " +
                "dayLengthId = " + ((DataRowView)cbDataType.SelectedItem).Row["id"] + ", " +
                "uses = " + (chUse.Checked ? 1 : 0) + " " +
              "WHERE transferDate = '" + keySQL + "'";                      //*рабочая дата (дата переноса)
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadListCalendar(clMsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('','') order by dWork"));     //сортировка по рабочей (перенос) дате
            lstwDataBaseCalendar.extFindListByColValue(1, key);                //найти и выделить позицию
            dtWork_ValueChanged(null, null);                                //обновить статус кнопок
        }

        /// <summary>
        /// кнопка Удалить запись в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDelete_Click(object sender, EventArgs e)
        {
            string key = dtWork.Value.ToString("yyyy-MM-dd");               //ключевое поле
            string keySQL = dtWork.Value.ToString("yyyyMMdd");              //ключевое поле для БД

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "DELETE FROM Calendars " +
              "WHERE transferDate = '" + keySQL + "'";                      //*рабочая дата (дата переноса)
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadListCalendar(clMsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('','') order by dWork"));     //сортировка по рабочей (перенос) дате
            if (lstwDataBaseCalendar.Items.Count != 0)
                lstwDataBaseCalendar.extFindListByColValue(1, lstwDataBaseCalendar.Items[0].SubItems[1].Text);            //найти и выделить позицию
            dtWork_ValueChanged(null, null);                                //обновить статус кнопок
        }

        #endregion

        #region//Interface

        /// <summary>
        /// Hover наехали на кнопку Insert загасили id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_MouseHover(object sender, EventArgs e)
        {
            tbID.Visible = false;
            lMsg.Visible = true;
            btUpdate.Visible = false;
            btDelete.Visible = false;
        }

        /// <summary>
        /// Leave уехали с кнопки Insert показали id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btInsert_MouseLeave(object sender, EventArgs e)
        {
            tbID.Visible = true;
            lMsg.Visible = false;
            btUpdate.Visible = true;
            btDelete.Visible = true;
        }

        #endregion
    }
}
