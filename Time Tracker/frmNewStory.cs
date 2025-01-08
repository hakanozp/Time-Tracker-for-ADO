using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmNewStory : Form
    {
        public string projectName;
        public string areaPath;
        public string assignedTo;
        public ADOHelper ado;

        public frmNewStory()
        {
            InitializeComponent();
        }

        private void frmNewStory_Load(object sender, EventArgs e)
        {
            _ = LoadFeaturesAsync(areaPath);
        }


        private async Task LoadFeaturesAsync(string areaPath)
        {
            cmbFeature.DataSource = null;
            cmbFeature.Items.Clear();
            Dictionary<int, string> storyList = new Dictionary<int, string>();

            var workItems = await ado.GetItemList("Feature", areaPath: areaPath, state: "Active");

            foreach (var workItem in workItems)
            {
                storyList.Add(Convert.ToInt32(workItem.Id), workItem.Id.ToString() + " - " + workItem.Fields["System.Title"].ToString());
            }

            if (storyList.Count > 0)
            {
                storyList.Add(0, "");
                var sortedDict = storyList.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                cmbFeature.DataSource = sortedDict.ToList();
                cmbFeature.DisplayMember = "Value";
                cmbFeature.ValueMember = "Key";
            }
        }

        private void btnAddStory_Click(object sender, EventArgs e)
        {
            AddNewStory();
        }

        private void AddNewStory()
        {
            if (cmbFeature.SelectedIndex == 0)
            {
                MessageBox.Show("You must select a parent feature!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("You must enter a title for the story!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ADOTask newItem = new ADOTask();

            // set the necessary fields for creating ADO item
            newItem.ItemType = "User Story";
            newItem.AssignedTo = assignedTo;
            newItem.Title = txtTitle.Text;
            newItem.Description = txtDescription.Text;
            newItem.State = "Active"; // initial state must be NEW!
            newItem.IterationPath = "PBI_DS\\PBI";
            newItem.AreaPath = areaPath;
            newItem.ParentId = cmbFeature.SelectedValue.ToString();

            try
            {
                int itemId = ado.CreateUserStory(newItem);

                MessageBox.Show("User story created, please refresh story list to see it!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbFeature.SelectedIndex = -1;
                txtTitle.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                    MessageBox.Show("Error in creating user story!/n" + exc.InnerException.Message);
                else
                    MessageBox.Show("Error in creating user story!/n" + exc.Message);
            }

            
        }
    }
}
