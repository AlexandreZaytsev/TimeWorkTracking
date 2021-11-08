using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            mainPanelSetting.Enabled = clMsSqlDatabase.CheckConnectWithConnectionStr(cs);
//            int count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from Users", false));
//            btImportUsers.Enabled = count == 0;
//            count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from EventsPass", false));
//            btImportPass.Enabled = count == 0;
        }   
        //кнопка импорт пользователей
        private void btImportUsers_Click(object sender, EventArgs e)
        {
            ImportUserDataFromExcel();
            CallBack_FrmSetting_outEvent.callbackEventHandler("", "", null);  //send a general notification
            string cs = Properties.Settings.Default.twtConnectionSrting;    //connection string
            int count = Convert.ToInt32(clMsSqlDatabase.RequesScalar(cs, "select count(*) from Users", false));
            btImportUsers.Enabled = count == 0;

        }

        public static string getPathSourse()
        {
            OpenFileDialog od = new OpenFileDialog
            {
                //                Filter = "Excell|*.xls;*.xlsx;*.xlsm;"
                Filter = "Excel 2010(*.xlsm) | *.xlsm|XML Documents(*.xml)|*.xml"
                //"Excel Worksheets 2003(*.xls)|*.xls|Excel Worksheets 2007(*.xlsx)|*.xlsx|Word Documents(*.doc)|*.doc"
            };
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return "";
            if (dr == DialogResult.Cancel)
                return "" ;
            return od.FileName.ToString();
        }

        public static void ImportUserDataFromExcel()
        {
          //  string excelFilePath = "";
            DialogResult response = MessageBox.Show(
                "Внимание Таблицы Прохода и Сотрудников будут Очищены" + "\r\n" +
                "Продолжить?" + "\r\n",
                "Начальное заполнение данных",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly
                );
            if (response == DialogResult.Yes) 
            { 
            string excelFilePath = getPathSourse();
                if (excelFilePath != "")
                {
                    Excel.Application excelapp = new Excel.Application();
                    //excelapp.Visible = true;
                    Excel.Workbook workbook = excelapp.Workbooks.Open(
                        excelFilePath,
                        Type.Missing, true, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);

                    Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Reference"];
                    Excel.Range range = (Excel.Range)sheet.Range["Users"];// ().Cells[row, col];
                 
                    //   string n = "'" + range.Parent + "'!" + range.Address;
//                    Set b = Worksheets(2).Range("Users")
//s = "'" & b.Parent.name & "'!" & b.Address(External:= False)
                    foreach (var rangeName in workbook.Names)
                    {
                       // Range c = ws.Cells[row++, 3];
                       // c.Value = rangeName.NameLocal;
                    }
                    //                    string address= workbook.Worksheets[2].R
                    workbook.Close(false, Type.Missing, Type.Missing);  // Закройте книгу без сохранения изменений.
                    excelapp.Quit();                                   // Закройте сервер Excel.


                    //http://www.codedigest.com/Articles/ASPNET/400_ImportUpload_Excel_Sheet_data_to_Sql_Server_in_C__and_AspNet.aspx#google_vignette
                    //https://csharp-tutorials1.blogspot.com/2017/03/import-excel-data-into-sql-table-using.html
                    //https://question-it.com/questions/1788823/kak-zagruzit-fajl-excel-v-tablitsu-bazy-dannyh-sql-s-pomoschju-prilozhenija-s-windows-form
                    //https://www.red-gate.com/simple-talk/databases/sql-server/t-sql-programming-sql-server/questions-about-using-tsql-to-import-excel-data-you-were-too-shy-to-ask/          
                    //https://metanit.com/sharp/tutorial/6.5.php

                    using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
                    {
                        string myexceldataquery = "Select * from [Reference$B3:J68]";
                        //               string myexceldataquery = "Select * from users";
                        try
                        {
                            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                            ";extended properties=" + "\"Excel 12.0 Macro;hdr=yes;\"";

                            sqlConnection.Open();
                            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                            oledbconn.Open();
                            OleDbDataReader dr = oledbcmd.ExecuteReader();

                            object[] meta = new object[10];
                            bool read;

                            using (var sqlCommand = sqlConnection.CreateCommand())
                            {
                                sqlCommand.CommandText = "DELETE FROM EventsPass";
                                sqlCommand.ExecuteScalar();

                                sqlCommand.CommandText = "DELETE FROM Users";
                                sqlCommand.ExecuteScalar();
                                if (dr.Read() == true)
                                {
                                    do
                                    {
                                        int NumberOfColums = dr.GetValues(meta);

                                        sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + meta[1].ToString() + "'";
                                        int departmentId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + meta[2].ToString() + "'";
                                        int postId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + meta[7].ToString() + "'";
                                        int workSchemeId = (int)sqlCommand.ExecuteScalar();

                                        sqlCommand.CommandText =
                                            "UPDATE Users Set " +
                                              "departmentId = " + departmentId + ", " +
                                              "postId = " + postId + ", " +
                                              "timeStart = " + "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "timeStop = " + "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              "noLunch = " + ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              "workSchemeId = " + workSchemeId + ", " +
                                              "uses = " + ((Boolean)meta[8] ? 1 : 0) + " " +
                                            "WHERE extId = '" + meta[0].ToString() + "' and name = '" + meta[3].ToString() + "'; " +
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
                                              "N'" + meta[0].ToString() + "', " +
                                              "N'" + meta[3].ToString() + "', " +
                                              departmentId + ", " +
                                              postId + ", " +
                                              "'" + ((DateTime)meta[4]).ToShortTimeString() + "', " +
                                              "'" + ((DateTime)meta[5]).ToShortTimeString() + "', " +
                                              ((Boolean)meta[6] ? 1 : 0) + ", " +
                                              workSchemeId + ", " +
                                              ((Boolean)meta[8] ? 1 : 0) +
                                              ")";
                                        sqlCommand.ExecuteNonQuery();
                                        read = dr.Read();
                                    } while (read == true);
                                }
                            }
                            dr.Close();
                            oledbconn.Close();
                            MessageBox.Show("Список сотрудников загружен в БД");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
            }
        }

        //импорт проходов
        private void btImportPass_Click(object sender, EventArgs e)
        {

            toolStripProgressBarImport.Value = 0;
            //проверим наличие провайдера
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table1 = enumerator.GetElements();
            bool jetOleDb = false, aceOleDb = false;
            foreach (DataRow row in table1.Rows)
            {
                if (row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0") jetOleDb = true;
                if (row["SOURCES_NAME"].ToString() == "Microsoft.ACE.OLEDB.12.0") aceOleDb = true;
            }

            if (aceOleDb) //если провайдер есть
            {
                //https://www.nookery.ru/c-work-c-excel/
                //https://yoursandmyideas.com/2011/02/05/how-to-read-or-write-excel-file-using-ace-oledb-data-provider/
                //https://gist.github.com/maestrow/fd68246f6bca87891d2ace7a67d180e0
                //https://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB


                string excelFilePath = getPathSourse();
                if (excelFilePath != "")
                {

                    List<string[]> d = import_xlsx(excelFilePath, 1);



                    string csExcel ="", reqExcel="";
                //    DataSet ds = new DataSet();

                    /*
                        csExcel = "Provider=Microsoft.Jet.OLEDB.4.0; "Data Source=" + excelFilePath + Extended Properties=Excel 12.0 Macro;";
                        csExcel = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath + ";extended properties=" + "\"Excel 12.0 Macro;hdr=yes;\"";
                        csExcel = $@"provider=microsoft.ACE.OLEDB.12.0;data source ={excelFilePath};extended properties=" + "\"excel 12.0;hdr=yes;\"";
                        csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={excelFilePath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES;ReadOnly=true\"";
                        csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={excelFilePath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=NO\"";
                           HDR = YES | NO.HDR = YES означает, что первую строку листа, следует рассматривать как заголовки колонок. Т.о.значение из первой строки можно использовать как имена полей в sql запросах(любых: select, insert, update, delete).
                          IMEX = 1 | 3. 1 - открыть соединение для чтения. 3 - для записи.

                          "'[Учет рабочего времени.xlsm]Reference'!$B$4:$J$68"
                        reqExcel = @"Select * from '[Учет рабочего времени.xlsm]Reference'!$B$4:$J$68";     //ругается на скобки
                        reqExcel = @"Select * from 'Reference'!$B$4:$J$68";                                 //синтаксическая ошибка неполный запрос
                        reqExcel = @"Select * from $B$4:$J$68";                                             //ошибка в предложении from
                        reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
                        reqExcel = @"Select * from Reference!$B$4:$J$68";                                   //ошибка синтаксиса в предложении from
                        reqExcel = "Select * from Reference!$B$4:$J$68";                                    //ошибка синтаксиса в предложении from
                        reqExcel = "Select * from Reference$B3:J68";                                        //ошибка синтаксиса в предложении from
                        reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
                        reqExcel = "Select * from [Reference$users]";                                       //не найжен ядром
                        reqExcel = "Select * from [Reference$Users]";                                       //не найжен ядром
                        reqExcel = "Select * from [users]";                                                 //не найжен ядром
                        reqExcel = "Select * from [Users]";                                                 //не найжен ядром
                        reqExcel = "Select * from Users";                                                   //не найжен ядром
                        reqExcel = "Select * from users";                                                   //не найжен ядром
                        reqExcel = "Select * from [B3:J68]";                                                //ок но лист не тот
                        reqExcel = "Select * from B3:J68";                                                  //ок но лист не тот
                        reqExcel = "Select * from Reference!B3:J68";                                        //ошибка синтаксиса в предложении from
                        reqExcel = "Select * from Reference$B3:J68";                                        //ошибка синтаксиса в предложении from
                        reqExcel = "Select * from [Reference$B3:J68]";                                      //ок
                        reqExcel = "Select * from Data";
                        reqExcel = "SELECT * FROM USERS";
                        reqExcel = "SELECT * FROM DATA";
                        reqExcel = "SELECT * FROM [Reference$]";
                     */
                    csExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={excelFilePath};Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES; IMEX = 1\"";
                    reqExcel = "Select * from [Reference$B3:J68]";                      //диапазон Users (без заголовка)
 //                   reqExcel = "SELECT * FROM [Reference$] WHERE ID='Users'";
                    reqExcel = "Select * from [DataBase$B7:T56213]";                    //диапазон Data (без заголовка)
                    try
                    {

                        /*
                        OleDbConnection connExcel = new OleDbConnection(csExcel);
                        OleDbCommand cmdExcel = new OleDbCommand();
                        try
                        {
                            cmdExcel.Connection = connExcel;
                            //Read Data from Sheet1
                            connExcel.Open();
                            OleDbDataAdapter da = new OleDbDataAdapter();
                            DataSet ds = new DataSet();
                         //   string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            cmdExcel.CommandText = reqExcel;

                            da.SelectCommand = cmdExcel;
                            da.Fill(ds);
                            connExcel.Close();

                            toolStripProgressBarImport.Minimum = 0;
                            toolStripProgressBarImport.Maximum = ds.Tables[0].Rows.Count;
                            toolStripProgressBarImport.Value = 0;
                            foreach (var row in ds.Tables[0].Rows) 
                            {
                                toolStripProgressBarImport.Value += 1;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            cmdExcel.Dispose();
                            connExcel.Dispose();
                        }

                        */


                        using (OleDbConnection cnExcel = new OleDbConnection(csExcel))
                        {
                            cnExcel.Open();
                            //прочитать имена листов
                                                    DataTable dtTablesList = cnExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                                    foreach (DataRow drTable in dtTablesList.Rows)
                                                    {
                                                        //Do Something
                                                        //But be careful as this will also return Defined Names. i.e ranges created using the Defined Name functionality
                                                        //Actual Sheet names end with $ or $'
                                                        if (drTable["Table_Name"].ToString().EndsWith("$") || drTable["Table_Name"].ToString().EndsWith("$'"))
                                                        {
                                                            Console.WriteLine(drTable["Table_Name"]);
                                                        }
                                                    }

                        using (OleDbCommand cmdExcel1 = new OleDbCommand(reqExcel,cnExcel))
                        {
                            OleDbDataReader result = cmdExcel1.ExecuteReader();

                            toolStripProgressBarImport.Minimum = 0;
                            toolStripProgressBarImport.Maximum = 56206;
                            toolStripProgressBarImport.Value = 0;
                            while (result.Read())
                            {
                                    //              Console.WriteLine(result[0].ToString());
                               toolStripProgressBarImport.Value += 1;
                            }
                        }
                    }
                        MessageBox.Show("Список сотрудников загружен в БД");
                        toolStripProgressBarImport.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        //https://c-sharp.pro/?p=1744

        //https://ru.stackoverflow.com/questions/588737/%D1%8D%D0%BA%D1%81%D0%BF%D0%BE%D1%80%D1%82-%D0%B4%D0%B0%D0%BD%D0%BD%D1%8B%D1%85-%D0%B8%D0%B7-excel-%D1%87%D0%B5%D1%80%D0%B5%D0%B7-oledbdataadapter
        public static List<string[]> import_xlsx(String filename, int sheet_no)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            //XmlDocument sharedString = new XmlDocument();
            XmlDocument page = new XmlDocument();
            List<string> sharedString = new List<string>();
            List<string> colums = new List<string>();
            List<string[]> data = new List<string[]>();
            string Query = "xl/worksheets/sheet" + sheet_no + ".xml";
            int ready = 0;
            while (ready < 2)
            {
                byte[] head = new byte[30]; file.Read(head, 0, 30); if (head[0] != 'P') break;  //zip-header
                int i = (head[27] + head[29]) * 256 + head[28]; //  extra len
                long paked = head[18] + ((head[19] + (head[20] + head[21] * 256) * 256) * 256);
                byte[] nam = new byte[255];
                file.Read(nam, 0, head[26]);
                if (i != 0) file.Seek(i, SeekOrigin.Current);
                String aname = System.Text.Encoding.ASCII.GetString(nam, 0, head[26]);
                if ((aname == "xl/sharedStrings.xml") || (aname == Query) || (paked == 0))
                {
                    long lastpos = file.Position;
                    System.IO.Compression.DeflateStream deflate = new System.IO.Compression.DeflateStream(file, System.IO.Compression.CompressionMode.Decompress);
                    if (aname == "xl/sharedStrings.xml")
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(deflate);
                        foreach (XmlNode node in xml.SelectNodes("/*/*/*"))
                            sharedString.Add(node.InnerText);
                        ready++;
                    }
                    else if (aname == Query) { page.Load(deflate); ready++; };
                    file.Position = lastpos + paked;
                }
                else file.Seek(paked, SeekOrigin.Current);
            };
            int line = 1;
            foreach (XmlNode n in page.SelectNodes("/*/*/*"))
            {  /*nodes*/
                if (n.LocalName == "row")
                    foreach (XmlNode nn in n.ChildNodes)
                    {
                        string xpos = nn.Attributes["r"].Value;
                        int line2 = 0; int ss = -1; int v = -1;
                        int.TryParse(xpos.Substring(1), out line2);
                        if (line2 != line) 
                        { 
                            data.Add(colums.ToArray()); /*ИМПОРТ ТУТ*/   
                            colums.Clear(); 
                            line = line2; 
                        }
                        if (nn.FirstChild != null) 
                            int.TryParse(nn.FirstChild.InnerText, out v);
                        
                        colums.Add((nn.Attributes["t"] == null) ? ((nn.FirstChild == null) ? "" : nn.FirstChild.InnerText) : ((v < 0) ? "" : sharedString[v]));
                    };
                if (colums.Count != 0) 
                    data.Add(colums.ToArray());  /*ИМПОРТ ТУТ*/
            };
            return data;
        }
        //---------





        //----------
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
