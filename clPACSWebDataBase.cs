using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;



namespace TimeWorkTracking
{
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Структуры для парсинга Json ответов

    //http://localhost:40001/json/help/operations/Authenticate
    public class pacsAuthenticate
    {
        public string UserSID { get; set; }
    }

    //http://localhost:40001/json/help/operations/EmployeeGetList
    public class pacsEmployeeGetList
    {
        public pacsEmployee[] Employee { get; set; }
    }

    public class pacsEmployee
    {
        public string Token { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public pacsAdditionalFields[] AdditionalFields { get; set; }

    }
    public class pacsAdditionalFields
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    class clPacsWebDataBase
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
                    ret = webClient.UploadString(pacsUri, request);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
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
        private static string getRestData(string pacsUriStr, string extPath, string jsonReq, int printMsg)
        {
            string ret = "";
            string cn = pacsUriStr + "json/" + extPath;
            try
            {
                ret = getDataFromURL(cn, jsonReq);
             //   if (printMsg == 1)
                  //  printDebug(pacsUri.Host, jsonReq, ret);                //отчет о операции
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

        //проверить по настройкам формы что соединение есть в принципе 
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

        //проверить по строке подключения что соединение  существует
        //https://stackoverflow.com/questions/9620278/how-do-i-make-calls-to-a-rest-api-using-c
        private static bool CheckConnectSimple(string connectionString)
        {
            bool ret = false;
            UriBuilder pacsUri = new UriBuilder(connectionString);
            if (connectRestApi(pacsUri) != "")
                ret = true;
                
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


        //
        
        /// <summary>
        /// авторизации на сервере СКУД
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <returns>строка UserSID или если неудачно - пустая строка</returns>
        /// https://streletzcoder.ru/rabotaem-s-json-v-c-serializatsiya-i-deserializatsiya/
        /// https://coderoad.wiki/36674888/%D0%9A%D0%B0%D0%BA-%D1%81%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D1%8C-%D0%B2%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%BD%D1%83%D1%8E-%D1%81%D1%83%D1%89%D0%BD%D0%BE%D1%81%D1%82%D1%8C-%D0%BC%D0%BE%D0%B4%D0%B5%D0%BB%D1%8C-%D1%81-JavascriptSerializer-%D0%B2-C

        private static string connectRestApi(UriBuilder pacsUri) 
        {
            string jsonReq =        
                "{" +
                "\"PasswordHash\":\"" + pacsUri.Password + "\", " +
                "\"UserName\":\"" + pacsUri.UserName + "\"" +
                "}";

            UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля

            string res = getRestData(pacsUriLite.Uri.AbsoluteUri, "Authenticate", jsonReq, 0);//,
            pacsAuthenticate jsonRet = new JavaScriptSerializer().Deserialize<pacsAuthenticate>(res);
            //dynamic usr = new JavaScriptSerializer().DeserializeObject(res);
            //Dictionary<string, object> company = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(res);
            return jsonRet.UserSID;
        }

        /// <summary>
        /// получить внутренний id пользователя СКУД ProxWay
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <param name="crmId">id хвостик Лоции или Табельный номер пользователя в ProxWay</param>
        /// <param name="extId">d пользователя в служебной базе РПК - учет рабочего времени</param>
        /// <param name="userName">ФИО пользоватея (допускается использование маски через символ %) скорее всего в формате SQL для функции Like</param>
        /// <returns>id (Token) пользователя системы ProxWay - или в случае неудачи - пустая строка</returns>
        /// //http://localhost:40001/json/help/operations/EmployeeGetList
        /// //https://stackoverflow.com/questions/5502245/deserializing-a-json-file-with-javascriptserializer                
        private static string getUserIdProxWayByName(UriBuilder pacsUri, string crmId,  string extId, string userName)
        {
            string ret = "";
            string msg = "";
            string pwUserID = "";
            string UserSID = connectRestApi(pacsUri);

           // userName = "%" + "ле" + "%";
            if (UserSID.Length > 0) 
            {
               //  pointHostName = "EmployeeGetList"
                string jsonReq =    //-------------список пользователей
                    "{" +
                    "\"Language\":\"ru\", " +
                    "\"UserSID\":\"" + UserSID + "\", " +
                    "\"SubscriptionEnabled\":true, " +
                    "\"Limit\":0, " +
                    "\"StartToken\":0, " +
                    "\"AdditionalFieldsRequired\":true, " +
                    "\"Name\":\"" + userName + "\", " +
                    "}";

           // '           """DepartmentToken"":0, "
           // '           """DepartmentUsed"":true, " &
           // '           """HideDismissed"":true, " &
                UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
                string res = getRestData(pacsUriLite.Uri.AbsoluteUri, "EmployeeGetList", jsonReq, 0);//,
                pacsEmployeeGetList jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);

                switch (jsonRet.Employee.GetLength(0))
                {
                    case 0:
                        msg = "совпадений не обнаружено";
                        break;
                    case 1:
                        msg = "";
                        break;
                    default:
                        msg = "обнаружено более одного пользователя" + "\r\n" + "будет использован последний";

                        for (int i = 0; i < jsonRet.Employee.GetLength(0); i++)
                        {
                            pwUserID = jsonRet.Employee[i].Token;   //id юзера

                            //если нужна проверка на id сотрудника из Лоции (табельный номер в ProxWay)
                            if (crmId.Length> 0)                    
                            {
                                if(crmId != jsonRet.Employee[i].EmployeeNumber)
                                {
                                    pwUserID = "";
                                    msg = "совпадений по табельному номеру сотрудника" + "\r\n" + "не обнаружено";
                                    break;
                                }
                            }

                            //если нужна проверка на idExcel сотрудника из Excel базы учета рабочего времени (доп поля в ProxWay)
                            if (extId.Length > 0) 
                            {
                                if (jsonRet.Employee[i].AdditionalFields.GetLength(0) > 0) 
                                {
                                    for(int j=0;j< jsonRet.Employee[i].AdditionalFields.GetLength(0); i++) 
                                    {
                                        if(jsonRet.Employee[i].AdditionalFields[j].Name== "id базы учета рабочего времени (Excel)") 
                                        { 
                                            if(extId != jsonRet.Employee[i].AdditionalFields[j].Value) 
                                            {
                                                pwUserID = "";
                                                msg = "совпадений не обнаружено";
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else 
                            {
                                pwUserID = "";
                                msg = "совпадений не обнаружено" + "\r\n" + 
                                    "в базе ProxWay не настроены дополнительные поля сотрудника";
                                break;
                            }
                        }
                        break;
                }

                if (msg.Length > 0) 
                {
                    MessageBox.Show(
                        "Ошибка сопоставления пользователя" + "\r\n\r\n" +
                        " по параметрам запроса" + "\r\n" +
                        "   ФИО сотрудника        : '" + userName + "'" + "\r\n" +
                        "   id сотрудника из Лоции: '" + crmId + "'" + "\r\n" +
                        "   id сотрудника из Excel: '" + extId + "'" + "\r\n" +
                        "\r\n" + msg, "Пользователи СКУД ProwWay", MessageBoxButtons.OK, MessageBoxIcon.Warning 
                        );
                }

                //-------------выход
                //pointHostName = "Logout"
                jsonReq = 
                    "{" +
                    "\"UserSID\":\"" + UserSID + "\"" + 
                    "}";
                res = getRestData(pacsUriLite.Uri.AbsoluteUri, "Logout", jsonReq, 0);
                jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);
            }
            return pwUserID;
        }

        /// <summary>
        /// запрос к серверу на счет входа выхода конкретного сотрудника в/из офиса, и получение ответа
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <param name="crmId">id хвостик Лоции или Табельный номер пользователя в ProxWay</param>
        /// <param name="extId">id пользователя в служебной базе РПК - учет рабочего времени</param>
        /// <param name="userName">ФИО пользоватея (допускается использование маски через символ %) скорее всего в формате SQL для функции Like</param>
        /// <param name="findDateTime">день запроса в формате "уууу.mm.dd" (поиск будет произведен на указанную дату в диапазоне времени от 00:00:00 до 23:59:59)</param>
        /// <returns>одномерный массив - первое значение - время первого входа (если есть), второе значение - время последнего выхода (если есть)</returns>
        public static string[] сheckPointPWTime(string connectionString, string crmId, string extId, string userName, string findDateTime) 
        {
            UriBuilder pacsUri = new UriBuilder(connectionString);
           // UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
            string ret = getUserIdProxWayByName(pacsUri, crmId, extId, userName); //'infoArr

            return new string[1];
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
