using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;



namespace TimeWorkTracking
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //поработаем с командной строкой на предмет сброса админского пароля
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length >1)
            {
                switch (arguments[1])
                {
                    case "-r":                          //сбросить админски пароль
                        Properties.Settings.Default.adminPass = "";
                        Properties.Settings.Default.Save();     //сохраним новый пароль в настройках
                        break;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }

}
