using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Globalization;

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

    //http://localhost:40001/json/help/operations/EventGetList
    public class pacsEventGetList 
    {
        public string UserSID { get; set; }
        public pacsEvent[] Event { get; set; }
 //       public pacsEventColumns[] EventColumns { get; set; }
}

    public class pacsEvent 
    {
        public string CardCode { get; set; }
        public DateTime Issued { get; set; }
        public pacsMessage Message { get; set; }
        public pacsUser User { get; set; }
    }

    public class pacsMessage 
    {
        public string Name { get; set; }
    }

    public class pacsUser
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
    }

/*    public class pacsEventColumns
    {
        public string Name { get; set; }

    }
*/
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




    class clPacsWebDataBase
{
        /// <summary>
        /// Отправка POST запроса на хост
        /// </summary>
        /// <param name="pacsUri">connectionstring</param>
        /// <param name="request">json запрос</param>
        /// <returns>json строка ответа</returns>
        private static string getDataFromURL(Uri pacsUri, string request)
        {
            string ret="";
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Clear();
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json"; // Is about the payload/content of the current request or response. Do not use it if the request doesn't have a payload/ body.
                    wc.Headers[HttpRequestHeader.Accept] = "application/json"; // Tells the server the kind of response the client will accept.
//                    wc.Headers[HttpRequestHeader.UserAgent] = "PostmanRuntime/7.28.3";
//                    wc.Headers[HttpRequestHeader.Authorization] = "yourKey"; // Can be Bearer token, API Key etc.....
//                    wc.Headers.Add("Content-Type", "application/json");

                    ret = wc.UploadString(pacsUri, request);
//                    pacsAuthenticate jsonRet = new JavaScriptSerializer().Deserialize<pacsAuthenticate>(res);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// запрос к серверу и получение ответа
        /// </summary>
        /// <param name="pacsUriStr">connectionstring</param>
        /// <param name="extPath">адрес rest</param>
        /// <param name="jsonReq">запрос формата Json</param>
        /// <param name="printMsg">печатать или нет отладку</param>
        /// <returns></returns>
        private static string getRestData(Uri pacsUri, string jsonReq, int printMsg)
        {
            string ret = "";
            try
            {
                ret = getDataFromURL(pacsUri, jsonReq);
            }
            catch
            {
                ret = "";
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

        /// <summary>
        /// проверить по настройкам формы что соединение есть в принципе
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <returns>true если соединение есть</returns>
        private static bool CheckConnectBase(UriBuilder pacsUri)
        {
            bool ret = false;
            if (connectRestApi(pacsUri, true) != "")
                ret = true;
            else 
            {
                //описание ошибко подключения
                //   StringBuilder errorMessages = new StringBuilder();
            }
            return ret;
        }

        /// <summary>
        /// проверить по строке подключения что соединение  существует
        /// </summary>
        /// <param name="connectionString">connectionstring</param>
        /// <returns>true если соединение есть</returns>
        private static bool CheckConnectSimple(string connectionString)
        {
            bool ret = false;
            if (connectionString != "")
            {
                UriBuilder pacsUri = new UriBuilder(connectionString);
                if (connectRestApi(pacsUri, true) != "")
                    ret = true;
            }
            return ret;
        }

        /// <summary>
        /// авторизации на сервере СКУД
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <param name="logout">true - сразу разлогинится false - нет</param>
        /// <returns>строка UserSID или если неудачно - пустая строка</returns>
        /// https://streletzcoder.ru/rabotaem-s-json-v-c-serializatsiya-i-deserializatsiya/
        /// https://coderoad.wiki/36674888/%D0%9A%D0%B0%D0%BA-%D1%81%D0%B5%D1%80%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D1%8C-%D0%B2%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%BD%D1%83%D1%8E-%D1%81%D1%83%D1%89%D0%BD%D0%BE%D1%81%D1%82%D1%8C-%D0%BC%D0%BE%D0%B4%D0%B5%D0%BB%D1%8C-%D1%81-JavascriptSerializer-%D0%B2-C

        private static string connectRestApi(UriBuilder pacsUri, bool logout) 
        {
            string ret = "";
            string res = "";
            string jsonReq = "";
            UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля

            jsonReq =
                    "{" +
                    "\"PasswordHash\":\"" + pacsUri.Password + "\", " +
                    "\"UserName\":\"" + pacsUri.UserName + "\"" +
                    "}";
            pacsUriLite.Path = "json/Authenticate";
            res = getRestData(pacsUriLite.Uri, jsonReq, 0);//,
            pacsAuthenticate jsonRet = new JavaScriptSerializer().Deserialize<pacsAuthenticate>(res);
            //dynamic usr = new JavaScriptSerializer().DeserializeObject(res);
            //Dictionary<string, object> company = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(res);

            if (jsonRet != null) 
            {
                ret = jsonRet.UserSID;
                jsonRet = null;                                     //очистить объект

                if (logout)                                         //разлогитится
                {
                    jsonReq =
                            "{" +
                            "\"UserSID\":\"" + ret + "\"" +
                            "}";
                    pacsUriLite.Path = "json/Logout";
                    res = getRestData(pacsUriLite.Uri, jsonReq, 0);
                    }
            }
            return ret;
        }

        /// <summary>
        /// получить внутренний id пользователя СКУД ProxWay
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <param name="crmId">id хвостик Лоции или Табельный номер пользователя в ProxWay</param>
        /// <param name="extId">d пользователя в служебной базе РПК - учет рабочего времени</param>
        /// <param name="userName">ФИО пользоватея (допускается использование маски через символ %) скорее всего в формате SQL для функции Like</param>
        /// <returns>id (Token) пользователя системы ProxWay - или в случае неудачи - пустая строка</returns>
        private static string getUserIdProxWayByName(UriBuilder pacsUri, string crmId,  string extId, string userName)
        {
            string jsonReq = "";
            string res = "";
            string msg = "";
            string pwUserID = "";
            string UserSID = connectRestApi(pacsUri, false);   //получить внутренний id пользователя СКУД ProxWay
            UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля

            //userName = "%" + "ле" + "%";
            if (UserSID.Length > 0) 
            {
               //  pointHostName = "EmployeeGetList"
                jsonReq =    //-------------список пользователей
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
               // UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
                pacsUriLite.Path = "json/EmployeeGetList";
                res = getRestData(pacsUriLite.Uri, jsonReq, 0);//,
                pacsEmployeeGetList jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);
                if (jsonRet != null)
                {
                    switch (jsonRet.Employee.GetLength(0))
                    {
                        case 0:
                            msg = "совпадений не обнаружено";
                            pwUserID = "";
                            break;
                        case 1:
                            msg = "";
                            pwUserID = jsonRet.Employee[0].Token;   //id юзера
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
                    jsonRet = null;                                     //очистить объект
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
                pacsUriLite.Path = "json/Logout";
                res = getRestData(pacsUriLite.Uri, jsonReq, 0);
                //jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);
            }
            return pwUserID;
        }

        /// <summary>
        /// запрос к серверу на счет входа выхода конкретного сотрудника в/из офиса, и получение ответа
        /// </summary>
        /// <param name="pacsUri">строка подключения uriBuilder</param>
        /// <param name="pwIdUser"> id пользователя ProxWay</param>
        /// <param name="findDateTime">день запроса в формате "уууу.mm.dd" (поиск будет произведен на указанную дату в диапазоне времени от 00:00:00 до 23:59:59)</param>
        /// <returns>одномерный массив - первое значение - время первого входа (если есть), второе значение - время последнего выхода (если есть)</returns>
        private static Dictionary<string, string> checkPointPWTime(UriBuilder pacsUri, string pwIdUser, string findDateTime) 
        {
            string jsonReq = "";
            string res = "";
            DateTime pwDataTime;

            //            DateTime now = DateTime.Now;//локальное/универсальное время
            //            DateTime utc = DateTime.UtcNow;//времяutc без часового пояся

            //передача с преобразованием в универсальное время (с учетом смещения GMT)
            DateTime utcFrom = DateTime.Parse(findDateTime + " 00:00:00");
//            utcFrom = utcFrom.ToUniversalTime();                                                    //с учетом часового пояса (-3 часа для Москвы)
            double unixFrom = utcFrom.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
            DateTime utcTo = DateTime.Parse(findDateTime + " 23:59:59");
//            utcTo = utcTo.ToUniversalTime();                                                        //с учетом часового пояса (-3 часа для Москвы)
            double unixTo = utcTo.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;

            //            DateTime utcTo = DateTime.Parse(findDateTime + " 23:59:59");
            //            string unixTime = clSystemSet.convertToUnixTimeStamp(findDateTime + " 00:00:00", 3);

            string[] timeArr = new string[2];
            Dictionary<string, string> timePacs = new Dictionary<string, string>();
            timePacs.Add("userSID", "");                                                            //id сотрудника в СКУД
            timePacs.Add("timeIn", "");                                                             //время первого входа                       
            timePacs.Add("timeOut", "");                                                            //время последнего выхода

            string UserSID = connectRestApi(pacsUri, false);                                        //получить внутренний id пользователя СКУД ProxWay
            UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
            timePacs["userSID"] = UserSID;
            if (UserSID.Length > 0)
            {
                //https://zetcode.com/csharp/datetime/
                //  pointHostName = "EventGetList"
                jsonReq =    //-------------список проходов
                    "{" +
                    "\"Language\":\"ru\", " +
                    "\"UserSID\":\"" + UserSID + "\", " +
                    "\"SubscriptionEnabled\":false, " +
                    "\"Limit\":0, " +
                    "\"StartToken\":0, " +
                    "\"Employees\":[" + pwIdUser + "], " +
                    "\"IssuedFrom\":\"" + @"\/Date(" + unixFrom.ToString() + @")\/" + "\", " +
                    "\"IssuedTo\":\"" + @"\/Date(" + unixTo.ToString() + @")\/" + "\", " +
                    "}";
//                "\"IssuedFrom\":\"" + @"\/Date(" + clSystemSet.convertToUnixTimeStamp(findDateTime + " 00:00:00", 3) + @")\/" + "\", " +
//                "\"IssuedTo\":\"" + @"\/Date(" + clSystemSet.convertToUnixTimeStamp(findDateTime + " 23:59:59", 3) + @")\/" + "\", " +
            //"""Employees"":[], "  'массив id сотрудников [1785, 1809] Ечина и Зайцев

            pacsUriLite.Path = "json/EventGetList";
                res = getRestData(pacsUriLite.Uri, jsonReq, 0);//,
                pacsEventGetList jsonRet = new JavaScriptSerializer().Deserialize<pacsEventGetList>(res);
                if (jsonRet != null)
                {
                    string[] cultureNames = { "en-US", "ru-RU", "ja-JP" };
                    CultureInfo culture = new CultureInfo(cultureNames[1]);

                    for (int i = 0; i < jsonRet.Event.GetLength(0); i++)
                    {
                        if (jsonRet.Event[i].CardCode.Length > 0 && jsonRet.Event[i].User.Token == pwIdUser) //!!!если чела небыло есть проход от юзера 0??? jsonRet.Event[i].User.Token == pwIdUser
                        {
                            switch (jsonRet.Event[i].Message.Name) 
                            {
                                case "Вход совершен":
                                    pwDataTime = jsonRet.Event[i].Issued.ToLocalTime();     //прием с преобразованием в локальное время (с учетом смещения GMT)
                                    if (timePacs["timeIn"] == "")
                                        timePacs["timeIn"] = pwDataTime.ToString();
                                    else if (pwDataTime < Convert.ToDateTime(timePacs["timeIn"]))
                                        timePacs["timeIn"] = pwDataTime.ToString();
                                    break;
                                case "Выход совершен":
                                    pwDataTime = jsonRet.Event[i].Issued.ToLocalTime();     //прием с преобразованием в локальное время (с учетом смещения GMT)
                                    if (timePacs["timeOut"] == "")
                                        timePacs["timeOut"] = pwDataTime.ToString();
                                    else if (pwDataTime > Convert.ToDateTime(timePacs["timeOut"]))
                                        timePacs["timeOut"] = pwDataTime.ToString();
                                    break;
                            }
                        }
                    }
                    jsonRet = null;                                     //очистить объект
                }
                //-------------выход
                //pointHostName = "Logout"
                jsonReq =
                    "{" +
                    "\"UserSID\":\"" + UserSID + "\"" +
                    "}";
                pacsUriLite.Path = "json/Logout";
                res = getRestData(pacsUriLite.Uri, jsonReq, 0);
                    //jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);
            }
            return timePacs;
        }

        //PUBLIC------------------------------------------------------------------------

        //Подключения и проверки

        /// <summary>
        /// проверить соединение отдельно по соединению (на базе master) и по имени базы в списке баз
        /// выдать расшифровку ошибок
        /// (проверка только из формы настроек соединения)
        /// </summary>
        /// <param name="pacsUri"></param>
        /// <returns></returns>
        public static string pacsConnectBase(UriBuilder pacsUri)
        {
            if (CheckConnectBase(pacsUri))
                return pacsUri.Uri.AbsoluteUri;
            else
                return "-9";            //соединение установить не удалось
        }

        /// <summary>
        /// проверить соединение сразу по строке подключения
        /// без выдачи ошибок
        /// (проверки из всех модулей)
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <returns></returns>
        public static bool pacsConnectSimple(string connectionString)
        {
            return CheckConnectSimple(connectionString);
        }

        //Запросы

        /// <summary>
        /// запрос к серверу на счет входа выхода конкретного сотрудника в/из офиса, и получение ответа
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <param name="findDateTime">день запроса в формате "уууу.mm.dd" (поиск будет произведен на указанную дату в диапазоне времени от 00:00:00 до 23:59:59)</param>
        /// <param name="crmId">id хвостик Лоции или Табельный номер пользователя в ProxWay</param>
        /// <param name="extId">id пользователя в служебной базе РПК - учет рабочего времени</param>
        /// <param name="userName">ФИО пользоватея (допускается использование маски через символ %) скорее всего в формате SQL для функции Like</param>
        /// <returns>словарь - userSID, timeIn, timeOut</returns>
        public static Dictionary<string, string> сheckPointPWTime(string findDateTime, string connectionString, string crmId, string extId, string userName)
        {
            Dictionary<string, string> timePacs = new Dictionary<string, string>();
            UriBuilder pacsUri = new UriBuilder(connectionString);
            string pwIdUser = getUserIdProxWayByName(pacsUri, crmId, extId, userName);           //получить id юзера (токен) в proxway
            if (pwIdUser!="")
                timePacs = checkPointPWTime(pacsUri, pwIdUser, findDateTime);
            return timePacs;
        }
    }
}

/*
       https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
       https://zetcode.com/csharp/httpclient/
       http://localhost:40001/json/help/operations/EmployeeGetList
       https://stackoverflow.com/questions/5502245/deserializing-a-json-file-with-javascriptserializer 
       https://stackoverflow.com/questions/9620278/how-do-i-make-calls-to-a-rest-api-using-c
 */