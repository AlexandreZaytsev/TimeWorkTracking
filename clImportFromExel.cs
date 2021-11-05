using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Globalization;

namespace TimeWorkTracking
{
    class clImportFromExel
    {

        public static void ImportFromExcel()
        {
            OpenFileDialog od = new OpenFileDialog
            {
//                Filter = "Excell|*.xls;*.xlsx;*.xlsm;"
                Filter = "Excel 2010(*.xlsm) | *.xlsm"              //"Excel Worksheets 2003(*.xls)|*.xls|Excel Worksheets 2007(*.xlsx)|*.xlsx|Word Documents(*.doc)|*.doc"
            };
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            string path = od.FileName.ToString();
            ImportDataFromExcel(path);


        }

        public static void ImportDataFromExcel(string excelFilePath)
        {
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
                                      "uses = " + ((Boolean)meta[8] ? 1 : 0) + " "+
                                    "WHERE extId = '" + meta[0].ToString() + "' and name = '" + meta[3].ToString()+"'; " +
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
                    MessageBox.Show("File imported into sql server.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }



        public static void ImportFromExcel_()
        {
            using (OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["ExcelCon"].ConnectionString))
            {
                con.Open();
                OleDbCommand com = new OleDbCommand("Select * from [EmployeeInfo$]", con);
                OleDbDataReader dr = com.ExecuteReader();
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlcon))
                    {
                        bulkCopy.ColumnMappings.Add("[Employee Name]", "EmpName");
                        bulkCopy.ColumnMappings.Add("Department", "Department");
                        bulkCopy.ColumnMappings.Add("Address", "Address");
                        bulkCopy.ColumnMappings.Add("Age", "Age");
                        bulkCopy.ColumnMappings.Add("Sex", "Sex");
                        bulkCopy.DestinationTableName = "Employees";
                        bulkCopy.WriteToServer(dr);
                    }
                }
                dr.Close();
                dr.Dispose();
            }
//            Response.Write("Upload Successfull!");
        }

        static void ReadProducts()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;
            string queryString = "SELECT Id, ProductName FROM dbo.Products;";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }
                }
            }
        }
    }
}
