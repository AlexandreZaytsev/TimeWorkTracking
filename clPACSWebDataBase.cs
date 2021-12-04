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
        /// <param name="idRic">id хвостик Лоции или Табельный номер пользователя в ProxWay</param>
        /// <param name="userName">ФИО пользоватея (допускается использование маски через символ %) скорее всего в формате SQL для функции Like</param>
        /// <param name="idExcel">d пользователя в служебной базе РПК - учет рабочего времени</param>
        /// <returns>id (Token) пользователя системы ProxWay - или в случае неудачи - пустая строка</returns>
        private static string getUserIdProxWayByName(UriBuilder pacsUri, string idRic, string userName, string idExcel) //'infoArr
        {
            string ret = "";
            string msg = "";
            string pwUserID = "";
            string UserSID = connectRestApi(pacsUri);

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
//                 ret = GetRestData("http://" & srvHost & ":40001/json/", pointHostName, req, 0)
                UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
                string res = getRestData(pacsUriLite.Uri.AbsoluteUri, "EmployeeGetList", jsonReq, 0);//,
                pacsEmployeeGetList jsonRet = new JavaScriptSerializer().Deserialize<pacsEmployeeGetList>(res);



                //http://localhost:40001/json/help/operations/EmployeeGetList
                //https://stackoverflow.com/questions/5502245/deserializing-a-json-file-with-javascriptserializer                

/*
                JavaScriptSerializer ser = new JavaScriptSerializer();
                Dictionary<string, object> company = (Dictionary<string, object>)ser.DeserializeObject(res);
                if (company != null)
                    ret = company["Employee"].ToString();
*/

            }

            /*
               Dim info, req, ret, json, UserSID, pointHostName, usersInfo, userInfo, i
              Dim pwUserID, count, msg


               msg = ""
               pwUserID = ""
               UserSID = connectRestApi()
               If Len(UserSID) > 0 Then

             '-------------список пользователей
                 pointHostName = "EmployeeGetList"
                 req = "{" & _
                       """Language"":""ru"", " & _
                       """UserSID"":""" & UserSID & """, " & _
                       """SubscriptionEnabled"":true, " & _
                       """Limit"":0, " & _
                       """StartToken"":0, " & _
                       """AdditionalFieldsRequired"":true, " & _
                       """Name"":""" & userName & """, " & _
                       "}"

            '           """DepartmentToken"":0, "
            '           """DepartmentUsed"":true, " &
            '           """HideDismissed"":true, " &
                 ret = GetRestData("http://" & srvHost & ":40001/json/", pointHostName, req, 0)


                 Set json = pwJsonConverter.ParseJSON(ret)
                 count = json("Employee").count

                 Select Case count
                   Case 0
                     msg = "совпадений не обнаружено"
                   Case Else
                     If count > 1 Then
                       msg = "обнаружено более одного пользователя" & vbCrLf & "будет использован последний"
                     End If


                     Dim item As Object                ' Reference to each JSON Object found in the "data" property.
                     Dim rows As VBA.Collection        ' Reference to each JSON Object found in the "data" property's JSON Array.
                     Dim row  As Long                  ' Number of rows in the "data" property's JSON Array.
                     Dim data As Scripting.Dictionary  ' Reference to a JSON Object in the "data" property's JSON Array.

                     i = 0
                     For Each userInfo In json("Employee")
                       pwUserID = userInfo("Token")                         'id юзера

                       If Len(idRic) > 0 Then                               'если нужна проверка на id сотрудника из Лоции (табельный номер в ProxWay)
                         If idRic<> CStr(userInfo("EmployeeNumber")) Then
                          pwUserID = ""
                           msg = "совпадений по табельному номеру сотрудника" & vbCrLf & "не обнаружено"
                           Exit For
                         End If
                       End If


                       If Len(idExcel) > 0 Then                             'если нужна проверка на idExcel сотрудника из Excel базы учета рабочего времени (доп поля в ProxWay)
                         Set rows = userInfo("AdditionalFields")            'получить коллекцию
                         If rows.count > 0 Then
                           For row = 1 To rows.count Step 1                   'пройти по коллекции
                             Set item = rows.item(row)                        'получить объект из коллекции (JSON Array)
                             Set data = item                                  'преобразовать его в словарь
                             If data.Items(0) = "id базы учета рабочего времени (Excel)" Then 'проверить конкретное поле
                               If idExcel<> CStr(data.Items(1)) Then
                                pwUserID = ""
                                 msg = "совпадений не обнаружено"
                                 Exit For
                               End If
                             End If
                           Next row
                         Else
                           pwUserID = ""
                           msg = "совпадений не обнаружено" & vbCrLf & "в базе ProxWay не настроены дополнительные поля сотрудника"
                           Exit For
                         End If
                       End If
                       i = i + 1
                     Next userInfo
                 End Select
                 If Len(msg) > 0 Then
                   MsgBox "Ошибка сопоставления пользователя" & vbCrLf & vbCrLf & _
                          " по параметрам запроса" & vbCrLf & _
                          "   ФИО сотрудника        : '" & userName & "'" & vbCrLf & _
                          "   id сотрудника из Лоции: '" & idRic & "'" & vbCrLf & _
                          "   id сотрудника из Excel: '" & idExcel & "'" & vbCrLf & _
                          vbCrLf & msg, vbOKCancel + vbInformation, "Пользователи СКУД ProwWay"
                 End If

                '-------------выход
                 pointHostName = "Logout"
                 req = "{""UserSID"":""" & UserSID & """}"
                 ret = GetRestData("http://" & srvHost & ":40001/json/", pointHostName, req, 0)


                 Set json = Nothing

               End If
               GetUserIdProxWayByName = pwUserID
            End Function

             */

            return ret;
        }

        /// <summary>
        /// запрос к серверу на счет входа выхода конкретного сотрудника в/из офиса, и получение ответа
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <param name="pwIdUser">id пользователя ProxWay</param>
        /// <param name="findDateTime">день запроса в формате "уууу.mm.dd" (поиск будет произведен на указанную дату в диапазоне времени от 00:00:00 до 23:59:59)</param>
        /// <returns>одномерный массив - первое значение - время первого входа (если есть), второе значение - время последнего выхода (если есть)</returns>
        public static string[] сheckPointPWTime(string connectionString, string pwIdUser, string findDateTime) 
        {
            UriBuilder pacsUri = new UriBuilder(connectionString);
           // UriBuilder pacsUriLite = new UriBuilder(pacsUri.Scheme, pacsUri.Host, pacsUri.Port);    //пересоберем инфу без логина и пароля
            string ret = getUserIdProxWayByName(pacsUri, "", "", pwIdUser); //'infoArr

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
