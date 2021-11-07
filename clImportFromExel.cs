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
