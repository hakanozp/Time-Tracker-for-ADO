using Microsoft.Win32;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.IO;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmSettings : Form
    {
		public string dataDirectory;

		public frmSettings()
        {
            InitializeComponent();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
            if (key != null)
            {
                //set the parameters for ADO
                txtOrganization.Text = key.GetValue("Organization").ToString();
                txtOrganizationUrl.Text = key.GetValue("OrganizationUrl").ToString();
                txtPersonelAccessToken.Text = key.GetValue("PersonalAccessToken").ToString();
                txtUser.Text = key.GetValue("User").ToString();

				if (key.GetValue("WBSRUN") != null) 
					txtWbsRun.Text = key.GetValue("WBSRUN").ToString();
				
				if (key.GetValue("WBSPROJECT") != null)
					txtWbsProject.Text = key.GetValue("WBSPROJECT").ToString();

				if (key.GetValue("TagGroup1") != null)
				{
					string[] items = key.GetValue("TagGroup1").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					txtTags1.Lines = items.Select(item => item.Trim()).ToArray();
				}

				if (key.GetValue("TagGroup2") != null)
				{
					string[] items = key.GetValue("TagGroup2").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					txtTags2.Lines = items.Select(item => item.Trim()).ToArray();
				}

				if (key.GetValue("TagGroup3") != null)
				{
					string[] items = key.GetValue("TagGroup3").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					txtTags3.Lines = items.Select(item => item.Trim()).ToArray();
				}

				if (key.GetValue("TagGroup4") != null)
				{
					string[] items = key.GetValue("TagGroup4").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					txtTags4.Lines = items.Select(item => item.Trim()).ToArray();
				}
			}
			
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Time Tracker for ADO");
            key.SetValue("Organization", txtOrganization.Text);
            key.SetValue("OrganizationUrl", txtOrganizationUrl.Text);
            key.SetValue("PersonalAccessToken", txtPersonelAccessToken.Text);
            key.SetValue("User", txtUser.Text);

			key.SetValue("WBSRUN", txtWbsRun.Text);
			key.SetValue("WBSPROJECT", txtWbsProject.Text);

			string tagList = string.Join(", ", txtTags1.Lines.Select(line => line.Trim()));
			key.SetValue("TagGroup1", tagList);

			tagList = string.Join(", ", txtTags2.Lines.Select(line => line.Trim()));
			key.SetValue("TagGroup2", tagList);

			tagList = string.Join(", ", txtTags3.Lines.Select(line => line.Trim()));
			key.SetValue("TagGroup3", tagList);

			tagList = string.Join(", ", txtTags4.Lines.Select(line => line.Trim()));
			key.SetValue("TagGroup4", tagList);
			
			key.Close();


            MessageBox.Show("Setting saved successfully. Please restart application!");
        }

		private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
		{

		}


	}
}
