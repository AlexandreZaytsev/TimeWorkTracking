﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    static class clSystemSet
    {
        //получить хеш строку MD5   
        public static string getMD5(string input)
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

        //проверить доступ к сетевым ресурсам 
        static public bool CheckPing(string addrPing)
        {
            Ping Pinger = new Ping();
            //int timeout = 4000;                 //4 сек 
            //PingOptions options = new PingOptions(64, true);
            //string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //byte[] buffer = Encoding.ASCII.GetBytes(data);
            try
            {
                PingReply reply = Pinger.Send(addrPing);//, timeout);//, buffer, options);
                if (reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (PingException)// e)
            {
                return false;
            }
        }

        //проверить провайдеров для работы с Excel
        static public bool checkProvider()
        {
            //проверим наличие провайдера
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table1 = enumerator.GetElements();
            bool jetOleDb = false, aceOleDb = false, excel = false;
            foreach (DataRow row in table1.Rows)
            {
                if (row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0") jetOleDb = true;
                if (row["SOURCES_NAME"].ToString() == "Microsoft.ACE.OLEDB.12.0") aceOleDb = true;
            }

            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType != null)
                excel = true;

            if (!(aceOleDb && excel))
            {
                System.Windows.Forms.MessageBox.Show(
                    "В системе отсутствует провайдер\r\n" +
                    " - Microsoft.ACE.OLEDB.12.0\r\n\r\n" +
                    "функционал Экспорт/Импорт/Отчеты\r\n - недоступен\r\n" +
                    "установите пожалуйста MS Excel2010 или выше",
                    "Ошибка окружения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );
                return false;
            }
            else
                return true;
        }
    }
}