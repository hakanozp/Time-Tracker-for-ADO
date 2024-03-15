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

            txtOrganization.Text = Properties.Settings.Default.Organization;
            txtOrganizationUrl.Text = Properties.Settings.Default.OrganizationUrl;
            txtPersonelAccessToken.Text = Properties.Settings.Default.PersonalAccessToken;
            txtUser.Text = Properties.Settings.Default.User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Organization = txtOrganization.Text;
            Properties.Settings.Default.OrganizationUrl = txtOrganizationUrl.Text;
            Properties.Settings.Default.PersonalAccessToken = txtPersonelAccessToken.Text;
            Properties.Settings.Default.User = txtUser.Text;

            Properties.Settings.Default.Save();

            MessageBox.Show("Setting saved successfully. Please restart application!");
        }

    }
}
