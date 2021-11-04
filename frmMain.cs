﻿using System;
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
        DataTable dtWorkCalendar;                                           //производственный календаоь

        public frmMain()
        {
            //подписка события внешних форм 
            CallBack_FrmDataBaseSQL_outEvent.callbackEventHandler = new CallBack_FrmDataBaseSQL_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            CallBack_FrmDataBasePACS_outEvent.callbackEventHandler = new CallBack_FrmDataBasePACS_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            CallBack_FrmUsers_outEvent.callbackEventHandler = new CallBack_FrmUsers_outEvent.callbackEvent(this.CallbackCheckListUsers);    //subscribe (listen) to the general notification

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
            if (CheckConnects())                                //проверить соединение с базами
            {
                dtWorkCalendar = MsSqlDatabase.TableRequest(cs, "Select * From twt_GetDateInfo('', '') order by dWork");
                LoadBoldedDatesCalendar(dtWorkCalendar);        //Загрузить производственный календарь в массив непериодических выделенных дат
                getDateInfo(DateTime.Now, dtWorkCalendar);      //прочитать харектеристики дня по производственному календарю 

                cbSMarks.DisplayMember = "Name";
                cbSMarks.ValueMember = "id";
                cbSMarks.DataSource = MsSqlDatabase.TableRequest(cs, "Select id, name From SpecialMarks where uses=1");

                InitializeListView();
                LoadListUser(MsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));
                mainPanelRegistration.Enabled = lstwDataBaseMain.Items.Count > 0;
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
                        ImageIndex = (int)drow["used"]
                        , StateImageIndex = (int)drow["used"]
                        , Checked = (int)drow["used"]==1
                        //                        , UseItemStyleForSubItems = true
                    };
                    lvi.SubItems.Add(drow["fio"].ToString());
                    lvi.SubItems.Add(drow["extId"].ToString());
                    lvi.SubItems.Add(drow["gtStart"].ToString());
                    lvi.SubItems.Add(drow["gtStop"].ToString());
                    lvi.SubItems.Add(drow["specmarkId"].ToString());
                    lvi.SubItems.Add(drow["stSatrt"].ToString());
                    lvi.SubItems.Add(drow["stStop"].ToString());
                    lvi.SubItems.Add(drow["specmarkNote"].ToString());
                    lvi.SubItems.Add(drow["ptSart"].ToString());
                    lvi.SubItems.Add(drow["ptStop"].ToString());

                    lstwDataBaseMain.Items.Add(lvi);       // Add the list items to the ListView
                }
            }
            //после загрузки списка установить авторазмер последней колонки
            lstwDataBaseMain.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);      //растягиваем последний столбец

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

        //выбор значения из списка инициализация переменных формы
        private void lstwDataBaseMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dt;
            int ind = lstwDataBaseMain.SelectedIndex();
            if (ind >= 0)
            {
 //               tbExtID.Text = lstwDataBaseUsers.Items[ind].SubItems[2].Text;                 //extID
                //crmId
 //               chUse.Checked = lstwDataBaseUsers.Items[ind].Text == "True";                  //access    
                tbName.Text = lstwDataBaseMain.Items[ind].SubItems[1].Text;                     //fio
                if (lstwDataBaseMain.Items[ind].Text == "0")                                        
                {                                                                               //данных о проходе нет           
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[3].Text);
                    udBeforeH.Value = dt;
                    udBeforeM.Value = dt;
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[4].Text);
                    udAfterH.Value = dt;
                    udAfterM.Value = dt;

                    btInsert.Enabled = true;                                                    //разблокировать кнопку INSERT    
                    btUpdate.Enabled = false;                                                   //заблокировать кнопку UPDATE  
                }
                else
                {                                                                               //данные о проходе есть
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[9].Text);
                    udBeforeH.Value = dt;
                    udBeforeM.Value = dt;
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[10].Text);
                    udAfterH.Value = dt;
                    udAfterM.Value = dt;

                    cbSMarks.SelectedValue = lstwDataBaseMain.Items[ind].SubItems[4].Text;      //выбор по id

                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[6].Text);
                    smDStart.Value = dt;
                    smTStart.Value = dt;
                    dt = Convert.ToDateTime(lstwDataBaseMain.Items[ind].SubItems[7].Text);
                    smDStop.Value = dt;
                    smTStop.Value = dt;

                    tbNote.Text = lstwDataBaseMain.Items[ind].SubItems[8].Text;                 //комментарий

                    btInsert.Enabled = false;                                                   //заблокировать кнопку INSERT    
                    btUpdate.Enabled = true;                                                    //разблокировать кнопку UPDATE  
                }


                /*
                                tbNote.Text = lstwDataBaseUsers.Items[ind].SubItems[9].Text;                    //note
                                cbDepartment.Text = lstwDataBaseUsers.Items[ind].SubItems[3].Text;              //department    
                                cbPost.Text = lstwDataBaseUsers.Items[ind].SubItems[4].Text;                    //post

                                chbLunch.Checked = lstwDataBaseUsers.Items[ind].SubItems[7].Text == "True";     //lunch
                                cbSheme.Text = lstwDataBaseUsers.Items[ind].SubItems[8].Text;                   //work    
                                tbCrmID.Text = lstwDataBaseUsers.Items[ind].SubItems[10].Text;                  //crmID
                */
            }
        }



        //Загрузить Производственный календарь Data из DataSet в Calendar
        private void LoadBoldedDatesCalendar(DataTable dtable)
        {
            mcRegDate.RemoveAllBoldedDates();                           //Сбросить все непериодические даты
            for (int i = 0; i < dtable.Rows.Count; i++)                 //Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)              //Only row that have not been deleted
                {
                    mcRegDate.AddBoldedDate((DateTime)drow["dWork"]);
                }
            }
            mcRegDate.UpdateBoldedDates();
        }

        //проверить соединение с базами
        private bool CheckConnects()
        {
            //проверка соединения с SQL
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            bool conSQL = MsSqlDatabase.CheckConnectWithConnectionStr(cs);
            this.tsbtDataBaseSQL.Image = conSQL ? Properties.Resources.ok : Properties.Resources.no;
            mainPanelRegistration.Enabled = conSQL && lstwDataBaseMain.Items.Count>0;
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
                                     DateTime.Parse(smDStop.Value.ToString("yyyy-MM-dd ") + smTStop.Value.ToString("HH:mm "))) > 0)
                {
                    //                    MessageBox.Show("Дата/Время окончания периода должно быть боольше Даты/Времени начала периода","Ошибка установки диапазона дат",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    smDStop.Value = smDStart.Value;
                    smTStop.Value = smDStart.Value.AddHours(1);
                }
            }
        }

        //изменение даты в календаре
        private void mcRegDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            getDateInfo(e.Start, dtWorkCalendar);
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            LoadListUser(MsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));

            /*
            var firstDayOfMonth = new DateTime(e.Start.Year, e.Start.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            double bd = getBusinessDays(firstDayOfMonth, lastDayOfMonth);
            lbBusinessDayCount.Text = "рабочих дней - " + bd.ToString();

            if (e.Start.DayOfWeek == DayOfWeek.Monday)
            {
                MessageBox.Show("I hate mondays");
                mcRegDate.SelectionStart = e.Start.AddDays(1);
            }
            */
        }
        private void mcRegDate_DateSelected(object sender, DateRangeEventArgs e)
        {
//            getDateInfo(e.Start, dtWorkCalendar);
 //           lbDay.Text = inf[0].ToString();
        }

        //прочитать харектеристики дня по производственному календарю 
        private void getDateInfo(DateTime dayInfo, DataTable dtable)
        {
            bool check = false;
            lbDayValue.Text = dayInfo.ToString("dd-MM-yyyy");
            for (int i = 0; i < dtable.Rows.Count; i++)             //Display items in the ListView control
            {
                DataRow drow = dtable.Rows[i];
                if (                                                //если день совпадает с днем из производственного кадендаря
                    (drow.RowState != DataRowState.Deleted) &&
                    ((DateTime.Compare((DateTime)drow["dWork"], dayInfo) == 0) ||
                     (DateTime.Compare((DateTime)drow["dSource"], dayInfo) == 0))
                    )   //Only row that have not been deleted
                {
                    check = true;
                    if (DateTime.Compare((DateTime)drow["dWork"], (DateTime)drow["dSource"]) == 0)
                    {                                               //если дата без переносов
                        lbDay.Text = drow["dName"].ToString() +      //наименование дня из производственного календаря
                            "\r\n(" + drow["dType"].ToString().ToLower() + ")";
                        pbDay.Visible = true;
                    }
                    else
                    {                                               //дата с переносом
                        if (DateTime.Compare((DateTime)drow["dWork"], dayInfo) == 0)
                        {                                           //это перенесенная дата
//                            lbDay.Text = dayInfo.DayOfWeek == DayOfWeek.Saturday || dayInfo.DayOfWeek == DayOfWeek.Sunday ? "Выходной день" : "Рабочий день";// drow["dName"].ToString();
//                            lbDay.Text = drow["dName"].ToString();  //наименование дня из производственного календаря
                            lbDay.Text = "Нерабочий день" +
                                "\r\n(" + drow["dType"].ToString().ToLower() + ")" +
                                "\r\n\r\n" + "Перенесено с даты\r\n  " + ((DateTime)drow["dSource"]).ToString("dd.MM.yyyy г.") + "\r\n" + drow["dName"].ToString();
                            pbDay.Visible = true;
                        }
                        else
                        {                                           //это реальный праздник
                            //дополнительная прверка на дату реального праздника
                            
                            if (dayInfo.DayOfWeek == DayOfWeek.Saturday || dayInfo.DayOfWeek == DayOfWeek.Sunday)
                            {                                       //праздник попадает на выходной
                                lbDay.Text = "Выходной день" +
                                "\r\n(" + drow["dType"].ToString().ToLower() + ")" +
                                "\r\n\r\n" + "Перенесено на дату\r\n  " + ((DateTime)drow["dWork"]).ToString("dd.MM.yyyy г.") + "\r\n" + drow["dName"].ToString();
                                pbDay.Visible = false;
                            }
                            else
                            {                                       //праздник не попадает на выходной
                                lbDay.Text = "Рабочий день" +
                                "\r\n(" + drow["dType"].ToString().ToLower() + ")" +
                                "\r\n\r\n" + "Перенесено на дату\r\n  " + ((DateTime)drow["dWork"]).ToString("dd.MM.yyyy г.") + "\r\n" + drow["dName"].ToString();
                                pbDay.Visible = false;
                            }

                        }
                    }
                }
            }
            if (!check) 
            {
                lbDay.Text = dayInfo.DayOfWeek == DayOfWeek.Saturday || dayInfo.DayOfWeek == DayOfWeek.Sunday? "Выходной день":"Рабочий день";
                pbDay.Visible = false;
            }

        }

        //подсчитать количество рабочих дней
        private static double getBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
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
        //обновить список юзеров в главном окне
        private void CallbackCheckListUsers(string controlName, string controlParentName, Dictionary<String, String> param)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            LoadListUser(MsSqlDatabase.TableRequest(cs, "select * from twt_GetPassFormData('" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "','') order by fio"));
            mainPanelRegistration.Enabled = lstwDataBaseMain.Items.Count > 0;
        }

        //кнопка Добавить/Обновить запись в БД
        private void btInsert_Click(object sender, EventArgs e)
        {
            DateTime vDate = DateTime.Parse(mcRegDate.SelectionStart.ToString("yyyyMMdd")); //Чистая дата без времени
            DateTime vDateIn; 
            DateTime vDateOut;
            string vSpDateIn="";
            string vSpDateOut="";
            int spCount=0;
            string msg = "";
            DialogResult result= DialogResult.Yes;


            if (cbSMarks.Text == "-")
            {
                vDateIn = DateTime.Parse(vDate.ToString("yyyyMMdd") + " " + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm")); //+ Время прихода
                vDateOut = DateTime.Parse(vDate.ToString("yyyyMMdd") + " " + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm"));  //+ Время ухода
                WriteRecord(vDateIn, vDateOut, "-", "-");                   //Просто рабочий день
            }
            else 
            {
                vSpDateIn = smDStart.Value.ToString("yyyyMMdd") + " " + smTStart.Value.ToString("HH:mm");   //Дата начала спец. отметок
                vSpDateOut = smDStop.Value.ToString("yyyyMMdd") + " " + smTStop.Value.ToString("HH:mm");    //Дата окончания спец. отметок
                spCount = (DateTime.Parse(vSpDateOut) - DateTime.Parse(vSpDateIn)).Days; 
            }

            if (spCount == 0)
            {
                vDate = DateTime.Parse(vSpDateIn);       //Чистая дата без времени
                vDateIn = DateTime.Parse(vDate.ToString("yyyyMMdd") + " " + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm")); //+ Время прихода
                vDateOut = DateTime.Parse(vDate.ToString("yyyyMMdd") + " " + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm"));  //+ Время ухода

                result = DialogResult.Yes;
                msg = "";
                if (mcRegDate.SelectionStart.ToString("yyyyMMdd") != DateTime.Parse(vSpDateIn).ToString("yyyyMMdd"))
                {
                    msg = "Обратите внимание" + "\r\n" + "\r\n" +
                        mcRegDate.SelectionStart.ToString("dd.MM.yyyy") + " - текущая Дата Регистрации" + "\r\n" +
                        DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + " - Дата начала Специальных отметок" + "\r\n" +
                        "не совпадают" + "\r\n" +
                        "*данные будут записаны на Дату начала Специальных отметок" + "\r\n" + "\r\n" +
                        "Продолжить?" + "\r\n";

                    result = MessageBox.Show(
                        "Добавить запись",
                        msg,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly
                        );
                }

                if (result == DialogResult.Yes)
                    WriteRecord(vDateIn, vDateOut, vSpDateIn, vSpDateOut);              //Просто рабочий день
            }
            else 
            {
                string timeIn = lstwDataBaseMain.Items[lstwDataBaseMain.SelectedIndex()].SubItems[3].Text;  //Время начала работы
                string timeOut = lstwDataBaseMain.Items[lstwDataBaseMain.SelectedIndex()].SubItems[4].Text; //Время окончания работы

                result = DialogResult.Yes;
                msg = "";
                //-- обработка ошибок
                if (mcRegDate.SelectionStart.ToString("yyyyMMdd") != DateTime.Parse(vSpDateIn).ToString("yyyyMMdd"))
                {
                    msg = "Обратите внимание" + "\r\n" + "\r\n" +
                        mcRegDate.SelectionStart.ToString("dd.MM.yyyy") + " - текущая Дата Регистрации" + "\r\n" +
                        DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + " - Дата начала Специальных отметок" + "\r\n" +
                        "не совпадают" + "\r\n" +
                        "*данные будут записаны на Дату начала Специальных отметок" + "\r\n" + "\r\n" +
                        "Продолжить?" + "\r\n";
                }
                msg = msg + DateTime.Parse(vSpDateIn).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(vSpDateOut).ToString("dd.MM.yyyy") +
                        " - период действия Специальных отметок превышает одни сутки" + "\r\n" +
                        "*данные будут записаны на данный период с использованием времени из графика сотрудника " +
                        timeIn + "-" + timeOut + "\r\n" + "\r\n" +
                        "Продолжить?" + "\r\n";

                result = MessageBox.Show(
                        "Добавить запись",
                        msg,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly
                        );
                //-- обработка ошибок
                if (result == DialogResult.Yes) 
                {
                    for (int i = 0; i < spCount; i++)                           //цикл по всем датам диапазона спец отметок начиная со следующего дня 
                    {
                        vDate = DateTime.Parse(vSpDateIn).AddDays(i);           //смещение на день

                    }
                }




            }
            /*
                  Else

                    If response = vbYes Then 'vbOK Then   ' User chose Yes.
                      For i = 0 To spCount                                                      ' цикл по всем датам диапазона начиная со следующего дня
                        vDate = ClearDataString(DateAdd("d", i, vSpDateIn))                     ' смещение на день
                        vDateIn = CDate(vDate & " " & FormatDateTime(CDate(timeIn), vbShortTime))     '  + Время начала из графика
                        vDateOut = CDate(vDate & " " & FormatDateTime(CDate(timeOut), vbShortTime))    '  + Время окончания из графика
            '            If Not GetHolyday(ActiveWorkbook, CDate(vDate)) Then
                        If Not GetHolyday(ThisWorkbook, CDate(vDate)) Then

                          Call WriteRecord(vDateIn, vDateOut, vSpDateIn, vSpDateOut)            ' Просто рабочий (не праздничный не выходной) день
                        End If
                      Next
                    End If
                  End If
                End If


                  'сортировка по 3,5 колоке
                With Worksheets("DataBase").ListObjects("Data")
                  .Sort.SortFields.Clear
            '      .Sort.SortFields.Add Key:=.ListColumns(4).Range, SortOn:=xlSortOnValues, Order:=xlAscending, DataOption:=xlSortNormal
                  .Sort.SortFields.Add.ListColumns(3).Range, , xlDescending, , xlSortNormal
            '      .Sort.SortFields.Add .ListColumns(5).Range, , xlAscending, , xlSortNormal
                  .Sort.Apply
                End With


                'перемещение по списку
                If btRegAdd.Caption <> "Обновить" Then
                  If cdDirect.Value = "слева направо" Then                                      ' слева направо
                    sbDate.Value = sbDate.Value + 1
                    tbDate.Value = ClearDataString(DateValue(tbDate.Value) + 1)
                    Call ChangeTime
                    vDate = ClearDataString(tbDate.Value)                                       ' Чистая дата без времени
                  Else                                                                          ' Сверху вниз
                    If lbUsers.ListIndex = lbUsers.ListCount - 1 Then
                      lbUsers.ListIndex = 0
                    Else
                      lbUsers.ListIndex = lbUsers.ListIndex + 1
                    End If
                  End If
                End If
            */
        }

        //Добавить/Обновить запись в БД
        private void WriteRecord(DateTime vDateIn, DateTime vDateOut, string vSpDateIn, string vSpDateOut)
        {
            string key = DateTime.Now.ToString("yyyyMMddHHmmss");           //ключевое поле
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            /*
                                    "id bigint PRIMARY KEY IDENTITY, " +
                                    "author VARCHAR(150) NOT NULL, " +                                          //имя учетной записи сеанса
                                    "passDate Datetime NOT NULL, " +                                                //*дата события (без времени) 
                                    "passId VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Users(extId), " +       //*->ссылка на внешний id пользователя
                                    "passTimeStart Datetime NOT NULL, " +                                           //время первого входа (без даты)
                                    "passTimeStop Datetime NOT NULL, " +                                            //время последнего выхода (без даты)
                                    "infoLunchId bit DEFAULT 1, " +                                             //флаг признака обеда
                                    "infoWorkSchemeId int NULL FOREIGN KEY REFERENCES UserWorkScheme(id), " +   //->ссылка на схему работы
                                    "timeScheduleFact int DEFAULT 0, " +                                        //отработанное время (мин)
                                    "timeScheduleWithoutLunch int DEFAULT 0, " +                                //отработанное время без обеда (мин)
                                    "timeScheduleLess int DEFAULT 0, " +                                        //время недоработки (мин)
                                    "timeScheduleOver int DEFAULT 0, " +                                        //время переработки (мин)
                                    "specmarkId int NOT NULL FOREIGN KEY REFERENCES SpecialMarks(id), " +       //->ссылка на специальные отметки
                                    "specmarkTimeStart Datetime NULL, " +                                       //датавремя начала действия специальных отметок
                                    "specmarkTimeStop Datetime NULL, " +                                        //датавремя окончания специальных отметок
                                    "specmarkNote VARCHAR(1024) NULL, " +                                       //комментарий к специальным отметкам
                                    "totalHoursInWork int DEFAULT 0, " +                                        //итог рабочего времени в графике (мин)
                                    "totalHoursOutsideWork int DEFAULT 0" +                                     //итог рабочего времени вне графика (мин)
                                    "UNIQUE(passDate, passId) " +                                               //уникальность на уровне таблицы

             */
            /*
            string sql =
              "UPDATE EventsPass Set " +
                "departmentId = " + departmentId + ", " +
                "postId = " + postId + ", " +
                "timeStart = " + "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                "timeStop = " + "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                "noLunch = " + ((Boolean)meta[6] ? 1 : 0) + ", " +
                "workSchemeId = " + workSchemeId + ", " +
                "uses = " + ((Boolean)meta[8] ? 1 : 0) + " " +
                "WHERE extId = '" + meta[0].ToString() + "' and name = '" + meta[3].ToString() + "'; " +
              "IF @@ROWCOUNT = 0 " +
              "INSERT INTO EventsPass(" +
                "author, " +
                "passDate, " +
                "passId, " +
                "passTimeStart, " +
                "passTimeStop, " +
                "infoLunchId, " +
                "infoWorkSchemeId, " +
                "timeScheduleFact, " +
                "timeScheduleWithoutLunch, " +
                "timeScheduleLess, " +
                "timeScheduleOver, " +
                "specmarkId, " +
                "specmarkTimeStart, " +
                "specmarkTimeStop, " +
                "specmarkNote, " +
                "totalHoursInWork, " +
                "totalHoursOutsideWork) " +
              "VALUES (" +
                "N'" + Environment.UserName.ToString() + "', " +                                         //
                "'" + mcRegDate.SelectionStart.ToString("yyyyMMdd") + "', " +
                "'" + lstwDataBaseMain.Items[lstwDataBaseMain.SelectedIndex()].SubItems[2].Text + "', " +
                "'" + udBeforeH.Value.ToString("HH") + ":" + udBeforeM.Value.ToString("mm") + "', " +
                "'" + udAfterH.Value.ToString("HH") + ":" + udAfterM.Value.ToString("mm") + "', " +

                0 + ", " +
                "N'" + tbName.Text.Trim() + "', " +
                "N'" + tbNote.Text.Trim() + "', " +
                ((DataRowView)cbDepartment.SelectedItem).Row["id"] + ", " +
                ((DataRowView)cbPost.SelectedItem).Row["id"] + ", " +
                (chbLunch.Checked ? 1 : 0) + ", " +
                ((DataRowView)cbSheme.SelectedItem).Row["id"] + ", " +
                (chUse.Checked ? 1 : 0) +
              ")";
            MsSqlDatabase.RequestNonQuery(cs, sql, false);

            LoadList(MsSqlDatabase.TableRequest(cs, "select * from twt_GetUserInfo('') order by fio"));// order by extId desc"));
            lstwDataBaseUsers.FindListByColValue(2, key);                   //найти и выделить позицию
            tbName_TextChanged(null, null);                                 //обновить поля и кнопки
*/
        }


        private void btUpdate_Click(object sender, EventArgs e)
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
