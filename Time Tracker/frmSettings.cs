using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            //txtOrganization.Text = Properties.Settings.Default.Organization;
            //txtOrganizationUrl.Text = Properties.Settings.Default.OrganizationUrl;
            //txtPersonelAccessToken.Text = Properties.Settings.Default.PersonalAccessToken;
            //txtUser.Text = Properties.Settings.Default.User;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
            if (key != null)
            {
                //set the parameters for ADO
                txtOrganization.Text = key.GetValue("Organization").ToString();
                txtOrganizationUrl.Text = key.GetValue("OrganizationUrl").ToString();
                txtPersonelAccessToken.Text = key.GetValue("PersonalAccessToken").ToString();
                txtUser.Text = key.GetValue("User").ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Organization = txtOrganization.Text;
            //Properties.Settings.Default.OrganizationUrl = txtOrganizationUrl.Text;
            //Properties.Settings.Default.PersonalAccessToken = txtPersonelAccessToken.Text;
            //Properties.Settings.Default.User = txtUser.Text;

            //Properties.Settings.Default.Save();

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Time Tracker for ADO");
            key.SetValue("Organization", txtOrganization.Text);
            key.SetValue("OrganizationUrl", txtOrganizationUrl.Text);
            key.SetValue("PersonalAccessToken", txtPersonelAccessToken.Text);
            key.SetValue("User", txtUser.Text);
            key.Close();

            MessageBox.Show("Setting saved successfully. Please restart application!");
        }

    }
}
