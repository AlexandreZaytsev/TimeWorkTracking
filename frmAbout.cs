using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.Text = String.Format("О программе {0}", AssemblyTitle);
            this.lbProductName.Text = Application.ProductName;// AssemblyProduct;
            this.lbVersion.Text = String.Format("Версия {0}", AssemblyVersion);
            this.lbCopyright.Text = AssemblyCopyright;
            this.lbCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription + "\r\n"+Properties.Resources.about;
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        //двойное нажатие на тексте
        private void textBoxDescription_DoubleClick(object sender, EventArgs e)
        {
            string txt = ((System.Windows.Forms.TextBoxBase)sender).SelectedText;
            switch (txt.Trim()) 
            {
                case "ric":
                    System.Diagnostics.Process.Start(@"https://cad.ru");
                    break;
                case "github":
                    System.Diagnostics.Process.Start(@"https://github.com/AlexandreZaytsev/TimeWorkTracking");
                    break; 
                default:
                    if (txt.IndexOf('@') > 0)
                    {
                        string subject = lbProductName.Text;
                        string body = "Hi";
                        System.Diagnostics.Process.Start("mailto:" + txt + "? subject=" + subject + " & body = " + body + "");
                    }
                    break;
            }
        }
    }
}
