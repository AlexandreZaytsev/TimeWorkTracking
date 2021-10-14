﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    class DataBase
    {


        /*
           Console.WriteLine("Getting Connection ...");
           SqlConnection conn = DBUtils.GetDBConnection();
           try
           {
               Console.WriteLine("Openning Connection ...");
               conn.Open();
               Console.WriteLine("Connection successful!");
           }
           catch (Exception e)
           {
               Console.WriteLine("Error: " + e.Message);
           }
           Console.Read();
           */

        public static string GetSqlConnection(string autehtification, string datasource, string database, string username, string password) 
        {
            string connectionString;
            StringBuilder errorMessages = new StringBuilder();

            switch (autehtification)
            {
                case "SQL Server Autentification":
                    connectionString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
                    break;
                case "Windows Autentification":
                    connectionString = @"Data Source=" + datasource + "; Initial Catalog=" + database + "; Integrated Security=True";
                    break;
                default:
                    connectionString="";
                    break;
            }

            var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCmd.Parameters.Add("@database", System.Data.SqlDbType.NVarChar).Value = database;
                    try
                    {
                        sqlConnection.Open();
                        if (Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1)
                            MessageBox.Show(
                                "Соединение установлено" + "\n\n" +
                                "Свойства подключения:" + "\n" +
                                $"\tСтрока подключения: {sqlConnection.ConnectionString}" + "\n" +
                                $"\tБаза данных: {sqlConnection.Database}" + "\n" +
                                $"\tСервер: {sqlConnection.DataSource}" + "\n" +
                                $"\tВерсия сервера: {sqlConnection.ServerVersion}" + "\n" +
                                $"\tСостояние: {sqlConnection.State}" + "\n" +
                                $"\tWorkstationld: {sqlConnection.WorkstationId}",
                                "Подключение к Базе Данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show("База данных с именем:" + "\n" +
                            "'"+database+"'" + "\n" +
                            "не существует на сервере",
                            "Подключение к Базе Данных",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                            connectionString = "-1";
                        }
                    }
                    catch (SqlException ex)
                    {
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                "Source: " + ex.Errors[i].Source + "\n" +
                                "Procedure: " + ex.Errors[i].Procedure + "\n");
                        }
                        connectionString = "-9";
                        MessageBox.Show(errorMessages.ToString(),
                                       "Подключение к Базе Данных",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
/*
                        if (rdr != null)
                        {
                            rdr.Close();                        //close the reader
                        }
*/
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();                         //Close the connection
                        }
                    }



                }
            }





/*

            SqlConnection cn = new SqlConnection();     //Instantiate the connection
            SqlDataReader rdr = null;

            cn.ConnectionString = connectionString;
            try
            {
                cn.Open();                              //Open the connection
                MessageBox.Show("Свойства подключения:" + "\n" +
                                $"\tСтрока подключения: {cn.ConnectionString}" + "\n" +
                                $"\tБаза данных: {cn.Database}" + "\n" +
                                $"\tСервер: {cn.DataSource}" + "\n" +
                                $"\tВерсия сервера: {cn.ServerVersion}" + "\n" +
                                $"\tСостояние: {cn.State}" + "\n" +
                                $"\tWorkstationld: {cn.WorkstationId}",
                                "Подключение к Базе Данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //дополнительная проверка что в БД есть наша база
                var cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from master.dbo.sysdatabases where name=@" + database; 
 */
                /*
                                // 3. Pass the connection to a command object
                                SqlCommand cmd = new SqlCommand("select * from Customers", conn);

                                //
                                // 4. Use the connection
                                //

                                // get query results
                                rdr = cmd.ExecuteReader();

                                // print the CustomerID of each record
                                while (rdr.Read())
                                {
                                    Console.WriteLine(rdr[0]);
                                }
                */
 
            return connectionString;
        }


    public static void GetDBConnection()
        {
            string datasource = @".\SQLEXPRESS";
            string username = @"RIC\zaytsev";// "sa";
            string password = "";// "1234";
  //          return DataBase.GetDBConnection(datasource, database, username, password);
            string database = "TimeWorkTracking";
        }

    }
}
