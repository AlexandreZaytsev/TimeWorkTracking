using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;



//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;

namespace TimeWorkTracking
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            //подписка события внешних форм 
            CallBack_FrmMain_outEvent.callbackEventHandler = new CallBack_FrmMain_outEvent.callbackEvent(this.CallbackReload);    //subscribe (listen) to the general notification
            InitializeComponent();
            InitializeBackgroundWorker();
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?redirectedfrom=MSDN&view=net-5.0
        //https://www.bestprog.net/ru/2021/03/28/c-control-component-backgroundworker-ru/
        //https://www.bestprog.net/ru/2021/03/31/c-windows-forms-the-backgroundworker-control-displays-the-progress-of-completed-work-canceling-the-execution-of-a-thread-ru/
        //Настройка объекта BackgroundWorker добавим свои события.
        private void InitializeBackgroundWorker()
        {
            backgroundWorkerSetting.DoWork += new DoWorkEventHandler(backgroundWorkerSetting_DoWork);
            backgroundWorkerSetting.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerSetting_ProgressChanged);
            backgroundWorkerSetting.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSetting_RunWorkerCompleted);
            backgroundWorkerSetting.WorkerReportsProgress = true;       //Разрешить использовать событие по отображению прогресса
            backgroundWorkerSetting.WorkerSupportsCancellation = true;  //Разрешить использовать средства остановки(отмены выполнения) потока.
//            backgroundWorkerSetting.GenerateMember = true;              
        }

        //Событие возникает после запуска потока методом RunAsync()
        //В обработчик этого события вписывается код выполнения потока.
        private void backgroundWorkerSetting_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;           //передать объект (BackgroundWorker) вызвавший данное событие

            List<string> arg = e.Argument as List<string>;
            //Назначить результат вычисления к свойству результата DoWorkEventArgs объект.
            //Это будет доступно обработчику событий RunWorkerCompleted.
            switch (arg[0])   // the 'argument' parameter resurfaces here
            {
                case "users":
                    e.Result = ImportUserDataFromExcel(worker, e);
                    break;
                case "pass":
                    e.Result = ImportPassDataFromExcel(worker, e);
                    break;
            }
        }

        //Событие возникает когда происходит завершение потока выполнения
        //В обработчик этого события целесообразно вписывать код завершающих операций, вывод соответствующих сообщений и т.п.
        private void backgroundWorkerSetting_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        //    List<string> arg = e.Argument as List<string>;
            // Проверить как завершился поток с ошибками или без
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                toolStripStatusLabelInfo.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                toolStripStatusLabelInfo.Text = ""; //e.Result.ToString();
                toolStripProgressBarImport.Value = 0;
                switch (e.Result.ToString())                
                {
                    case "users":                                                           //если завершился иморт пользователей
                        CallBack_FrmImport_outEvent.callbackEventHandler("", "", null);     //отправитьс ообщение главной форме что импрот произошел
                        break;
                    case "pass":                                                            //если завершился иморт проходов
                        break;
                }
            }
        }

        //Событие возникает, когда рабочий поток указывает на то, что был достигнут некоторый прогресс
        //вызывается из DoWork запуском ReportProgress которое вызывает данное событие
        //В обработчике события ProgressChanged указывается код визуализации прогресса с помощью известных компонент, таких как ProgressBar, Label и т.д.;
        private void backgroundWorkerSetting_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<string> arg = e.UserState as List<string>;
            switch (arg[0])
            {
                case "init":                                                //инициализируем прогрессбар
                    toolStripProgressBarImport.Minimum = Convert.ToInt32(arg[1]);
                    toolStripProgressBarImport.Maximum = Convert.ToInt32(arg[2]);
                    toolStripProgressBarImport.Step = Convert.ToInt32(arg[3]);
                    toolStripStatusLabelInfo.Text = arg[4];
                    break;
                case "work":                                                //двигаем прогрессбар
                    //Задать изменение процента в progressBar
                    toolStripProgressBarImport.PerformStep();               //сдвинуться на шаг
                    //toolStripProgressBarImport.Value = e.ProgressPercentage;
                    //            this.toolStripProgressBarImport.Value = e.ProgressPercentage;
                    //Отобразить процент и текст
                    toolStripStatusLabelInfo.Text = "Обработано " +
                                                    toolStripProgressBarImport.Value.ToString() + " из " +
                                                    toolStripProgressBarImport.Maximum.ToString() + " (" +
                                                    Convert.ToString(e.ProgressPercentage) + "%)";
                    break;
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (!clSystemSet.checkProvider()) this.Close();
            checkFileImport(Properties.Settings.Default.importFilename);

            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSetting.Enabled = clMsSqlDatabase.sqlConnectSimple(cs);
            tbCompanyName.Text = Properties.Settings.Default.companyName;   //наименование компании
            nDaysInWorkWeek.Value = Properties.Settings.Default.daysInWorkWeek;
            nHoursInFullWorkDay.Value = Properties.Settings.Default.hoursInFullWorkDay;
            nMinutesChangingFullWorkDay.Value = Properties.Settings.Default.minutesChangingFullWorkDay;
            nMinutesLunchBreakTime.Value = Properties.Settings.Default.minutesLunchBreakTime;
        }   

        //диалог выбора имени файла
        private void btFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog
            {
                //   Filter = "Excel 2010(*.xlsm) | *.xlsm|XML Documents(*.xml)|*.xml";
                Filter = "Excel 2010(*.xlsm) | *.xlsm"//|XML Documents(*.xml)|*.xml";
            };
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                tbPath.Text = "";
            if (dr == DialogResult.Cancel)
                tbPath.Text = "";

            tbPath.Text = od.FileName.ToString();
            checkFileImport(tbPath.Text);
        }

        //проверить файл импорта и настройка
        private void checkFileImport(string newPath) 
        {
            string parse; 

            parse = Properties.Settings.Default.importUserRange;
            cbSheetUser.Text = parse.Substring(0, parse.IndexOf("$"));
            tbRangeUser.Text = parse.Substring(parse.IndexOf("$") + 1);

            parse = Properties.Settings.Default.importPassRange;
            cbSheetPass.Text = parse.Substring(0, parse.IndexOf("$"));
            tbRangePass.Text = parse.Substring(parse.IndexOf("$") + 1);

            if (newPath == "" || !(File.Exists(newPath))) 
            {
                tbPath.Text = ""; 
                groupBox1.Enabled = false;
            }
            else
            {
                try
                {
                    string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={newPath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                    using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                    {
                        cnExcel.Open();
                        //прочитать имена листов
                        DataTable dtTablesList = cnExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        //Фактические имена листов заканчиваются на $ или $'
                        foreach (DataRow drTable in dtTablesList.Rows)
                        {
                            if (drTable["Table_Name"].ToString().EndsWith("$") || drTable["Table_Name"].ToString().EndsWith("$'")) 
                            {
                                string shName = drTable["Table_Name"].ToString();
                                shName = shName.Substring(0, shName.IndexOf("$"));
                                if (shName.Substring(0, 1) == "'") shName = shName.Substring(1, shName.Length - 1);
                                cbSheetUser.Items.Add(shName);
                                cbSheetPass.Items.Add(shName);
                            }
                        }
                        cnExcel.Close();
                    }
                    Properties.Settings.Default.importFilename = @newPath;
                    Properties.Settings.Default.importUserRange = cbSheetUser.Text + "$" + tbRangeUser.Text;
                    Properties.Settings.Default.importPassRange = cbSheetPass.Text + "$" + tbRangePass.Text;

                    Properties.Settings.Default.Save();

                    tbPath.Text= newPath;
                    groupBox1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //кнопка импорт пользователей
        private void btImportUsers_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show(
                "Внимание Таблицы:\r\n" +
                "  EventsPass (События проходов)\r\n" +
                "  Users      (Список сотрудников)\r\n" +
                " будут ОЧИЩЕНЫ!!!" + "\r\n\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly
                );
            if (response == DialogResult.Yes)
            {
                List<string> arguments = new List<string>
                {
                    "users",                                     //для вызова нужного метода
                    tbPath.Text,                                 //путь к файлу импорта Excel
                    cbSheetUser.Text + "$" + tbRangeUser.Text   //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН
                };

                if (!backgroundWorkerSetting.IsBusy)                        //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
            }
        }

        //импорт сотрудников через OleDbDataAdapter & DataSet
        public string ImportUserDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе
            try
            {
                string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={inArgument[1]};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                {
                    cnExcel.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    using (OleDbCommand cmdExcel = cnExcel.CreateCommand())
                    {
                        cmdExcel.CommandText = $"Select count(*) from [{inArgument[2]}]";
                        countRows = (int)cmdExcel.ExecuteScalar();

                        outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                        outArguments.Add("0");                          //минимальное значение
                        outArguments.Add(countRows.ToString());         //максимальное значение
                        outArguments.Add("1");                          //шаг
                        outArguments.Add("импорт");                     //комментарий
                        worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                        cmdExcel.CommandText = $"Select * from [{inArgument[2]}]";    //диапазон Data (без заголовка)
                        //OleDbDataReader result = cmdExcel.ExecuteReader();
                        da.SelectCommand = cmdExcel;
                        da.Fill(ds);
                    }
                    cnExcel.Close();
                    
                    using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                    {
                        sqlConnection.Open();
                        using (var sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.CommandText = "DELETE FROM EventsPass";
                            sqlCommand.ExecuteScalar();
                            
                            sqlCommand.CommandText = "DELETE FROM Users";
                            sqlCommand.ExecuteScalar();

                            int currentRow = 0;
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                //System.Threading.Thread.Sleep(50);
                                sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + row[1].ToString() + "'";
                                int departmentId = (int)sqlCommand.ExecuteScalar();
                                sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + row[2].ToString() + "'";
                                int postId = (int)sqlCommand.ExecuteScalar();
                                sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + row[7].ToString() + "'";
                                int workSchemeId = (int)sqlCommand.ExecuteScalar();

                                sqlCommand.CommandText =
                                    "UPDATE Users Set " +
                                        "departmentId = " + departmentId + ", " +
                                        "postId = " + postId + ", " +
                                        "timeStart = " + "'" + ((DateTime)row[4]).ToShortTimeString() + "', " +
                                        "timeStop = " + "'" + ((DateTime)row[5]).ToShortTimeString() + "', " +
                                        "noLunch = " + ((Boolean)row[6] ? 1 : 0) + ", " +
                                        "workSchemeId = " + workSchemeId + ", " +
                                        "uses = " + ((Boolean)row[8] ? 1 : 0) + " " +
                                    "WHERE extId = '" + row[0].ToString() + "' and name = '" + row[3].ToString() + "'; " +
                                    "IF @@ROWCOUNT = 0 " +
                                    "INSERT INTO Users(" +
                                        "extId, " +
                                        "name, " +
                                        "departmentId, " +
                                        "postId, " +
                                        "timeStart, " +
                                        "timeStop, " +
                                        "noLunch, " +
                                        "workSchemeId, " +
                                        "uses) " +
                                    "VALUES (" +
                                        "N'" + row[0].ToString() + "', " +
                                        "N'" + row[3].ToString() + "', " +
                                        departmentId + ", " +
                                        postId + ", " +
                                        "'" + ((DateTime)row[4]).ToShortTimeString() + "', " +
                                        "'" + ((DateTime)row[5]).ToShortTimeString() + "', " +
                                        ((Boolean)row[6] ? 1 : 0) + ", " +
                                        workSchemeId + ", " +
                                        ((Boolean)row[8] ? 1 : 0) +
                                        ")";
                                sqlCommand.ExecuteNonQuery();
                                currentRow += 1;

                                outArguments[0] = "work";                                          //init инициализация прогрессбара work отображение значения
                                worker.ReportProgress((currentRow*100)/ countRows, outArguments);  //отобразить (вызвать событие) результаты progressbar
                            }
                        }
                        sqlConnection.Close();
                    }
                }
                CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);    //отправитьс ообщение главной форме что импрот произошел
                System.Threading.Thread.Sleep(1000);    //пауза 1 сек чтобы главная форма успела обновить список юзеров
                MessageBox.Show("Список сотрудников загружен в БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return "users";
        }

        //кнопка импорт проходов 
        private void btImportPass_Click(object sender, EventArgs e) 
        {
            DialogResult response = MessageBox.Show(
                "Внимание Таблица:\r\n" +
                "  EventsPass (События проходов)\r\n" +
                " будет ОЧИЩЕНА!!!" + "\r\n\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly
            );
            if (response == DialogResult.Yes)
            {
                List<string> arguments = new List<string>
                {
                    "pass",                                      //для вызова нужного метода
                    tbPath.Text,                                 //путь к файлу импорта Excel
                    cbSheetPass.Text + "$" + tbRangePass.Text   //диапазон ячеек формата ИМЯ_ЛИСТА$ДИАПАЗОН
                };

                if (!backgroundWorkerSetting.IsBusy)                        //Запустить фоновую операцию (поток)(с аргументами) вызвав событие DoWork
                    backgroundWorkerSetting.RunWorkerAsync(arguments);
            }
        }

        //импорт сотрудников через OleDbDataAdapter & DataSet
        public string ImportPassDataFromExcel(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<string> inArgument = e.Argument as List<string>;   //распарсить входнык параметры
            List<string> outArguments = new List<string>();         //возврат аргументов из потока на обработку
            int countRows;                                          //общее количество строк в запросе
            try
            {
                string csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={inArgument[1]};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                {
                    cnExcel.Open();
                    using (OleDbCommand cmdExcel = cnExcel.CreateCommand())
                    {
                        cmdExcel.CommandText = $"Select count(*) from [{inArgument[2]}]";
                        countRows = (int)cmdExcel.ExecuteScalar();

                        outArguments.Add("init");                       //init инициализация прогрессбара work отображение значения
                        outArguments.Add("0");                          //минимальное значение
                        outArguments.Add(countRows.ToString());         //максимальное значение
                        outArguments.Add("1");                          //шаг
                        outArguments.Add("импорт");                     //комментарий
                        worker.ReportProgress(0, outArguments);         //отобразить (вызвать событие) результаты progressbar

                        cmdExcel.CommandText = $"Select * from [{inArgument[2]}]";    //диапазон Data (без заголовка)
                        OleDbDataReader result = cmdExcel.ExecuteReader();

                        using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                        {
                            sqlConnection.Open();
                            using (var sqlCommand = sqlConnection.CreateCommand())
                            { 
                                //sqlCommand.CommandTimeout = 10;
                                sqlCommand.CommandText = "DELETE FROM EventsPass";
                                sqlCommand.ExecuteScalar();
                                int currentRow = 0;
                                while (result.Read())
                                {
                                    try
                                    {
                                        //Явное приведение типов
                                        string author = result.GetString(1);
                                        string passDate = result.GetDateTime(2).ToString("yyyyMMdd");
                                        string passId = Convert.ToString(result.GetValue(3));
                                        string passTimeStart = result.GetDateTime(5).ToString("yyyyMMdd HH:mm");
                                        string passTimeStop = result.GetDateTime(6).ToString("yyyyMMdd HH:mm");
                                        int timeScheduleFact = Convert.ToInt32(result.GetValue(9));
                                        int timeScheduleWithoutLunch = Convert.ToInt32(result.GetValue(10));
                                        int timeScheduleLess = Convert.ToInt32(result.GetValue(11));
                                        int timeScheduleOver = Convert.ToInt32(result.GetValue(12));
                                        string sp = result.GetString(13).Trim();
                                        switch (sp)
                                        {
                                            case "-":
                                                sp = "Работа в дневное время";
                                                break;
                                            case "Больничный":
                                                sp = "Больничный (оплачиваемый)";
                                                break;
                                            case "Отгул":
                                                sp = "(Отгул) Дополнительный ежегодный отпуск (оплачиваемый)";
                                                break;
                                            case "Отпуск":
                                                sp = "Отпуск ежегодный (оплачиваемый)";
                                                break;
                                            case "Общественное дело":
                                            case "Служебное задание":
                                                sp = "Служебная командировка";
                                                break;
                                        }

                                        sqlCommand.CommandText = "SELECT id FROM SpecialMarks Where name='" + sp + "'";         
                                        int specialMarksId = (int)sqlCommand.ExecuteScalar();               //получить  id спец отметки                                   

                                        //поднять рейтинг спец отметки
                                        sqlCommand.CommandText = "SELECT rating FROM SpecialMarks Where id=" + specialMarksId;        
                                        int specialMarksRating = (int)sqlCommand.ExecuteScalar();           //прочитать рейтинг
                                        specialMarksRating++;                                               //поднять рейтинг                        
                                        sqlCommand.CommandText = "UPDATE SpecialMarks Set rating = " + specialMarksRating + ", uses = 1 Where id=" + specialMarksId;
                                        sqlCommand.ExecuteNonQuery();                                       //обновить рейтинг

                                        string specmarkTimeStart = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(14)).ToString("yyyyMMdd HH:mm") + "'";
                                        string specmarkTimeStop = specialMarksId == 1 ? "NULL" : "'" + Convert.ToDateTime(result.GetValue(15)).ToString("yyyyMMdd HH:mm") + "'";
                                        string specmarkNote = result.GetValue(16) == DBNull.Value ? "NULL" : "N'" + Convert.ToString(result.GetValue(16)).Replace("'","''") + "'";
                                        int totalHoursInWork = Convert.ToInt32(result.GetValue(17));
                                        int totalHoursOutsideWork = result.GetValue(18) == DBNull.Value ? 0 : Convert.ToInt32(result.GetValue(18));

                                        string sql =
                                            "UPDATE EventsPass Set " +
                                                "author = " + "N'" + author + "', " +
                                                "passTimeStart = " + "'" + passTimeStart + "', " +
                                                "passTimeStop = " + "'" + passTimeStop + "', " +
                                                //"pacsTimeStart = " + "NULL" + ", " +
                                                //"pacsTimeStop = " +  "NULL" + ", " +
                                                "timeScheduleFact = " + timeScheduleFact + ", " +
                                                "timeScheduleWithoutLunch = " + timeScheduleWithoutLunch + ", " +
                                                "timeScheduleLess = " + timeScheduleLess + ", " +
                                                "timeScheduleOver = " + timeScheduleOver + ", " +
                                                "specmarkId = " + specialMarksId + ", " +
                                                "specmarkTimeStart = " + specmarkTimeStart + ", " +
                                                "specmarkTimeStop = " + specmarkTimeStop + ", " +
                                                "specmarkNote = " + specmarkNote + ", " +
                                                "totalHoursInWork = " + totalHoursInWork + ", " +
                                                "totalHoursOutsideWork = " + totalHoursOutsideWork + " " +
                                            "WHERE passDate = '" + passDate + "' " +                   //*дата прохода
                                                "and passId = '" + passId + "' ; " +                   //*внешний id сотрудника
                                            "IF @@ROWCOUNT = 0 " +
                                            "INSERT INTO EventsPass(" +
                                                "author, " +                                    //имя учетной записи сеанса
                                                "passDate, " +                                  //*дата события (без времени)
                                                "passId, " +                                    //*внешний id пользователя
                                                "passTimeStart, " +                             //время первого входа (без даты)
                                                "passTimeStop, " +                              //время последнего выхода (без даты)
                                                //"pacsTimeStart, " +                             //время первого входа по СКУД (без даты)
                                                //"pacsTimeStop, " +                              //время последнего выхода по СКУД (без даты)
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
                                                "N'" + author + "', " +
                                                "'" + passDate + "', " + 
                                                "'" + passId + "', " +
                                                "'" + passTimeStart + "', " +
                                                "'" + passTimeStop + "', " +
                                                //"NULL" + ", " +
                                                //"NULL" + ", " +
                                                timeScheduleFact + ", " +
                                                timeScheduleWithoutLunch + ", " +
                                                timeScheduleLess + ", " +
                                                timeScheduleOver + ", " +
                                                specialMarksId + ", " +
                                                specmarkTimeStart + ", " +
                                                specmarkTimeStop + ", " +
                                                specmarkNote + ", " +
                                                totalHoursInWork + ", " +
                                                totalHoursOutsideWork +
                                                ")";
                                            sqlCommand.CommandText = sql;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.ToString());
                                        }
                                        sqlCommand.ExecuteNonQuery();
                                        currentRow += 1;

                                        outArguments[0] = "work";                                               //init инициализация прогрессбара work отображение значения
                                        worker.ReportProgress((currentRow * 100) / countRows, outArguments);    //отобразить (вызвать событие) результаты progressbar
                                    }
                                }
                                sqlConnection.Close();
                            }
                        }
                        cnExcel.Close();
                    }
                    MessageBox.Show("Список проходов загружен в БД");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            return "pass";
        }

        //перед закрытием формы
        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.importFilename = @tbPath.Text;
            Properties.Settings.Default.importUserRange = @cbSheetUser.Text + "$" + tbRangeUser.Text;
            Properties.Settings.Default.importPassRange = @cbSheetPass.Text + "$" + tbRangePass.Text;
            Properties.Settings.Default.companyName = tbCompanyName.Text.Trim();
            Properties.Settings.Default.daysInWorkWeek = (int)nDaysInWorkWeek.Value;
            Properties.Settings.Default.hoursInFullWorkDay = (int)nHoursInFullWorkDay.Value;
            Properties.Settings.Default.minutesChangingFullWorkDay = (int)nMinutesChangingFullWorkDay.Value;
            Properties.Settings.Default.minutesLunchBreakTime = (int)nMinutesLunchBreakTime.Value;

            Properties.Settings.Default.Save();
            CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);    //отправитьс ообщение главной форме что импрот произошел

        }

        /// <summary>
        /// событие перерисуем цвет кнопок вкладок
        /// </summary>
        private void tabSetting_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabSetting.TabPages[e.Index];
            //Color col = e.Index == 0 ? Color.Aqua : Color.Yellow;
            Color col = e.Index == 2 ? Color.WhiteSmoke : SystemColors.Control;
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
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
            /*
            if (param.Count() != 0)
            {
                Control[] cntrl = this.FilterControls(c => c.Name != null && c.Name.Equals(controlName) && c is DataGridView);
                ((DataGridView)cntrl[0]).DataSource = param;
            }
            */
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
    //после импорта
    public static class CallBack_FrmImport_outEvent
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
    //изменение общих настроек
    public static class CallBack_FrmSetting_outEvent
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



//---мусор
//http://www.codedigest.com/Articles/ASPNET/400_ImportUpload_Excel_Sheet_data_to_Sql_Server_in_C__and_AspNet.aspx#google_vignette
//https://csharp-tutorials1.blogspot.com/2017/03/import-excel-data-into-sql-table-using.html
//https://question-it.com/questions/1788823/kak-zagruzit-fajl-excel-v-tablitsu-bazy-dannyh-sql-s-pomoschju-prilozhenija-s-windows-form
//https://www.red-gate.com/simple-talk/databases/sql-server/t-sql-programming-sql-server/questions-about-using-tsql-to-import-excel-data-you-were-too-shy-to-ask/          
//https://metanit.com/sharp/tutorial/6.5.php

//https://www.nookery.ru/c-work-c-excel/
//https://yoursandmyideas.com/2011/02/05/how-to-read-or-write-excel-file-using-ace-oledb-data-provider/
//https://gist.github.com/maestrow/fd68246f6bca87891d2ace7a67d180e0
//https://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB

