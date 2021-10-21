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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            mainPanelUsers.Enabled = MsSqlDatabase.CheckConnectWithConnectionStr(Properties.Settings.Default.twtConnectionSrting);
            if (mainPanelUsers.Enabled)
            {
                cbDepartment.DisplayMember = "Name";
                cbDepartment.ValueMember = "id";
                cbDepartment.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserDepartment");

                cbPost.DisplayMember = "Name";
                cbPost.ValueMember = "id";
                cbPost.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserPost");

                cbSheme.DisplayMember = "Name";
                cbSheme.ValueMember = "id";
                cbSheme.DataSource = MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select id, name From UserWorkScheme");


                
          //      InitializeListView();
          //      LoadList(MsSqlDatabase.TableRequest(Properties.Settings.Default.twtConnectionSrting, "Select * From SpecialMarks"));
            }
        }

        //чекбокс
        private void chUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chUse.Checked)
                chUse.ImageIndex = 1;
            else
                chUse.ImageIndex = 2;
        }
    }
}
