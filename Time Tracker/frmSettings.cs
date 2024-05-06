using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmSettings : Form
    {
		public string dataDirectory;

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

		private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
		{
            if (tabSettings.SelectedIndex == 1) 
            {
				SaveTags();   
            }
		}

		private void LoadTags()
		{
			string fileName = dataDirectory + "\\tags.txt";
			if (!File.Exists(fileName)) return;

			StreamReader reader = new StreamReader(fileName);
			StringBuilder sb1 = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();
			StringBuilder sb3 = new StringBuilder();
			StringBuilder sb4 = new StringBuilder();

			string line;
            int ix = 1;

			while ((line = reader.ReadLine()) != null)
			{
				if (line == "")
				{
					ix++;
					continue;
				}
                switch (ix)
                {   
                    case 1:
						sb1.AppendLine(line);
                        break;
					case 2:
						sb2.AppendLine(line);
						break;
					case 3:
						sb3.AppendLine(line);
						break;
					case 4:
						sb4.AppendLine(line);
						break;
					default:
                        break;
                }                
			}

            txtTags1.Text = sb1.ToString();
			txtTags2.Text = sb2.ToString();
			txtTags3.Text = sb3.ToString();
			txtTags4.Text = sb4.ToString();

			reader.Close();
		}

		private void SaveTags()
		{
			//set date in file name to day loaded
			string fileName = dataDirectory + "\\tags.txt";

			StreamWriter writer = new StreamWriter(fileName);

			
			// Loop through each row

			foreach (var item in txtTags1.Lines)
			{
				if (item != "")
					writer.WriteLine(item);
			}
			writer.WriteLine();

			foreach (var item in txtTags2.Lines)
			{
				if (item != "")
					writer.WriteLine(item);
			}
			writer.WriteLine();

			foreach (var item in txtTags3.Lines)
			{
				if (item != "")
					writer.WriteLine(item);
			}
			writer.WriteLine();

			foreach (var item in txtTags4.Lines)
			{
				if (item != "")
					writer.WriteLine(item);
			}

			writer.Close();
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			LoadTags();
		}
	}
}
