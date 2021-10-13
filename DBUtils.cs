using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TimeWorkTracking
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @".\SQLEXPRESS";
            string database = "TimeWorkTracking";
            string username = @"RIC\zaytsev";// "sa";
            string password = "";// "1234";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
