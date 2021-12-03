﻿using System;
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
//using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;


namespace TimeWorkTracking
{
    class clWebServiceDataBase
    {
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'функция Отправка GET POST запроса на хост
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' host - запрашиваемый сайт
        ' request - запрос
        //        https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
        //https://zetcode.com/csharp/httpclient/
         */
        private static string getDataFromURL(string pacsUri, string request)
        {
            string ret="";
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    ret = webClient.UploadString(pacsUri, request);// "http://some/address", "{some:\"json data\"}");
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
        ' extPath - даполнительный путь
        ' jsonReq - запрос формата Json
        ' return - ответ сервера
        'прочитать данные из СКУД
        */
        private static string getRestData(UriBuilder pacsUri, string extPath, string jsonReq, int printMsg)
        {
            string ret = "";
            string cs = pacsUri.Uri.OriginalString;
//            string cs = pacsUri.Uri.OriginalString.Replace(pacsUri.Uri.UserInfo + "@", "");
            //           cs = cs.Substring(0, cs.IndexOf('#'));
            //            cs = cs.Replace(uriPacs.Uri.UserInfo + "@", "")

            string cn = cs + "json/" + extPath;
            try
            {
                ret = getDataFromURL(cn, jsonReq);
                if (printMsg == 1)
                    printDebug(pacsUri.Host, jsonReq, ret);                //отчет о операции
            }
            catch
            {
                ret = "";
                //MessageBox.Show("No data from CB.");
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

        //проверить что соединение есть в принципе 
        private static bool CheckConnectBase(UriBuilder pacsUri)
        {
            bool ret = false;
            if (connectRestApi(pacsUri) != "")
                ret = true;
            else 
            {
                //описание ошибко подключения
                //   StringBuilder errorMessages = new StringBuilder();
            }
            return ret;
        }



        //проверить что и соединение и бд существует
        //https://stackoverflow.com/questions/9620278/how-do-i-make-calls-to-a-rest-api-using-c
        private static bool CheckConnectSimple(string connectionString)
        {
            bool ret = false;

            UriBuilder pacsUri = new UriBuilder(connectionString);

//            string cs = uriPacs.Uri.OriginalString.Replace(uriPacs.Uri.UserInfo + "@", "");
            //           cs = cs.Substring(0, cs.IndexOf('#'));
            //            cs = cs.Replace(uriPacs.Uri.UserInfo + "@", "")
            //            if (!clSystemSet.CheckHost(GetFormConnectionString().AbsoluteUri.Replace(uriPacs.Uri.UserInfo + "@", "")))
            //            if (!clSystemSet.CheckHost(cs))




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

                httpRet = "";// getRestData("http://" + "srvHost" + ":40001/json/", req, 0);
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


        /*'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'попытка авторизации на сервере
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ' возврат - строка UserSID или если неудачно - пустая строка
        '//https://streletzcoder.ru/rabotaem-s-json-v-c-serializatsiya-i-deserializatsiya/
        */
        private static string connectRestApi(UriBuilder pacsUri) 
        {
            string ret = "";
            StringBuilder errorMessages = new StringBuilder();
            //-------------авторизация
            string jsonReq =
                "{" +
                "\"PasswordHash\":\"" + pacsUri.Password + "\", " +
                "\"UserName\":\"" + pacsUri.UserName + "\"" +
                "}";

            //сбросим инфу по логину и паролю
            pacsUri.UserName = "";
            pacsUri.Password = "";
            string res = getRestData(pacsUri, "Authenticate", jsonReq, 0);//,
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Dictionary<string, object> company = (Dictionary<string, object>)ser.DeserializeObject(res);
            return company["UserSID"].ToString();
        } 

        //PUBLIC------------------------------------------------------------------------

        //Подключения и проверки

        //проверить соединение отдельно по соединению (на базе master) и по имени базы в списке баз
        //выдать расшифровку ошибок
        //(проверка только из формы настроек соединения)
        public static string pacsConnectBase(UriBuilder pacsUri)
        {
            if (CheckConnectBase(pacsUri))
                return pacsUri.Uri.AbsoluteUri;
            else
                return "-9";            //соединение установить не удалось
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
