using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
        clListViewItemComparer _lvwItemComparer;                            //объект сортировки по колонкам
        private readonly clCalendar pCalendar;                              //класс производственный календаоь
        public bool userType;                                               //false - пользователь true - админ
        private bool readType;                                              //true - чтение из списка/БД false - запись в БД  

        public frmMain()
        {
            //подписка события внешних форм 
            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler = new CallBack_FrmDataBaseSQL_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler = new CallBack_FrmDataBasePACS_outEvent.callbackEvent(this.CallbackReload);  //subscribe (listen) to the general notification
            CallBack_FrmSetting_outEvent.callbackEventHandler = new CallBack_FrmSetting_outEvent.callbackEvent(this.CallbackSetting);           //subscribe (listen) to the general notification
            CallBack_FrmImport_outEvent.callbackEventHandler = new CallBack_FrmImport_outEvent.callbackEvent(this.CallbackImport);
            CallBack_FrmLogIn_outEvent.callbackEventHandler = new CallBack_FrmLogIn_outEvent.callbackEvent(this.CallbackLogIn);                 //subscribe (listen) to the general notification

            InitializeComponent();
            lMsg.Visible = false;                                           //погасить сообщение о записи в БД
            cbDirect.SelectedIndex = 0;
            /*
                        smDStart.Value = DateTime.Now;
                        smTStart.Value = DateTime.Now;
                        smDStop.Value = DateTime.Now;
                        smTStop.Value = DateTime.Now.AddHours(1);
            */
            pCalendar = new clCalendar();                                   //создать экземпляр класса Производственный календарь
            btDelete.Visible = false;                                       //заблокировать кнопку DELETE 
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
                                                                            //            webInfoDay.Visible = false;
            if (CheckConnects())                                            //проверить соединение с базами
            {
                //                webInfoDay.Visible = true;
                pCalendar.uploadCalendar(cs, "Select * From twt_GetDateInfo('', '') order by dWork");   //прочитаем данные производственного календаря
                LoadBoldedDatesCalendar(pCalendar.getListWorkHoliday());                                //Загрузить производственный календарь в массив непериодических выделенных дат
                webInfoDay.DocumentText = pCalendar.getDateInfoHTML(mcRegDate.SelectionStart);          //прочитать харектеристики дня по производственному календарю 

                cbSMarks.DisplayMember = "Name";
                cbSMarks.ValueMember = "id";
                cbSMarks.DataSource = clMsSqlDatabase.TableRequest(cs, "Select id, name From SpecialMarks where uses=1");

                InitializeListView();
                LoadListUser(clMsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));
                mainPanelRegistration.Enabled = lstwDataBaseMain.Items.Count > 0;
            }
            else 
            {
                webInfoDay.DocumentText = pCalendar.getDateInfoHTML(DateTime.Today);
            }
        }

        //при первом показе формы
        private void frmMain_Shown(object sender, EventArgs e)
        {
            LogIn();        //авторизация
        }

        //Диалог Авторизации
        private void LogIn() 
        {
            frmLogIn frm = new frmLogIn { Owner = this };
            CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
            frm.ShowDialog();
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

            //            lstwDataBaseUsers.StateImageList=
            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new clListViewItemComparer
            {
                SortColumn = 1,// 1;// e.Column; (3 name)       //сортировка по ФИО
                Order = SortOrder.Ascending
            };
            lstwDataBaseMain.ListViewItemSorter = _lvwItemComparer;

        }
        //Загрузить Data из DataSet в ListViewUser
        private void LoadListUser(DataTable dtable)
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
                        ImageIndex = (int)drow["used"],
                        StateImageIndex = (int)drow["used"],
                        Checked = (int)drow["used"] == 1
                        //                        , UseItemStyleForSubItems = true
                    };
                    lvi.SubItems.Add(drow["fio"].ToString());                       //ФИО
                    lvi.SubItems.Add(drow["extId"].ToString());                     //внешний id
                    lvi.SubItems.Add(drow["gtStart"].ToString());                   //время начала работы по графику
                    lvi.SubItems.Add(drow["gtStop"].ToString());                    //время окончания работы по графику    
                    lvi.SubItems.Add(drow["specmarkId"].ToString());                //тип специальной отметки
                    lvi.SubItems.Add(drow["stSatrt"].ToString());                   //время начала специальной отметки
                    lvi.SubItems.Add(drow["stStop"].ToString());                    //время окончания специальной отметки
                    lvi.SubItems.Add(drow["specmarkNote"].ToString());              //комментарий к специальной отметке
                    lvi.SubItems.Add(drow["ptSart"].ToString());                    //время первого прохода
                    lvi.SubItems.Add(drow["ptStop"].ToString());                    //время последнего прохода
                    lvi.SubItems.Add(drow["noLunch"].ToString());                   //признак обеда
                    lvi.SubItems.Add(drow["workSchemeId"].ToString());              //схема работы
                    lvi.SubItems.Add(drow["passDate"].ToString());                  //дата регистрации

                    lstwDataBaseMain.Items.Add(lvi);       // Add the list items to the ListView
                }
            }
            //после загрузки списка установить авторазмер последней колонки
            lstwDataBaseMain.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец

            tbSatusList.Text = getPassCount();
            grRegistrator.Enabled = false;
        }
        //сортировка по заголовке столбца
        private void lstwDataBaseMain_ColumnClick(object sender, ColumnClickEventArgs e)
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

        //запретить изменение размеров
        private void lstwDataBaseMain_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstwDataBaseMain.Columns[e.ColumnIndex].Width;
        }

        //выбор значения из списка инициализация переменных формы
        private void lstwDataBaseMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            readType = true;                                                                //включить режим чтения данных
            DateTime dt;
            int ind = lstwDataBaseMain.extSelectedIndex();
            if (ind >= 0)
            {
                grRegistrator.Enabled = true;
                //               tbExtID.Text = lstwDataBaseUsers.Items[ind].SubItems[2].Text;                 //extID
                //crmId
                //               chUse.Checked = lstwDataBaseUsers.Items[ind].Text == "True";                  //access    
                tbName.Text = lstwDataBaseMain.Items[ind].SubItems[1].Text;                 //fio

                if (lstwDataBaseMain.Items[ind].Text == "0")                                //данных о проходе нет
                {                                                                                      
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[3].Text);  //время начала работы по графику
                    udBeforeH.Value = dt;
                    udBeforeM.Value = dt;
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[4].Text);  //время окончания работы по графику
                    udAfterH.Value = dt;
                    udAfterM.Value = dt;

                    cbSMarks.Text = "-";                                                    //тип специальной отметки

                    //дата время начала специальной отметки
                    dt = DateTime.Parse(mcRegDate.SelectionStart.ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH:mm"));
                    smDStart.Value = dt;
                    smTStart.Value = dt;
                    //дата время окончания специальной отметки
                    dt = DateTime.Parse(mcRegDate.SelectionStart.ToString("yyyy-MM-dd") + " " + udAfterH.Value.ToString("HH:mm"));
                    smDStop.Value = dt;
                    smTStop.Value = dt;

                    tbNote.Text = "";                                                       //комментарий к специальной отметке

                    btDelete.Visible = false;                                               //заблокировать кнопку DELETE    
                    btInsertUpdate.Text = "Добавить";
                    btInsertUpdate.ImageIndex = 1;
                    btInsertUpdate.Enabled = true;                                          //заблокировать кнопку UPDATE  
                }
                else                                                                        //данные о проходе есть
                {                                                                           
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[9].Text);  //время первого прохода
                    udBeforeH.Value = dt;
                    udBeforeM.Value = dt;
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[10].Text); //время последнего прохода
                    udAfterH.Value = dt;
                    udAfterM.Value = dt;

                    cbSMarks.SelectedValue = lstwDataBaseMain.Items[ind].SubItems[5].Text;  //тип специальной отметки
                    cbSMarks.Enabled = cbSMarks.Text != "";                                 //блокировать если спецотметка не опознана      

                    if (lstwDataBaseMain.Items[ind].SubItems[6].Text == "")
                        dt = DateTime.Parse(DateTime.Parse(lstwDataBaseMain.Items[ind].SubItems[13].Text).ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH:mm"));
                    else
                        dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[6].Text);  //время начала специальной отметки

                    smDStart.Value = dt;
                    smTStart.Value = dt;

                    if (lstwDataBaseMain.Items[ind].SubItems[7].Text == "")
                        dt = DateTime.Parse(DateTime.Parse(lstwDataBaseMain.Items[ind].SubItems[13].Text).ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH:mm"));
                    else
                        dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[7].Text);  //время окончания специальной отметки

                    smDStop.Value = dt;
                    smTStop.Value = dt;

                    tbNote.Text = lstwDataBaseMain.Items[ind].SubItems[8].Text;             //комментарий к специальной отметке

                    btDelete.Visible = true;                                                //разблокировать кнопку DELETE    
                    btInsertUpdate.Text = "Обновить";
                    btInsertUpdate.ImageIndex = 2;
                    btInsertUpdate.Enabled = true;                                          //разблокировать кнопку UPDATE  
                }
            }
            readType = false;                                                               //выключить режим чтения данных
        }

        //Загрузить Производственный календарь Data из DataSet в Calendar
        private void LoadBoldedDatesCalendar(List<DateTime> dList)
        {
            mcRegDate.RemoveAllBoldedDates();                           //Сбросить все непериодические даты
            foreach (DateTime dt in dList) 
            {
                mcRegDate.AddBoldedDate(dt);
            }
            mcRegDate.UpdateBoldedDates();
        }


        //проверить соединение с базами
        private bool CheckConnects()
        {
            string msg = "";
            string hostSQL = Properties.Settings.Default.twtServerName;
            string csSQL = Properties.Settings.Default.twtConnectionSrting;
            bool pingSQL = csSQL != "" && clSystemChecks.CheckPing(hostSQL);
            bool conSQL = false;
            if (!pingSQL)
                msg += "Cетевое имя сервера SQL\r\n  " + hostSQL + "- недоступно\r\n\r\n";
            else
                conSQL = clMsSqlDatabase.CheckConnectWithConnectionStr(csSQL);

            string hostPACS = Properties.Settings.Default.pacsHost;
            string csPACS = Properties.Settings.Default.pacsConnectionString;
            bool pingPACS = csPACS != "" && clSystemChecks.CheckPing(hostPACS);
            if (!pingPACS)
                msg += "Cетевое имя сервиса СКУД\r\n  " + hostPACS + "- недоступно\r\n";

            this.tsbtDataBaseSQL.Image = conSQL ? Properties.Resources.ok : Properties.Resources.no;
            mainPanelRegistration.Enabled = conSQL && lstwDataBaseMain.Items.Count > 0;
            tsbtGuideUsers.Enabled = conSQL;
            tsbtGuideMarks.Enabled = conSQL;
            tsbtGuideCalendar.Enabled = conSQL;
            tsbtFormHeatCheck.Enabled = conSQL;
            tsbtFormTimeCheck.Enabled = conSQL;
            tsbtReportTotal.Enabled = conSQL;
            toolSetting.Enabled = conSQL;

//            if (msg != "")
//                MessageBox.Show(msg+"\r\nавторизуйтесь под Администратором и\r\nнастройте соединения", "Проверка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return conSQL;
        }

        //прочитать количество обработанных строк
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
            return "обработано " + count.ToString() + " из " + lstwDataBaseMain.Items.Count.ToString();
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
            if (userType) 
            { 
                frmDataBaseSQL frm = new frmDataBaseSQL { Owner = this };
                CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
                frm.ShowDialog();
            }
        }
        //кнопка настройки базы СКУД
        private void tsbtDataBasePACS_Click(object sender, EventArgs e)
        {
            if (userType)
            {
                frmDataBasePACS frm = new frmDataBasePACS { Owner = this };
                CallBack_FrmMain_outEvent.callbackEventHandler("", "", null);  //send a general notification
                frm.ShowDialog();
            }
        }
        //кнопка Импорт Экспорт
        private void toolSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting { Owner = this };
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

        //кнопка Бланк Учета температуры
        private void tsbtFormHeatCheck_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport { Owner = this };
            CallBack_FrmMain_outEvent.callbackEventHandler("FormHeatCheck", "Бланк Учета температуры", null);  //send a general notification
            frm.ShowDialog();
        }
        //кнопка Бланк Учета рабочего времени
        private void tsbtFormTimeCheck_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport { Owner = this };
            CallBack_FrmMain_outEvent.callbackEventHandler("FormTimeCheck", "Бланк Учета рабочего времени", null);  //send a general notification
            frm.ShowDialog();
        }
        //кнопка Итоговый отчет
        private void tsbtReportTotal_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport { Owner = this };
            CallBack_FrmMain_outEvent.callbackEventHandler("ReportTotal", "Итоговый отчет", null);  //send a general notification
            frm.ShowDialog();
        }

        //STATUS STRIP------------------------------------------------------------------- 

        //изменение специальных отметок
        private void cbSMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            smDStart.Enabled = cbSMarks.Text != "-";
            smTStart.Enabled = cbSMarks.Text != "-";
            smDStop.Enabled = cbSMarks.Text != "-";
            smTStop.Enabled = cbSMarks.Text != "-";
        }

        //проверка дат в специальных отметках
        private void checkDateSpecialMarks(object sender, EventArgs e)
        {
            if ((cbSMarks.Text != "-" && cbSMarks.Text != "") && mainPanelRegistration.Enabled && !readType)
            {
                if (DateTime.Compare(DateTime.Parse(smDStart.Value.ToString("yyyy-MM-dd ") + smTStart.Value.ToString("HH:mm ")),
                                     DateTime.Parse(smDStop.Value.ToString("yyyy-MM-dd ") + smTStop.Value.ToString("HH:mm "))) > 0)
                {
                                        MessageBox.Show("Дата/Время окончания периода должно быть больше Даты/Времени начала периода","Ошибка установки диапазона дат",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    btPanel.Enabled = false;
                }
                else
                    btPanel.Enabled = true;
            }
        }

        //проверка базового времени
        private void checkBaseTimeWork(object sender, EventArgs e)
        {
            if (!readType)
            {
                if (DateTime.Compare(DateTime.Parse(mcRegDate.SelectionStart.ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm")),
                                     DateTime.Parse(mcRegDate.SelectionStart.ToString("yyyy-MM-dd") + " " + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm"))) > 0)
                {
                    MessageBox.Show("Время Входа должно быть меньше времени Выхода", "Ошибка установки времени", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btPanel.Enabled = false;
                }
                else
                    btPanel.Enabled = true;
            }

        }
        //изменение даты в календаре
        private void mcRegDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            int index = lstwDataBaseMain.extSelectedIndex();                //сохранить индекс текущей строки
                
            webInfoDay.DocumentText = pCalendar.getDateInfoHTML(e.Start);
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            LoadListUser(clMsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));

            if (index != -1) 
            {                                                               //выделить строку по индексу
                lstwDataBaseMain.Items[index].Selected = true;
                lstwDataBaseMain.HideSelection = false;                     //оставить выделение строки при потере фокуса ListView
                lstwDataBaseMain.EnsureVisible(index);                      //показать в области видимости окна
            }
        }

        //подсчитать количество рабочих дней
        /*
                private static double getBusinessDays(DateTime startD, DateTime endD)
                {
                    double calcBusinessDays =
                        1 + ((endD - startD).TotalDays * 5 -
                        (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

                    if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
                    if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

                    return calcBusinessDays;
                }
        */
        //кнопка Добавить/Обновить запись в БД
        private void btInsertUpdate_Click(object sender, EventArgs e)
        {
            DialogResult response = DialogResult.No;
            string msg;
            DateTime vDate;
            DateTime vDateIn;
            DateTime vDateOut;
            string vSpDateIn;
            string vSpDateOut;
            string timeIn;
            string timeOut;
            int spCount;

            switch (cbSMarks.Text) 
            {
                case "":                                                        //спец отметок нет - возможно смотрим историю (и спецотметка отключена в настоящий момент)
                    MessageBox.Show(
                        "Специальная отметка не указана" + "\r\n" +
                        "  возможно Вы пытаетесь перезаписать старые данные" + "\r\n" +
                        "  крайне не рекомендуем этим заниматься" + "\r\n\r\n" +
                        "операция будет отменена" + "\r\n",
                        "Попытка вмешательства в историю",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    break;
                case "-":                                                       //спец отметка Явка
                    vDate = mcRegDate.SelectionStart;                           //дата из формы + время их формы
                    vDateIn = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm")); //Время прихода
                    vDateOut = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm"));  //Время ухода
                    WriteRecord(
                        vDate, 
                        vDateIn, 
                        vDateOut, 
                        (int)((DataRowView)cbSMarks.SelectedItem).Row["id"], 
                        "-", 
                        "-", 
                        tbNote.Text.Trim());//добавить/обновить запись прохода
                    break;

                default:                                                            //спец отметки есть
                    vSpDateIn = smDStart.Value.ToString("yyyy-MM-dd") + " " + smTStart.Value.ToString("HH:mm"); //строка Дата начала спец. отметок
                    vSpDateOut = smDStop.Value.ToString("yyyy-MM-dd") + " " + smTStop.Value.ToString("HH:mm");  //строка Дата окончания спец. отметок
                    spCount = (DateTime.Parse(vSpDateOut) - DateTime.Parse(vSpDateIn)).Days;                    //количество дней в спецотметках

                    if (spCount == 0)                                           //спец отметки в пределах дня    
                    {
                        vDate = DateTime.Parse(vSpDateIn);                      //дата из начала спец отметок + время их формы
                        vDateIn = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm")); //Время прихода
                        vDateOut = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm"));  //Время ухода

                        //обработка исключений
                        response = DialogResult.Yes;
                        if (DateTime.Compare(mcRegDate.SelectionStart.Date, DateTime.Parse(vSpDateIn).Date) != 0)    //дата регистрации и дата начала спец отметок              
                        {
                            response = MessageBox.Show(
                                "Обратите внимание на даты" + "\r\n" +
                                "  " + mcRegDate.SelectionStart.ToString("dd.MM.yyyy") + " - текущая дата Регистрации" + "\r\n" +
                                "  " + DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + " - дата начала Специальных отметок" + "\r\n" +
                                "не совпадают" + "\r\n" +
                                " *данные будут записаны на Дату начала Специальных отметок" + "\r\n\r\n" +
                                "Продолжить?" + "\r\n",
                                "Изменение даты регистрации",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button2,
                                MessageBoxOptions.DefaultDesktopOnly
                                );
                        }
                        if (response == DialogResult.Yes)
                            WriteRecord(
                                vDate,
                                vDateIn,
                                vDateOut,
                                (int)((DataRowView)cbSMarks.SelectedItem).Row["id"],
                                vSpDateIn,
                                vSpDateOut,
                                tbNote.Text.Trim());//добавить/обновить запись прохода
                    }
                    else                                                        //спец отметки более одного дня
                    {
                        timeIn = lstwDataBaseMain.Items[lstwDataBaseMain.extSelectedIndex()].SubItems[3].Text;      //Время начала работы по графику
                        timeOut = lstwDataBaseMain.Items[lstwDataBaseMain.extSelectedIndex()].SubItems[4].Text;     //Время окончания работы по графику

                        //обработка исключений
                        msg = "";
                        response = DialogResult.Yes;
                        if (DateTime.Compare(mcRegDate.SelectionStart.Date, DateTime.Parse(vSpDateIn).Date) != 0)   //дата регистрации и дата начала спец отметок              
                        {
                            msg = "Обратите внимание на даты" + "\r\n" +
                             "  " + mcRegDate.SelectionStart.ToString("dd.MM.yyyy") + " - текущая дата Регистрации" + "\r\n" +
                             "  " + DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + " - дата начала Специальных отметок" + "\r\n" +
                             "не совпадают" + "\r\n" +
                             " *данные будут записаны на Дату начала Специальных отметок" + "\r\n\r\n";
                        }
                        msg += DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(vSpDateOut).ToString("dd.MM.yyyy") +
                            " - период действия Специальных отметок превышает одни сутки" + "\r\n" +
                            " *данные будут записаны на данный период с использованием времени из графика сотрудника " +
                            DateTime.Parse(timeIn).ToString("HH:mm") + "-" + DateTime.Parse(timeOut).ToString("HH:mm") + "\r\n\r\n" +
                            "Продолжить?" + "\r\n";
                        response = MessageBox.Show(
                                msg,
                                "Изменение даты регистрации",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button2,
                                MessageBoxOptions.DefaultDesktopOnly
                                );
                        if (response == DialogResult.Yes)
                        {
                            for (int i = 0; i <= spCount; i++)                          //цикл по всем датам диапазона спец отметок начиная со следующего дня 
                            {
                                vDate = DateTime.Parse(vSpDateIn).AddDays(i);           //смещение на день
                                vDateIn = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + DateTime.Parse(timeIn).ToString("HH:mm"));        //+ Время начала из графика
                                vDateOut = DateTime.Parse(vDate.ToString("yyyy-MM-dd") + " " + DateTime.Parse(timeOut).ToString("HH:mm"));      //+ Время окончания из графика
                                if (pCalendar.chechWorkDay(vDate))                  //если это рабочий день
                                    WriteRecord(
                                        vDate,
                                        vDateIn,
                                        vDateOut,
                                        (int)((DataRowView)cbSMarks.SelectedItem).Row["id"],
                                        vSpDateIn, 
                                        vSpDateOut,
                                        tbNote.Text.Trim());//добавить/обновить запись прохода
                            }
                        }
                    }
                break;
            }

            //перемещение по списку
            if (btInsertUpdate.Text != "Обновить")
            {
                int index = lstwDataBaseMain.extSelectedIndex();
                if (cbDirect.Text == "слева направо")
                    mcRegDate.SelectionStart = mcRegDate.SelectionStart.AddDays(1);
                else
                {
                    if (index == lstwDataBaseMain.Items.Count - 1)
                    {
                        index = 0;
                        lstwDataBaseMain.Items[index].Selected = true;
                    }
                    else
                    {
                        if (index < lstwDataBaseMain.Items.Count - 1)
                        {
                            index += 1;
                            lstwDataBaseMain.Items[index].Selected = true;
                        }
                    }

                    lstwDataBaseMain.EnsureVisible(index);          //показать в области видимости окна
                    lstwDataBaseMain.HideSelection = false;         //оставить выделение строки при потере фокуса ListView                }
                }
            }
        }
        //Добавить/Обновить запись в БД
        void WriteRecord(DateTime regDate, DateTime vDateIn, DateTime vDateOut, int vSpID, string vSpDateIn, string vSpDateOut, string vSpNote)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            int index = lstwDataBaseMain.extSelectedIndex();                //сохранить индекс текущей строки
            string keyUser = lstwDataBaseMain.Items[index].SubItems[2].Text;//ключевое поле внешний id пользователя
            string keyDate = regDate.ToString("yyyyMMdd");  //mcRegDate.SelectionStart.ToString("yyyyMMdd"); //ключевое поле дата прохода

            string pacsTimeStart = "";                                      //строка Дата Время прохода СКУД
            string pacsTimeStop = "";                                       //строка Дата Время выхода СКУД

            int chLunch = lstwDataBaseMain.Items[index].SubItems[11].Text == "1" ? 0 : 60;  //0 мин не обедает 60 мин обедает
            int wScheme = lstwDataBaseMain.Items[index].SubItems[12].Text == "1" ? 1 : 0;   //1 режим почасовой 0 режим поминутный
            double timeScheduleFact = (vDateOut - vDateIn).TotalMinutes;                           //Всего минут по факту 

            int extMin = pCalendar.getLengthWorkHoliday(vDateIn);           //количество минут для короткого длинного и обычного дня     
            //------------------------
            double cMin = timeScheduleFact;
            double tempMin = cMin;                                          //Сохраним текущее время
            switch (wScheme)                                                 //Тариф    
            {
                case 1:                                                     //Почасовой
                    cMin -= chLunch;                                        //Учитывая Обед
                    //! исключения сокращенный день только для полной занятости
                    cMin = cMin < 0 ? tempMin : cMin;                       //Если ушли в минус вернемся обратно
                    tempMin = cMin;                                         //Сохраним текущее время
                    //!!!!! Плюс потому что секретарь отмечает фактическое время ухода а человек уходит раньше на час за счет праздника
                    cMin += extMin;                                   //Учтем Сокращенный Предпраздничный День
                    //!!!!! Поэтому этот ранний уход компенсируем добавляя час из сокращенного времени
                    cMin = cMin < 0 ? tempMin : cMin;                       //Если ушли в минус вернемся обратно
                    break;
                case 0:                                                     //Поминутный
                    cMin = cMin >= 300 ? cMin - chLunch : cMin;             //Если студент отработал больше чем 4 часа (Учитываем Обед)
                    break;
            }
            double timeScheduleWithoutLunch = cMin;                         //За минусом обеда и сокращений
            //------------------------
            double timeScheduleLess;                                        //Недоработка
            double timeScheduleOver;                                        //Переработка

            if (cMin == 0)
            {
                timeScheduleLess = 0;                                       //Недоработка
                timeScheduleOver = 0;                                       //Переработка
            }
            else
            {
                double dMin = (8 * 60) + extMin;                            //Прочитать количество рабочих часов в дне по календарю
                if (cMin < dMin)                                            //Недоработка
                    timeScheduleLess = dMin - cMin;
                else
                    timeScheduleLess = 0;

                if (cMin > dMin)                                            //Переработка
                    timeScheduleOver = cMin - dMin;
                else
                    timeScheduleOver = 0;
            }
            //------------------------
            int specmarkId = vSpID;// (int)((DataRowView)cbSMarks.SelectedItem).Row["id"];   //код спец отметок
//            string specmarkTimeStart = cbSMarks.Text == "-" ? "" : smDStart.Value.ToString("yyyy-MM-dd") + " " + smTStart.Value.ToString("HH:mm"); //строка Дата начала спец. отметок 
//            string specmarkTimeStop = cbSMarks.Text == "-" ? "" : smDStop.Value.ToString("yyyy-MM-dd") + " " + smTStop.Value.ToString("HH:mm");  //строка Дата окончания спец. отметок
            string specmarkTimeStart;   //строка Дата начала спец. отметок 
            string specmarkTimeStop;  //строка Дата окончания спец. отметок
            string specmarkNote = vSpNote;// tbNote.Text.Trim();                       //Комментарий спец отметок
            //------------------------
            //формулы
            double totalHoursInWork;
            double totalHoursOutsideWork=0;
            DateTime dMainBg;
            DateTime dMainEn; 
            DateTime dSpecBg;
            DateTime dSpecEn;

            if (vSpID == 1) 
            {
                specmarkTimeStart = "NULL";
                specmarkTimeStop = "NULL";

                totalHoursInWork = 0;                                       //Итоги. Время всего
                totalHoursOutsideWork = 0;                                  //Итоги. Вне рабочего дня
            }
            else
            {
                specmarkTimeStart = "'" + DateTime.Parse(vSpDateIn).ToString("yyyyMMdd HH:mm") + "'";
                specmarkTimeStop = "'" + DateTime.Parse(vSpDateOut).ToString("yyyyMMdd HH:mm") + "'"; ;

                //приведем все к одной дате
                dMainBg = DateTime.Parse("1984-05-22" + " " + vDateIn.ToString("HH:mm"));                   //Начало Факт
                dMainEn = DateTime.Parse("1984-05-22" + " " + vDateOut.ToString("HH:mm"));                  //Конец Факт
                dSpecBg = DateTime.Parse("1984-05-22" + " " + DateTime.Parse(vSpDateIn).ToString("HH:mm")); //Начало Спец
                dSpecEn = DateTime.Parse("1984-05-22" + " " + DateTime.Parse(vSpDateOut).ToString("HH:mm"));//Конец Спец

                totalHoursInWork = Math.Abs((dSpecEn - dSpecBg).TotalMinutes);                                   //Итоги. Время всего

                //если диапазоны не пересекаются (Итоги. Вне рабочего дня)
                if ((dSpecEn < dMainBg && dSpecEn <= dMainBg) || (dSpecBg >= dMainEn && dSpecEn > dMainEn))
                    totalHoursOutsideWork = Math.Abs((dSpecEn - dSpecBg).TotalMinutes);  //берем все время диапазона спец отметок
                //если нос спецотметок входит в основное время
                if (dSpecBg < dMainBg && (dSpecEn > dMainBg && dSpecEn <= dMainEn))
                    totalHoursOutsideWork = Math.Abs((dSpecBg - dMainBg).TotalMinutes);  //разница между началами диапазонов
                //если хвост спецотметок задержался в основном времени
                if ((dSpecBg >= dMainBg && dSpecBg < dMainEn) && dSpecEn > dMainEn)
                    totalHoursOutsideWork = Math.Abs((dSpecEn - dMainEn).TotalMinutes);  //разница между концами диапазонов
                //если диапазон внутри основного времени - не считаем
                if (dSpecBg >= dMainBg && dSpecEn <= dMainEn) 
                    totalHoursOutsideWork = 0;                                      //спец диапазон входит в фактический диапазон
              }
            //------------------------
            string sql =
              "UPDATE EventsPass Set " +
                "author = " + "N'" + Environment.UserName.ToString() + "', " +
                "passTimeStart = " + "'" + vDateIn.ToString("yyyyMMdd") + "', " +
                "passTimeStop = " + "'" + vDateOut.ToString("yyyyMMdd") + "', " +
                "pacsTimeStart = " + (pacsTimeStart == "" ? "NULL" : "'" + pacsTimeStart + "'") + ", " +
                "pacsTimeStop = " + (pacsTimeStop == "" ? "NULL" : "'" + pacsTimeStop + "'") + ", " +
                "timeScheduleFact = " + timeScheduleFact + ", " +
                "timeScheduleWithoutLunch = " + timeScheduleWithoutLunch + ", " +
                "timeScheduleLess = " + timeScheduleLess + ", " +
                "timeScheduleOver = " + timeScheduleOver + ", " +
                "specmarkId = " + specmarkId + ", " +
                "specmarkTimeStart = " + specmarkTimeStart + ", " +
                "specmarkTimeStop = " + specmarkTimeStop + ", " +
                "specmarkNote = " + "N'" + specmarkNote + "', " +
                "totalHoursInWork = " + totalHoursInWork + ", " +
                "totalHoursOutsideWork = " + totalHoursOutsideWork + " " +
              "WHERE passDate = '" + regDate.ToString("yyyyMMdd") + "' " +                   //*дата прохода
                "and passId = '" + keyUser + "' ; " +                   //*внешний id сотрудника
              "IF @@ROWCOUNT = 0 " +
              "INSERT INTO EventsPass(" +
                    "author, " +                                    //имя учетной записи сеанса
                    "passDate, " +                                  //*дата события (без времени)
                    "passId, " +                                    //*внешний id пользователя
                    "passTimeStart, " +                             //время первого входа (без даты)
                    "passTimeStop, " +                              //время последнего выхода (без даты)
                    "pacsTimeStart, " +                             //время первого входа по СКУД (без даты)
                    "pacsTimeStop, " +                              //время последнего выхода по СКУД (без даты)
                    "timeScheduleFact, " +                          //отработанное время (мин)
                    "timeScheduleWithoutLunch, " +                  //отработанное время без обеда (мин)
                    "timeScheduleLess, " +                          //время недоработки (мин)
                    "timeScheduleOver, " +                          //время переработки (мин)
                    "specmarkId, " +                                //->ссылка на специальные отметки
                    "specmarkTimeStart, " +                         //датавремя начала действия специальных отметок
                    "specmarkTimeStop, " +                          //датавремя окончания специальных отметок
                    "specmarkNote, " +                              //комментарий к специальным отметкам
                    "totalHoursInWork, " +                          //итог рабочего времени в графике (мин)
                    "totalHoursOutsideWork) " +                     //итог рабочего времени вне графика (мин)
                  "VALUES (" +
                    "N'" + Environment.UserName.ToString() + "', " +
                    "'" + regDate.ToString("yyyyMMdd") + "', " + // mcRegDate.SelectionStart.ToString("yyyyMMdd") + "', " +
                    "'" + keyUser + "', " +
                    "'" + vDateIn.ToString("yyyyMMdd") + "', " +
                    "'" + vDateOut.ToString("yyyyMMdd") + "', " +
                    (pacsTimeStart == "" ? "NULL" : "'" + pacsTimeStart + "'") + ", " +
                    (pacsTimeStop == "" ? "NULL" : "'" + pacsTimeStop + "'") + ", " +
                    timeScheduleFact + ", " +
                    timeScheduleWithoutLunch + ", " +
                    timeScheduleLess + ", " +
                    timeScheduleOver + ", " +
                    specmarkId + ", " +
                    specmarkTimeStart + ", " +
                    specmarkTimeStop + ", " +
                    "N'" + specmarkNote + "', " +
                    totalHoursInWork + ", " +
                    totalHoursOutsideWork +
                  ")";

            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadListUser(clMsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + keyDate + "','') order by fio"));
            lstwDataBaseMain.Items[index].Selected = true;
            lstwDataBaseMain.HideSelection = false;                         //оставить выделение строки при потере фокуса ListView
            lstwDataBaseMain.EnsureVisible(index);                          //показать в области видимости окна
        }
        //кнопка удалить запись в БД
        private void btDelete_Click(object sender, EventArgs e)
        {
            int index = lstwDataBaseMain.extSelectedIndex();                //сохранить индекс текущей строки
            string keyUser = lstwDataBaseMain.Items[index].SubItems[2].Text;//ключевое поле внешний id пользователя
            string keyDate = mcRegDate.SelectionStart.ToString("yyyyMMdd"); //ключевое поле дата прохода

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            string sql =
              "DELETE FROM EventsPass " +
              "WHERE passDate = '" + keyDate + "' " +                       //*дата прохода
                    "and passId = '" + keyUser + "'";                       //*внешний id сотрудника
            clMsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadListUser(clMsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + keyDate + "','') order by fio"));
            lstwDataBaseMain.Items[index].Selected = true;
            lstwDataBaseMain.HideSelection = false;                         //оставить выделение строки при потере фокуса ListView
            lstwDataBaseMain.EnsureVisible(index);                          //показать в области видимости окна
        }
        //обновить имя главного окна
        private void reloadCaption() 
        {
            if (userType)
                this.Text = "Учет рабочего времени (Администратор) " + Properties.Settings.Default.companyName;
            else
                this.Text = "Учет рабочего времени (Регистратор) " + Properties.Settings.Default.companyName;
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
        //обновить общие настройки 
        private void CallbackSetting(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            reloadCaption();                            //Обновить имя главного окна
        }
        //обновить настройки после импорта (список юзеров в главном окне)
        private void CallbackImport(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            LoadListUser(clMsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));
            mainPanelRegistration.Enabled = lstwDataBaseMain.Items.Count > 0;
        }
        //проверить кто будет работать с программой
        private void CallbackLogIn(string typeLogIn, string controlParentName, Dictionary<String, String> param)
        {
            switch (typeLogIn)
            {
                case "Администратор":
                    userType = true;
                    toolSetting.Visible = true;
                    break;
                case "Пользователь":
                    userType = false;
                    toolSetting.Visible = false;
                    break;
            }
            reloadCaption();                            //Обновить имя главного окна
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
