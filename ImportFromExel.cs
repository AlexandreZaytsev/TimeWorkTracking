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
    class ImportFromExel
    {

        public static void ImportFromExcel()
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;*.xlsm;";
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
            //            https://csharp-tutorials1.blogspot.com/2017/03/import-excel-data-into-sql-table-using.html
            //https://question-it.com/questions/1788823/kak-zagruzit-fajl-excel-v-tablitsu-bazy-dannyh-sql-s-pomoschju-prilozhenija-s-windows-form

            //https://www.red-gate.com/simple-talk/databases/sql-server/t-sql-programming-sql-server/questions-about-using-tsql-to-import-excel-data-you-were-too-shy-to-ask/          

            //https://metanit.com/sharp/tutorial/6.5.php

            using (var sqlConnection = new SqlConnection(Properties.Settings.Default.twtConnectionSrting))
            {
                string ssqltable = "Users";
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
                    string sql="";
                    int departmentId;
                    int postId;
                    int workSchemeId;
                    DateTime start;
                    DateTime stop;
                    //var ret=null;
                    //           var sqlCommand = sqlConnection.CreateCommand();
                    SqlCommand cmd;
                    using (var sqlCommand = sqlConnection.CreateCommand())
                    {
                        if (dr.Read() == true)
                        {
                            do
                            {
                                int NumberOfColums = dr.GetValues(meta);
                                sqlCommand.CommandText = "SELECT count(*) FROM Users Where extId='" + meta[0].ToString() + "' and name='" + meta[3].ToString()+"'";
//                                cmd = new SqlCommand("SELECT count(*) FROM Users Where extId=" + meta[0].ToString() + " and name=" + meta[1].ToString(), sqlConnection);
                                switch (sqlCommand.ExecuteScalar())
                                {
                                    case 1:
                                      //  using (var sqlCommand = sqlConnection.CreateCommand(())
                                        break;
                                    default:
                                        sqlCommand.CommandText = "SELECT id FROM UserDepartment Where name='" + meta[1].ToString()+"'";
                                        departmentId=(int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserPost Where name='" + meta[2].ToString()+"'";
                                        postId = (int)sqlCommand.ExecuteScalar();
                                        sqlCommand.CommandText = "SELECT id FROM UserWorkScheme Where name='" + meta[7].ToString()+"'";
                                        workSchemeId = (int)sqlCommand.ExecuteScalar();
                                        start = (DateTime)meta[4];
                                        stop = (DateTime)meta[5];
                                        var sta = start.ToString("HH:mm");
                                        var sto = stop.ToString("HH:mm");
                                        sqlCommand.CommandText = "INSERT INTO Users(extId, name, departmentId, postId, timeStart, timeStop, lunch, workSchemeId, uses) VALUES " +
                                            "(" +
                                            "N'" + meta[0].ToString() + "', " +
                                            "N'" + meta[3].ToString() + "', " +
                                            departmentId + ", " +
                                            postId + ", " +
                                          //             TimeSpan.FromHours(meta[4]).ToString("hh':'mm") + ", " +
                                          //    (DateTime)meta[4].ToString("HH:mm")+//  ((DateTime)meta[4]).ToShortTimeString().ToString() + ", " +
                                          "'"+DateTime.Parse(meta[4].ToString()).ToString("HH:mm") + "', " +
                                          "'"+DateTime.Parse(meta[5].ToString()).ToString("HH:mm") + "', " +
                                            //  ((DateTime)meta[5]).ToShortTimeString().ToString() + ", " +
                                            ((Boolean)meta[6] ? 1 : 0) + ", " +
                                            workSchemeId + ", " +
                                            ((Boolean)meta[8] ? 1 : 0) +
                                            ")";
                                        break;
                                }
                          //      sqlCommand.CommandText = sql;
                                sqlCommand.ExecuteNonQuery(); 
                       //         break;
                                read = dr.Read();
                            } while (read == true);
                        }

                    }
                    /*
                                        List<Class> list = new List<Class>();
                                        while (reader.Read())
                                            list.Add(new MyClass
                                            {
                                                ID = reader.GetInt32(0),
                                                MarketName = reader.GetString(1),
                                                Price = reader.GetDecimal(2),
                                                Date = reader.GetDateTime(3)
                                            });
                                        reader.Close();

                                        return list.ToArray();
                      */
                    /*
                                        List<MyData> list = new List<MyData>();
                                        while (dr.Read())
                                        {
                                            MyData data = new MyData();
                                            data.Name = (string)myReader["name"];
                                            data.FinalConc = (int)myReader["finalconc"]; // or whatever the type should be
                                            list.Add(data);
                                        }
                    */


                    //        SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlConnection);
                    //        bulkcopy.DestinationTableName = ssqltable;
                            //          while (dr.Read())
                              //   {
            //            bulkcopy.WriteToServer(dr);
                                //   }
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
