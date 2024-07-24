using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        DBHelper db = new DBHelper();


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
            try
            {
                List<string> boardNames = lstFavoriteBoards.Items.Cast<string>().ToList();
				db.SaveFavoriteBoards(boardNames);
			
            }
            catch (Exception exc)
            {
				MessageBox.Show("Error in saving favorite boards! /n" + exc.Message);
			}
        }

        private void LoadFavoriteBoards()
        {

            try
            {
				SQLiteDataReader reader = db.LoadFavoriteBoards();
                while (reader.Read())
                {
					lstFavoriteBoards.Items.Add(reader["BoardName"].ToString());
				}
			}
            catch (Exception exc)
            {
				MessageBox.Show("Error in loading favorite boards! /n" + exc.Message);
			}
        }

    }
}
