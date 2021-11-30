using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net.Http;

using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;



namespace TimeWorkTracking
{
    class clWebServiceDataBase
    {
        //получить хеш строку MD5   
        private static string getMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Makes an async HTTP Request
        /// </summary>
        /// <param name="pMethod">Those methods you know: GET, POST, HEAD, etc...</param>
        /// <param name="pUrl">Very predictable...</param>
        /// <param name="pJsonContent">String data to POST on the server</param>
        /// <param name="pHeaders">If you use some kind of Authorization you should use this</param>
        /// <returns></returns>
        static async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = pMethod;
            httpRequestMessage.RequestUri = new Uri(pUrl);
            foreach (var head in pHeaders)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }
            switch (pMethod.Method)
            {
                case "POST":
                    HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = httpContent;
                    break;

            }

            return await _Client.SendAsync(httpRequestMessage);
        }


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
        private string getDataFromURL(string REQUEST_URI, string REQUEST_METHOD, string QUERY_STRING, string CONTENT_TYPE, string HTTP_ACCEPT, string strAuthorization)
        {

//        https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request

            int lngTimeout;                     //таймаут
            int intSslErrorIgnoreFlags;         //флаг intSslErrorIgnoreFlags Игноировать ошбибки при SSL соединении
            bool blnEnableRedirects;            //флаг blnEnableRedirects Разрешить перенаправления
            bool blnEnableHttpsToHttpRedirects; //флаг blnEnableHttpsToHttpRedirects Разрешить перенаправления с защищенного на не защиещенное соединение

            string HTTP_USER_AGENT;             //USER-AGENT содержит тип и версию браузера, версию ОС и аппаратную конфигурацию
            string strHostOverride;             //HOST URL cайта к которому подсоединяемся (имя хоста, с которого надо получить информацию, играет роль в том случае, когда на одном ip адресе лежит несколько виртуальных серверов)
            string HTTP_REFERER;                //REFERER формируется браузером и содержит URL страницы, с которой осуществился переход на текущую страницу по гиперссылке
            string strAcceptLanguage;           //ACCEPT-Language массив допустимых языков для вывода содержимого и их приоритет
            string strXForwardedFor;            //X-FORWARDED-FOR - используется не анонимными прокси-серверами для передачи реального IP клиента. Синтаксис следующий: X-Forwarded-For: client_ip, proxy1_ip, ..., proxyN_ip
            string HTTP_COOKIE;                 //Здесь хранятся все Cookies в URL-кодировке, отправить свои куки запрашиваемому сайту
            string strLogin;                    //логин
            string strPassword;                 //пароль
            string strResponseText;             //ответ
            string objWinHttp;                  //объект соединения
            string msg;

            lngTimeout = 60000;// ' 3000 ' 59000    '2000 'milliseconds '60000
            HTTP_USER_AGENT = "http_requester/0.1";     ' протокол по умолчанию (HTTP/1.1.)
            intSslErrorIgnoreFlags = 13056;// ' 13056: ignore all err, 0: accept no err
            blnEnableRedirects = true;
            blnEnableHttpsToHttpRedirects = true;
            strHostOverride = "";
            strLogin = "";
            strPassword = "";

            Set objWinHttp = CreateObject("WinHttp.WinHttpRequest.5.1");
  objWinHttp.SetTimeouts lngTimeout, lngTimeout, lngTimeout, lngTimeout


  objWinHttp.Open REQUEST_METHOD, REQUEST_URI

'установка заголовков
  If REQUEST_METHOD = "POST" Then
'заголовки для запроса к серверу
    If HTTP_ACCEPT<> "" Then objWinHttp.setRequestHeader "Accept", HTTP_ACCEPT          ' "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
'     objWinHttp.SetRequestHeader "Accept-Language", "ru"              ' "ru,en-us;q=0.7,en;q=0.3"
'     objWinHttp.SetRequestHeader "Accept-Charset", "Windows-1251"     ' "windows-1251,utf-8;q=0.7,*;q=0.7"

'заголовки для ответа от сервера
    If CONTENT_TYPE <> "" Then objWinHttp.setRequestHeader "Content-Type", CONTENT_TYPE   ' "application/xml" "application/x-www-form-urlencoded" "application / x-www-form-urlencoded; charset = Windows-1251"
'     objWinHttp.setRequestHeader "Content-Language", "ru"             '
'     objWinHttp.setRequestHeader "Content-Charset", "Windows-1251"    '
  End If
  If strHostOverride <> "" Then objWinHttp.setRequestHeader "Host", strHostOverride
  If strAuthorization<> "" Then objWinHttp.setRequestHeader "Authorization", strAuthorization   '
 
'установка параметров для SSL
  objWinHttp.Option(0) = HTTP_USER_AGENT
  objWinHttp.Option(4) = intSslErrorIgnoreFlags
  objWinHttp.Option(6) = blnEnableRedirects
  objWinHttp.Option(12) = blnEnableHttpsToHttpRedirects
  If(strLogin<> "") And(strPassword<> "") Then
objWinHttp.SetCredentials strLogin, strPassword, 0

End If
  
'отправка запроса

On Error Resume Next

objWinHttp.send (QUERY_STRING)
msg = ""

If Err.Number = 0 Then
'    MsgBox objWinHttp.getAllResponseHeaders() 'показать все установленные заголовки

Select Case objWinHttp.Status
  Case "200"   'успешный запрос (существует веб-страница)

    GetDataFromURL = objWinHttp.responseText

  Case "301"

    msg = "перемещается постоянно (часто перенаправляется на новый URL-адрес)"

  Case "400"

    msg = "Некорректный запрос (невалидный JSON или XML)"

  Case "401"

    msg = "несанкционированный запрос (требуется авторизация, В запросе отсутствует API-ключ)"

  Case "403"

    msg = "запрещено (доступ к странице или каталогу не разрешен)" & vbCrLf & _
              "В запросе указан несуществующий API-ключ" & vbCrLf & _
              "Или не подтверждена почта" & vbCrLf & _
              "Или исчерпан дневной лимит по количеству запросов"

  Case "405"

    msg = "Запрос сделан с методом, отличным от POST"

  Case "413"

    msg = "Слишком большая длина запроса или слишком много условий"

  Case "429"

    msg = "Слишком много запросов в секунду"

  Case "500"

    msg = "внутренняя ошибка сервера / сервиса во время обработки (часто вызванная неправильной конфигурацией сервера)"

  Case Else

    msg = "Requiest Error " & vbCrLf & "HTTP " & objWinHttp.Status & " " & objWinHttp.StatusText & "Responce " & objWinHttp.responseText

End Select

Else
'    MsgBox objWinHttp.getAllResponseHeaders() 'показать все установленные заголовки

msg = msg & "Object Error " & vbCrLf & "Error " & Err.Number & " " & Err.Source & " " & Err.Description

return "";

        End If


If msg<> "" Then
MsgBox msg, vbOKOnly + vbCritical + vbSystemModal, "Загрузка XML данных сервиса DaData"

End If



On Error GoTo 0

Set objWinHttp = Nothing
}
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
' Открыть ссылку в браузере  по умолчанию
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Sub OpenURL(url)
Dim WSHShell

If CloudServiceVbScr.CheckHost("") Then
  If InStr(url, "http") = 0 Then url = "http://" & url

      Set WSHShell = CreateObject("WScript.Shell")
      WSHShell.Run url, 1, False
     Set WSHShell = Nothing

    End If
End Sub

'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'запрос к серверу и получение ответа
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
' url - адрес сервера
' return - ответ сервера
'прочитать данные из СКУД
Function GetRestData(url, pointHostName, req, printMsg)
  Dim ret


   On Error GoTo ErrorHandler
   ret = GetDataFromURL(_
                           url & pointHostName, _
                           "POST", _
                            req, _
                            "application/json", _
                            "application/json", _
                            "Token " & "")
   If printMsg = 1 Then
     printDebug pointHostName, req, ret                         ' отчет о операции
   End If
  GetRestData = ret

ErrorHandler:
   ret = "" ' CStr("{'Credentials':null,'Language':'','UserSID':'','UserToken':0}")
End Function

'напечатать отладочную информацию
Sub printDebug(name, req, ret)
   Dim page
   page = vbLf 'vbCr 'vbLf ' vbCrLf
   Debug.Print "  Host: " & name & page
   Debug.Print "  Requesr: " & page & req & page
   Debug.Print "  Response: " & page & ret & page
End Sub




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
            string httpRet = "";
            if (connectionString != "")
            {
                string pass = getMD5(getMD5(getMD5(connectionString) + "F593B01C562548C6B7A31B30884BDE53"));
                string pointHostName = "Authenticate";
                //-------------авторизация
                string req = 
                    "{" +
                    "\"PasswordHash\":\" + pass + \", " +
                    "\"UserName\":\" + srvLogint + \"" +
                    "}";
                httpRet = GetRestData("http://" & srvHost & ":40001/json/", pointHostName, req, 0)
                if (httpRet.Length > 0)
                    {
                    Set json = pwJsonConverter.ParseJSON(ret)
                     ret = json("UserSID")
                    Set json = Nothing
                    }
                //  connectRestApi = ret


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
