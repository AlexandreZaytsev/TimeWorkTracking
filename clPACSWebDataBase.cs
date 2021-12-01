using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.Web;
using System.Windows.Forms;

namespace TimeWorkTracking
{


    class clWebServiceDataBase
    {

  

        /*
        // utility method to read the cookie value:
        public static string ReadCookie(string cookieName)
        {
            var cookies = HttpContext.Current.Request.Cookies;
            var cookie = cookies.Get(cookieName);
            if (cookie != null)
                return cookie.Value;
            return null;
        }
        
        private void dd()
        {
            string url = "http://site.com/";

            using (var webClient = new WebClient())
            {
                // Создаём коллекцию параметров
                var pars = new NameValueCollection();

                // Добавляем необходимые параметры в виде пар ключ, значение
                pars.Add("format", "json");

                // Посылаем параметры на сервер
                // Может быть ответ в виде массива байт
                var response = webClient.UploadValues(url, pars);
            }
        }
        */


        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'функция Отправка GET POST запроса на хост
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' REQUEST_URI - запрашиваемый сайт
        ' REQUEST_METHOD - метод запроса
        '  GET - запрашивает данные из указанного ресурса
        '  POST - отправляет данных, подлежащие обработке, на указанный ресурс
        ' QUERY_STRING - запрос
        ' Content-Type: application/x-www-form-urlencoded идентифицирует тип передаваемых данных
        ' Accept: text/html, text/plain, image/gif, image/jpeg   какие типы документов он "понимает"
        //http://scriptcoding.ru/2013/03/19/protocol-http/
        //http://www.read.excode.ru/art5783p3.html
        */
        private static string getDataFromURL(string host, string request)
        {
            string ret="";
            //        https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request

            // WebClient:
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    ret = webClient.UploadString(host, request);// "http://some/address", "{some:\"json data\"}");
                    /*
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    byte[] requestData = Encoding.ASCII.GetBytes(serializer.Serialize(postRequest));
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = requestData.Length;
                    request.ContentType = "application/json";
                    request.Expect = "application/json";
                    request.Headers.Set("Authorization", ReadCookie("AuthCookie"));
                    request.GetRequestStream().Write(requestData, 0, requestData.Length);
                    using (var response1 = (HttpWebResponse)request.GetResponse())
                    {
                        var reader = new StreamReader(response1.GetResponseStream());
                        var objText = reader.ReadToEnd(); // objText will have the value
                    }
                    */
                    /*
                     //http://www.cbr.ru/scripts/XML_daily.asp
                Stream data = web.OpenRead(url);
                StreamReader reader = new StreamReader(data, Encoding.GetEncoding(1251));
                html = reader.ReadLine();
                data.Close();
                reader.Close();
                FileStream file = new FileStream("data.txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter wData = new StreamWriter(file);
                wData.Write(html);
                wData.Close(); 
                     
                     */
                }
            }
            catch
            {
                MessageBox.Show("No data from CB.");
            }
            return ret;
        }

        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'запрос к серверу и получение ответа
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' url - адрес сервера
        ' return - ответ сервера
        'прочитать данные из СКУД
        */
        private static string getRestData(string url, string pointHostName, string req, int printMsg)
        {
            string ret = "";
            try
            {
                ret = getDataFromURL(url + pointHostName, req);
                if (printMsg == 1)
                    printDebug(pointHostName, req, ret);                //отчет о операции
            }
            catch
            {
                MessageBox.Show("No data from CB.");
                //                ret = "" ' CStr("{'Credentials':null,'Language':'','UserSID':'','UserToken':0}")
            }
            return ret;
        }

        //напечатать отладочную информацию
        private static void printDebug(string name, string req, string ret) 
        {
/*
            Dim page
                                 page = vbLf 'vbCr 'vbLf ' vbCrLf
                                 Debug.Print "  Host: " & name & page
                                 Debug.Print "  Requesr: " & page & req & page
                                 Debug.Print "  Response: " & page & ret & page
                              End Sub
*/
        }

        //проверить что соединение есть в принципе на базе master
        private static bool ConnectExists(string connectionString)
        {
            bool ret = false;
            StringBuilder errorMessages = new StringBuilder();
            /*
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                //     var databaseName = sqlConnectionStringBuilder.InitialCatalog;
                InitialCatalog = "master"
            };
            using (var sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    ret = true;
                }
                catch (SqlException ex)
                {
                    //https://docs.microsoft.com/ru-ru/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver15#errors-4000-to-4999
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Number: " + ex.Errors[i].Number + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString(),
                                   "Подключение к Базе Данных",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();                         //Close the connection
                    }
                }
                return ret;
            }
            */
            return true;
        }


        //проверить что и соединение и бд существует
        private static bool CheckConnectSimple(string connectionString)
        {
            bool ret = false;
            string httpRet = "";
            if (connectionString != "")
            {
                string pass = clSystemSet.getMD5(clSystemSet.getMD5(clSystemSet.getMD5(connectionString) + "F593B01C562548C6B7A31B30884BDE53"));
                string pointHostName = "Authenticate";
                //-------------авторизация
                string req =
                    "{" +
                    "\"PasswordHash\":\" + pass + \", " +
                    "\"UserName\":\" + srvLogint + \"" +
                    "}";

                httpRet = getRestData("http://" + "srvHost" + ":40001/json/", pointHostName, req, 0);
                if (httpRet.Length > 0) 
                {
                    //                     private static JavaScriptSerializer _Serializer = new JavaScriptSerializer();
                    /*
                            Set json = pwJsonConverter.ParseJSON(ret)
                                         ret = json("UserSID")
                                        Set json = Nothing
                    */
                    /*
                     * 
                     * https://stackoverflow.com/questions/15091300/posting-json-to-url-via-webclient-in-c-sharp
                    var vm = new { k = "1", a = "2", c = "3", v = "4" };
                    using (var client = new WebClient())
                    {
                        var dataString = JsonConvert.SerializeObject(vm);
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString(new Uri("http://www.contoso.com/1.0/service/action"), "POST", dataString);
                    }
                    */

                }
            }

            return ret;
        }
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
        // }
        //      return ret;
        //    }


        //PUBLIC------------------------------------------------------------------------

        //Подключения и проверки

        //проверить соединение отдельно по соединению (на базе master) и по имени базы в списке баз
        //выдать расшифровку ошибок
        //(проверка только из формы настроек соединения)
        public static string pacsConnectBase(string connectionString)
        {
            /*
            if (ConnectExists(connectionString))
            {
                if (DatabaseExists(connectionString))
                    return connectionString;
                else
                    return "-1";        //база данных не существует
            }
            else
                return "-9";            //соединение установить не удалось
*/
            return "";
        }

        //проверить соединение сразу по строке подключения
        //без выдачи ошибок
        //(проверки из всех модулей)
        public static bool pacsConnectSimple(string connectionString)
        {
            return CheckConnectSimple(connectionString);
        }
    }
}
