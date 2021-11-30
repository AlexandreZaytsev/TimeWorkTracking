using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeWorkTracking
{
    class clWebServiceDataBase
    {

        //проверить соединение сразу по строке подключения
        //без выдачи ошибок
        public static bool CheckConnectWithConnectionWeb(string connectionString)
        {
            return FullConnectExists(connectionString);
        }

        //проверить что и соединение и бд существует
        private static bool FullConnectExists(string connectionString)
        {
            bool ret = false;
            if (connectionString != "")
            {
                /*

                //       StringBuilder errorMessages = new StringBuilder();
              //  var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
              //  using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    try
                    {
               //         sqlConnection.Open();
                        ret = true;
                    }
                    catch ()//SqlException)
                    { }
                    finally
                    {
                        if (sqlConnection != null)
                        {
                            sqlConnection.Close();                         //Close the connection
                        }
                    }
                }
                */
            }
            return ret;
        }

    }
}
