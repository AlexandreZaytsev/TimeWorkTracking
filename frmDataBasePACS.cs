using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeWorkTracking
{
    public partial class frmDataBasePACS : Form
    {
        public frmDataBasePACS()
        {
            InitializeComponent();
        }

        //test Connrection СКУД (web сервис PACS)
        private void btTestConnectionPacs_Click(object sender, EventArgs e)
        {
            //PACS DataBase
            Properties.Settings.Default.pacsHost = tbHostNamePACS.Text;
            Properties.Settings.Default.pascLogin = tbUserNamePACS.Text;
            Properties.Settings.Default.pacsPassword = tbPasswordPASC.Text;

            //            pacsConnectionString

            Properties.Settings.Default.Save();
        }

        private void frmDataBasePACS_Load(object sender, EventArgs e)
        {
            //PACS DataBase
            tbHostNamePACS.Text = Properties.Settings.Default.pacsHost;
            tbUserNamePACS.Text = Properties.Settings.Default.pascLogin;
            tbPasswordPASC.Text = Properties.Settings.Default.pacsPassword;
        }
    }
}
