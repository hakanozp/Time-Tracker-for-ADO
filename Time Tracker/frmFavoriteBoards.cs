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
using System.Windows.Controls;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmFavoriteBoards : Form
    {

        ADOHelper ado = new ADOHelper();
        public string dataDirectory;

        public frmFavoriteBoards()
        {
            InitializeComponent();
        }

        private void frmFavoriteBoards_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProjects();
                LoadFavoriteBoards();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error getting project/board list! /n" + exc.Message);
            }
        }
        private void LoadProjects()
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
            if (key != null)
            {
                //set the parameters for ADO
                ado.OrganizationUrl = key.GetValue("OrganizationUrl").ToString();
                ado.PersonalAccessToken = key.GetValue("PersonalAccessToken").ToString();
            }

            Dictionary<Guid, string> projectList;
            projectList = ado.GetProjectList();

            //projectList.Add(0, "");
            //var sortedDict = projectList.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            cmbProject.DataSource = projectList.ToList();
            cmbProject.DisplayMember = "Value";
            cmbProject.ValueMember = "Key";
        }

        private void LoadBoardList(Guid projectId)
        {
            List<String> boardList;
            //get list of boards
            boardList = ado.GetBoardList(projectId);

            //populate combobox using list
            lstAllBoards.DataSource = boardList.ToList();
            lstAllBoards.DisplayMember = "Value";
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<Guid, string> selectedProject = (KeyValuePair<Guid, string>)cmbProject.SelectedItem;
            Guid projectId = selectedProject.Key;

            LoadBoardList(projectId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!lstFavoriteBoards.Items.Contains(lstAllBoards.SelectedItem.ToString()))
            {
                lstFavoriteBoards.Items.Add(lstAllBoards.SelectedItem);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstFavoriteBoards.Items.RemoveAt(lstFavoriteBoards.SelectedIndex);
        }

        private void lstAllBoards_DoubleClick(object sender, EventArgs e)
        {
            if (!lstFavoriteBoards.Items.Contains(lstAllBoards.SelectedItem.ToString()))
            {
                lstFavoriteBoards.Items.Add(lstAllBoards.SelectedItem);
            }
        }

        private void lstFavoriteBoards_DoubleClick(object sender, EventArgs e)
        {
            lstFavoriteBoards.Items.RemoveAt(lstFavoriteBoards.SelectedIndex);
        }

        private void frmFavoriteBoards_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveFavoriteBoards();
        }

        private void SaveFavoriteBoards()
        {
            //set date in file name to day loaded
            string fileName = dataDirectory + "\\boards.txt";

            StreamWriter writer = new StreamWriter(fileName);

            // Loop through each row
            foreach (var item in lstFavoriteBoards.Items)
            {
                // Write the line to the file
                writer.WriteLine(item.ToString());
            }
            writer.Close();
        }

        private void LoadFavoriteBoards()
        {
            string fileName = dataDirectory + "\\boards.txt";
            if (!File.Exists(fileName)) return;

            lstFavoriteBoards.Items.Clear(); //clear existing data in list

            StreamReader reader = new StreamReader(fileName);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lstFavoriteBoards.Items.Add((string)line);
            }

            reader.Close();
        }

    }
}
