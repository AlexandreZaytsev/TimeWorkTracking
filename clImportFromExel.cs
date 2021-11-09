using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Xml;

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


    }
}
