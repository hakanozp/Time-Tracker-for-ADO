using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Timers;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Threading;
using Microsoft.Win32;
using System.Deployment.Application;
using System.Data.SQLite;
using System.ComponentModel;


namespace TimeTracker
{

    public partial class frmTracker : Form
    {

        private System.Timers.Timer timer;
        private TimeSpan elapsedTime;

        private string itemTags;
        private string assignedTo;
        private bool isTimerRunning;
        private bool isTimerPaused = false;
        private bool isSettingsOk = false;
		private List<string> areaPathsList = new List<string>();
        private string wbsRun = string.Empty;
        private string wbsProject = string.Empty;
        private bool gridCellValueChanged = false;

		ADOHelper ado = new ADOHelper();
        DBHelper db = new DBHelper();

		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		public frmTracker()
        {
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.CurrentCulture = culture;

        }

        private void frmTracker_Load(object sender, EventArgs e)
        {

			try
            {
				db.CreateTables();
			}
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                throw exc;
            }
            

            timer = new System.Timers.Timer();
            timer.Interval = 1000; // Set the timer interval to 1 second
            timer.Elapsed += Timer_Elapsed; // Add the event handler for the timerbn
            elapsedTime = TimeSpan.Zero; // Set the elapsed time to zero

            //Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            //System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
            if (key != null)
            {
                //set the parameters for ADO
                ado.Organization = key.GetValue("Organization").ToString();
                ado.OrganizationUrl = key.GetValue("OrganizationUrl").ToString();
                ado.PersonalAccessToken = key.GetValue("PersonalAccessToken").ToString();
                assignedTo = key.GetValue("User").ToString();

				if (key.GetValue("WBSRUN") != null)
					wbsRun = key.GetValue("WBSRUN").ToString() + "-RUN";

				if (key.GetValue("WBSPROJECT") != null)
					wbsProject = key.GetValue("WBSPROJECT").ToString() + "-PROJECT";
			}
            
            isSettingsOk = !(String.IsNullOrWhiteSpace(ado.Organization) ||
                            String.IsNullOrWhiteSpace(ado.OrganizationUrl) ||
                            String.IsNullOrWhiteSpace(ado.PersonalAccessToken) ||
                            String.IsNullOrWhiteSpace(assignedTo));
            

            //load existing projects for the user
            if (isSettingsOk)
            {
                try
                {
                    LoadProjects();

					ado.Project = cmbProject.Text;

					_ = LoadAreaPathsAsync();
				}
                catch (Exception exc)
                {
                    if (exc.InnerException != null)
                        MessageBox.Show("Error in loading projects!/n" + exc.InnerException.Message);
                    else
                        MessageBox.Show("Error in loading projects!/n" + exc.Message);
                }

				LoadTimeEntries(DateTime.Now);
				LoadTags();

            }
            slDate.Text = DateTime.Now.ToString("d", currentCulture);
			slUser.Text = assignedTo;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                slVersion.Text = "Ver: " + version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Revision.ToString();
            }

            cmbItemType.SelectedIndex = 0;
            cmbState.SelectedIndex = 0; 
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbState.Text == "New")
            {
                return;
            }
                        
            if (isTimerRunning)
            {
                MessageBox.Show("Timer has already started!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }

            if (rbCreateNew.Checked)
            {
                if (cmbBoard.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a board!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbArea.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a area path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbIteration.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a iteration!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbStory.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a parent story!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

				if (txtOriginalEstimate.Text== "__:__" || txtOriginalEstimate.Text == "00:00")
				{
					MessageBox.Show("You must enter an original estimate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (txtTitle.Text == "")
                {
                    MessageBox.Show("You must enter a title!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (cmbWbsCode.Text == string.Empty)
                //{
                //    MessageBox.Show("You must select a WBS breakdown!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            }
            else if (rbUpdateTask.Checked)
            {
                if (cmbBoard.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a board!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbArea.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a area path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbIteration.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a iteration!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbTask.SelectedIndex <= 0)
                {
                    MessageBox.Show("You must select a " + cmbItemType.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

			isTimerRunning = true;
            if (isTimerPaused)
            {
                isTimerPaused = false;
            }
            else
            {
                lblStartTime.Text = DateTime.Now.ToString("HH\\:mm");
                txtStartTime.Text = DateTime.Now.ToString("HH\\:mm");
            }
            timer.Start(); // Start the timer

            btnStart.Enabled = false;
            btnStart.Text = "Start";
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnCancel.Enabled = true;

            rbCreateNew.Enabled = false;
            rbUpdateTask.Enabled = false;

            grpMain.Enabled = false;
            grpNewItem.Enabled = false; 
            grpExistingItem.Enabled = false;
            grpText.Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!isTimerRunning)
            {
                MessageBox.Show("Timer is not started!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isTimerRunning = false;
            isTimerPaused = true;
            timer.Stop(); // Stop the timer

            btnStart.Enabled = true;
            btnStart.Text = "Resume";
            btnPause.Enabled = false;
            btnStop.Enabled= true;   
            btnCancel.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cmbState.Text == "Active" && (!isTimerRunning && !isTimerPaused))
            {
                MessageBox.Show("Timer is not started!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbState.Text == "New")
            {
				if (cmbBoard.SelectedIndex <= 0)
				{
					MessageBox.Show("You must select a board!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (cmbArea.SelectedIndex <= 0)
				{
					MessageBox.Show("You must select a area path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (cmbIteration.SelectedIndex <= 0)
				{
					MessageBox.Show("You must select a iteration!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (cmbStory.SelectedIndex <= 0)
				{
					MessageBox.Show("You must select a parent story!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				//if (cmbWbsCode.Text == string.Empty)
				//{
				//	MessageBox.Show("You must select a WBS breakdown!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//	return;
				//}
				if (txtTitle.Text == "")
				{
					MessageBox.Show("You must enter a title!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

            timer.Stop(); // Stop the timer
            elapsedTime = TimeSpan.Zero; // Reset the elapsed time
            isTimerRunning = false;
            isTimerPaused = false;

            //add time entry to the list
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgEntries);

            row.Cells[dgEntries.Columns["colCategory"].Index].Value = cmbCategory.Text;
            row.Cells[dgEntries.Columns["colStartTime"].Index].Value = lblStartTime.Text;
            row.Cells[dgEntries.Columns["colEndTime"].Index].Value = DateTime.Now.ToString("HH\\:mm"); ;
            row.Cells[dgEntries.Columns["colDuration"].Index].Value = Convert.ToDateTime(lblDuration.Text).ToString("HH\\:mm");
            row.Cells[dgEntries.Columns["colCreateDate"].Index].Value = DateTime.Now.ToString("d", currentCulture);

			if (rbCreateNew.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = string.Empty;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = txtTitle.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text.Replace("\r\n", "<br>");
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = cmbItemType.Text;
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colStory"].Index].Value = cmbStory.Text;
                row.Cells[dgEntries.Columns["colParentId"].Index].Value = cmbStory.SelectedValue != null ? cmbStory.SelectedValue.ToString() : String.Empty;
                row.Cells[dgEntries.Columns["colTags"].Index].Value = CreateTagList();
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Create";
                row.Cells[dgEntries.Columns["colStartDate"].Index].Value = dtStartDate.Value.ToString("d", currentCulture);
				row.Cells[dgEntries.Columns["colTargetDate"].Index].Value = dtTargetDate.Value.ToString("d", currentCulture);

				//txtOriginalEstimate.Text = txtOriginalEstimate.Text.Replace('_', '0');
                row.Cells[dgEntries.Columns["colOriginalEstimate"].Index].Value = txtOriginalEstimate.Text.Replace('_', '0');
                row.Cells[dgEntries.Columns["colUpdateOrgEst"].Index].Value = chkUpdateOriginal.Checked;
                row.Cells[dgEntries.Columns["colState"].Index].Value = cmbState.Text;
				row.Cells[dgEntries.Columns["colWbsCode"].Index].Value = cmbWbsCode.Text;


			}
			else if (rbUpdateTask.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = cmbTask.SelectedValue;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = cmbTask.Text.Substring(cmbTask.Text.IndexOf("-") + 2);
                //row.Cells[dgEntries.Columns["colTitle"].Index].Value = cmbTask.Text.Split('-').Length == 2 ? cmbTask.Text.Split('-')[1].Trim() : cmbTask.Text.Split('-')[2].Trim();
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = cmbItemType.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text.Replace("\r\n", "<br>");
                row.Cells[dgEntries.Columns["colTags"].Index].Value = CreateTagList();
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Update";
                row.Cells[dgEntries.Columns["colTargetDate"].Index].Value = dtTargetDate.Value.ToString("d", currentCulture);
				row.Cells[dgEntries.Columns["colUpdateOrgEst"].Index].Value = chkUpdateOriginal.Checked;
			}

            dgEntries.Rows.Add(row);
            dgEntries.Sort(dgEntries.Columns["colStartTime"], ListSortDirection.Ascending);
            lblDuration.Text = "00:00:00"; // Reset the label text
            CalculateTotalDuration();


            if (cmbState.Text == "Active")
            {
                btnStart.Enabled = true;
                btnStart.Text = "Start";
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                btnCancel.Enabled = false;
            }

			txtTitle.Text = "";
			txtDescription.Text = "";
			txtStartTime.Text = "";
			cmbCategory.SelectedIndex = -1;
			cmbWbsCode.SelectedIndex = -1;
			chkCloseItem.Checked = false;
			chkUpdateOriginal.Checked = false;
			txtOriginalEstimate.Text = "";
			dtStartDate.Value = DateTime.Now.Date;
			dtTargetDate.Value = DateTime.Now.Date;
			cmbTask.SelectedIndex = -1;
			gridCellValueChanged = true;

            rbCreateNew.Enabled = true;
            rbUpdateTask.Enabled = true;

			grpMain.Enabled = true;
			grpNewItem.Enabled = true;
			grpExistingItem.Enabled = true;
			grpText.Enabled = true;

            if (rbUpdateTask.Checked)
            {                
                rbUpdateTask_CheckedChanged(this, EventArgs.Empty);
            }
            else if (rbCreateNew.Checked)
            { 
                rbCreateNew_CheckedChanged(this, EventArgs.Empty);
            }
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblDuration.Text = "00:00:00";
            timer.Stop(); 
            elapsedTime = TimeSpan.Zero; 
            isTimerRunning = false;
            isTimerPaused = false;

            btnStart.Enabled = true;
            btnStart.Text = "Start";
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = false;
            txtStartTime.Text = "";

            rbCreateNew.Enabled = true;
            rbUpdateTask.Enabled = true;

            grpMain.Enabled = true;
            grpNewItem.Enabled = true;
            grpExistingItem.Enabled = true;
            grpText.Enabled = true;

            if (rbUpdateTask.Checked)
            {
                rbUpdateTask_CheckedChanged(this, EventArgs.Empty);
            }
            else if (rbCreateNew.Checked)
            {
                rbCreateNew_CheckedChanged(this, EventArgs.Empty);
            }


        }

        // This method is called when the timer interval elapses
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            elapsedTime += TimeSpan.FromSeconds(1); // Increment the elapsed time by 1 second
            Invoke(new Action(UpdateLabel)); // Invoke the method to update the label on the UI thread            
        }

        // This method updates the label with the formatted time string
        private void UpdateLabel()
        {
            lblDuration.Text = elapsedTime.ToString(@"hh\:mm\:ss"); // Format the elapsed time as hh:mm:ss
            //this.Text = "Time Tracker / " + elapsedTime.ToString(@"HH\:mm");
        }

        private void cmbBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoard.SelectedIndex > 0)
            {
                SetAreaPath(cmbBoard.Text);

                cmbStory.DataSource = null;
                cmbStory.Items.Clear();
            }
        }

        private void btnDeleteRows_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you ure to delete the selected row?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            if (dgEntries.SelectedRows.Count > 0)
            {
                dgEntries.Rows.RemoveAt(dgEntries.SelectedRows[0].Index);
				gridCellValueChanged = true;
				return;
            }

            if (dgEntries.SelectedCells.Count > 0)
            {
                MessageBox.Show("You must select a row to delete it!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<Guid, string> selectedProject = (KeyValuePair<Guid, string>)cmbProject.SelectedItem;
            Guid projectId = selectedProject.Key;

            LoadBoardList(projectId);

            //_ = LoadAreaPathsAsync();

            LoadIterationList(projectId);
        }

        private void LoadProjects()
        {
            Dictionary<Guid, string> projectList;
            projectList = ado.GetProjectList();

            //projectList.Add(0, "");
            //var sortedDict = projectList.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            cmbProject.DataSource = projectList.ToList();
            cmbProject.DisplayMember = "Value";
            cmbProject.ValueMember = "Key";
        }

        private async Task LoadStoriesAsync(string areaPath)
        {
            cmbStory.DataSource = null;
            cmbStory.Items.Clear();
            Dictionary<int, string> storyList = new Dictionary<int, string>();

            var workItems = await ado.GetItemList("User Story", areaPath: areaPath, state: "Active");

            foreach (var workItem in workItems)
            {
                //Console.WriteLine(
                //    "{0}\t{1}\t{2}\t{3}",
                //    workItem.Id,
                //    workItem.Fields["System.Title"],
                //    workItem.Fields["System.State"],
                //    workItem.Fields["System.AreaPath"]);

                storyList.Add(Convert.ToInt32(workItem.Id), workItem.Id.ToString() + " - " + workItem.Fields["System.Title"].ToString());
            }

            if (storyList.Count > 0)
            {
                storyList.Add(0, "");
                var sortedDict = storyList.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                cmbStory.DataSource = sortedDict.ToList();
                cmbStory.DisplayMember = "Value";
                cmbStory.ValueMember = "Key";
            }
        }

        private void LoadBoardList(Guid projectId)
        {
            List<String> boardList;
            
            boardList = LoadMyFavoriteBoards();
            if (boardList.Count == 0)
				boardList = ado.GetBoardList(projectId);

			//populate combobox using list
			cmbBoard.DataSource = boardList.ToList();
            cmbBoard.DisplayMember = "Value";
        }

        private void LoadIterationList(Guid projectId)
        {
            List<String> iterationList;
            //get list of iterations
            iterationList = ado.GetIterationList(projectId);

            //populate combobox using list
            cmbIteration.DataSource = iterationList.ToList();
            cmbIteration.DisplayMember = "Value";       
            
            //select the iteration appropriate for current date.
            cmbIteration.SelectedIndex = FindCurrentIterationIndex(iterationList);
        }

        private async Task LoadAreaPathsAsync()
        {
			//get list of area paths from epics. Epic count is less when compared to other item.
			//bigger count causes issue in loading data.
			var workItems = await ado.GetItemList("Epic");

            foreach (var workItem in workItems)
            {
				areaPathsList.Add(workItem.Fields["System.AreaPath"].ToString());
            }

			//sort the list
			areaPathsList = areaPathsList.Distinct().ToList();
			areaPathsList.Sort();

        }

        private void SetAreaPath(string board)
        {
			//clear combo first.
			cmbArea.DataSource = null;
			cmbArea.Items.Clear();

			List<string> areaList = new List<string>();

            //get area paths containing board name
			foreach (var areaPath in areaPathsList)
            {
				if (areaPath.Contains(board))
				{
					areaList.Add(areaPath);
				}
			}
            
            //if there is no corresponding name populate the full list, so user can choose.
            if (areaList.Count == 0) 
            {
                foreach (var areaPath in areaPathsList)
                {
                    areaList.Add(areaPath);
                }

            }

            areaList.Insert(0, "");

			//populate combo box using list.
			cmbArea.DataSource = areaList.ToList();
			cmbArea.DisplayMember = "Value";
		}

        private void SaveTimeEntriesToAdo()
        {
            DateTime dt;

            foreach (DataGridViewRow row in dgEntries.Rows)
            {
                if (row.Cells["colSaved"].Value != null && Convert.ToBoolean(row.Cells["colSaved"].Value.ToString()) == true) continue;

                switch (row.Cells["colOperationMode"].Value.ToString())
                {
                    case "Create":

                        ADOTask newItem = new ADOTask();

                        // set the necessary fields for creating ADO item
                        newItem.ItemType = row.Cells["colItemType"].Value.ToString();
                        newItem.AssignedTo = assignedTo;
                        newItem.Title = row.Cells["colTitle"].Value.ToString();
                        newItem.Description = row.Cells["colDescription"].Value.ToString();
                        newItem.State = "New"; // initial state must be NEW!
                        newItem.IterationPath = row.Cells["colIteration"].Value.ToString();
                        newItem.AreaPath = row.Cells["colAreaPath"].Value.ToString();

                        //DateTime.TryParseExact(row.Cells["colStartDate"].Value.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime)
                        DateTime.TryParseExact(row.Cells["colStartDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        newItem.StartDate = dt;

                        DateTime.TryParseExact(row.Cells["colTargetDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        newItem.TargetDate = dt;

                        newItem.OriginalEstimate = CalculateHour(row.Cells["colOriginalEstimate"].Value.ToString());
                        newItem.CompletedWork = CalculateHour(row.Cells["colDuration"].Value.ToString());
                        newItem.ParentUserStoryId = row.Cells["colParentId"].Value.ToString();
                        newItem.Tags = row.Cells["colTags"].Value.ToString();
                        newItem.History = "Created by Time Tracker for ADO at " + DateTime.Now.ToString();
                        if (row.Cells["colUpdateOrgEst"].Value != null)
                        {
                            newItem.UpdateOriginalEstimate = Convert.ToBoolean(row.Cells["colUpdateOrgEst"].Value.ToString());
                        }

                        if (newItem.UpdateOriginalEstimate == true)
                            newItem.OriginalEstimate = newItem.CompletedWork;

                        //if (row.Cells["colWbsCode"].Value != null && row.Cells["colWbsCode"].Value.ToString() != "")
                        //{
                        //    if (row.Cells["colWbsCode"].Value.ToString().Contains("Run"))
                        //        newItem.WBS = wbsRun;
                        //    else if (row.Cells["colWbsCode"].Value.ToString().Contains("Project"))
                        //        newItem.WBS = wbsProject;
                        //}
                        //else
                        //{
                        //    newItem.WBS = string.Empty;
                        //}

                        if (row.Cells["colWbsCode"].Value != null && row.Cells["colWbsCode"].Value.ToString() != "")
                        {
                            newItem.WBS = row.Cells["colWbsCode"].Value.ToString();
                        }

                        //create the ADO item
                        int itemId = ado.CreateAdoItem(newItem);

                        //set item status again
                        bool closeItem = Convert.ToBoolean(row.Cells["colCloseItem"].Value.ToString());
						if (row.Cells["colState"].Value.ToString() == "Active")
                        { 
                            newItem.State = closeItem ? "Closed" : "Active";
                            ado.SetItemState(itemId, newItem.State);
                        }

                        //update the item id
                        row.Cells["colItemId"].Value = itemId.ToString();

                        db.SaveNewItem(itemId, newItem.WBS, row.Cells["colCategory"].Value.ToString());
                        
                        break;
                    case "Update":
                        ADOTask updateItem = new ADOTask();

                        updateItem.Id = Convert.ToInt32(row.Cells["colItemId"].Value.ToString());
                        
                        DateTime.TryParseExact(row.Cells["colTargetDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        updateItem.TargetDate = dt;

                        updateItem.IterationPath = row.Cells["colIteration"].Value.ToString();
                        updateItem.CompletedWork = CalculateHour(row.Cells["colDuration"].Value.ToString());
                        updateItem.History = row.Cells[dgEntries.Columns["colDescription"].Index].Value.ToString();
                        updateItem.UpdateOriginalEstimate = Convert.ToBoolean(row.Cells["colUpdateOrgEst"].Value.ToString());
                        
                        _ = ado.UpdateTaskAsync(updateItem);

                        closeItem = Convert.ToBoolean(row.Cells["colCloseItem"].Value.ToString());
                        if (closeItem == true)
                            ado.SetItemState(updateItem.Id, "Closed");
                        else
							ado.SetItemState(updateItem.Id, "Active");

						break;
                    
                    default:
                        break;
                }

                row.Cells["colSaved"].Value = true;
                row.SetValues();

                Thread.Sleep(2000);
            }
        }

        private void SaveTimeEntries()
        {
			TimeEntry timeEntry = new TimeEntry();
            DateTime dt;
            
			foreach (DataGridViewRow row in dgEntries.Rows)
			{
				if (row.Cells["colItemId"].Value != null && row.Cells["colItemId"].Value.ToString() != "")
					timeEntry.ItemId = Convert.ToInt32(row.Cells["colItemId"].Value.ToString());

				timeEntry.Category = row.Cells["colCategory"].Value.ToString();
				timeEntry.StartTime = row.Cells["colStartTime"].Value.ToString();
				timeEntry.EndTime = row.Cells["colEndTime"].Value.ToString();
				timeEntry.Duration = row.Cells["colDuration"].Value.ToString();

                DateTime.TryParseExact(row.Cells["colCreateDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                timeEntry.CreateDate = dt;

				timeEntry.Title = row.Cells["colTitle"].Value.ToString();
				timeEntry.Project = row.Cells["colProject"].Value.ToString();
				timeEntry.Board = row.Cells["colBoard"].Value.ToString();
				timeEntry.AreaPath = row.Cells["colAreaPath"].Value.ToString();
				timeEntry.ItemType = row.Cells["colItemType"].Value.ToString();
				timeEntry.Description = row.Cells["colDescription"].Value.ToString();
				timeEntry.Iteration = row.Cells["colIteration"].Value.ToString();
				timeEntry.Tags = row.Cells["colTags"].Value.ToString();
				timeEntry.OperationMode = row.Cells["colOperationMode"].Value.ToString();
				timeEntry.CloseItem = Convert.ToBoolean(row.Cells["colCloseItem"].Value.ToString());
				timeEntry.UpdateOrgEst = Convert.ToBoolean(row.Cells["colUpdateOrgEst"].Value.ToString());

				if (row.Cells["colSaved"].Value != null && row.Cells["colSaved"].Value.ToString() != "")
					timeEntry.Saved = Convert.ToBoolean(row.Cells["colSaved"].Value.ToString());

				DateTime.TryParseExact(row.Cells["colTargetDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
				timeEntry.TargetDate = dt;

                if (row.Cells["colOperationMode"].Value.ToString() == "Create")
                {
					timeEntry.Story = row.Cells["colStory"].Value.ToString();
					timeEntry.ParentId = Convert.ToInt32(row.Cells["colParentId"].Value.ToString());

					DateTime.TryParseExact(row.Cells["colStartDate"].Value.ToString(), "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
					timeEntry.StartDate = dt;

					timeEntry.OriginalEstimate = row.Cells["colOriginalEstimate"].Value.ToString();
					if (row.Cells["colWbsCode"].Value != null && row.Cells["colWbsCode"].Value.ToString() != "")
						timeEntry.WbsCode = row.Cells["colWbsCode"].Value.ToString();
					
                    timeEntry.State = row.Cells["colState"].Value.ToString();
				}

                db.SaveTimeEntry(timeEntry);
                timeEntry.Clear();
			}
		}

        private void LoadTimeEntries(DateTime selectedDate)
        {
            //clear existing rows
            dgEntries.RowCount = 0;

            string sql = "SELECT * FROM TimeEntries WHERE CreateDate = '" + selectedDate.ToString("yyyy\\-MM\\-dd 00:00:00") + "'";

            try
            {
                //read the time entries from DB
                SQLiteDataReader reader = db.LoadTimeEntries(sql);

				while (reader.Read())
                {
                    int rowIndex = dgEntries.Rows.Add();
                    DataGridViewRow row = dgEntries.Rows[rowIndex];

                    row.Cells["colCategory"].Value = reader["Category"].ToString();
                    if (Convert.ToInt32(reader["ItemId"]) != 0)
                        row.Cells["colItemId"].Value = Convert.ToInt32(reader["ItemId"]);
                    row.Cells["colItemType"].Value = reader["ItemType"].ToString();
                    row.Cells["colTitle"].Value = reader["Title"].ToString();
                    row.Cells["colBoard"].Value = reader["Board"].ToString();
                    row.Cells["colStory"].Value = reader["Story"].ToString();
                    row.Cells["colStartTime"].Value = reader.GetString(reader.GetOrdinal("StartTime"));
                    row.Cells["colEndTime"].Value = reader.GetString(reader.GetOrdinal("EndTime"));
                    row.Cells["colDuration"].Value = reader.GetString(reader.GetOrdinal("Duration"));
                    row.Cells["colTags"].Value = reader["Tags"].ToString();
                    row.Cells["colDescription"].Value = reader["Description"].ToString();
                    row.Cells["colProject"].Value = reader["Project"].ToString();
                    row.Cells["colAreaPath"].Value = reader["AreaPath"].ToString();
                    row.Cells["colIteration"].Value = reader["Iteration"].ToString();
                    row.Cells["colCloseItem"].Value = Convert.ToBoolean(reader["CloseItem"]);

                    if (Convert.ToInt32(reader["ParentId"]) != 0)
                        row.Cells["colParentId"].Value = Convert.ToInt32(reader["ParentId"]);
                    row.Cells["colCreateDate"].Value = reader.GetDateTime(reader.GetOrdinal("CreateDate")).ToString("d", currentCulture);
					row.Cells["colOperationMode"].Value = reader["OperationMode"].ToString();
                    row.Cells["colSaved"].Value = Convert.ToBoolean(reader["Saved"]);
                    if (reader["StartDate"].ToString() != string.Empty)
                        row.Cells["colStartDate"].Value = reader.GetDateTime(reader.GetOrdinal("StartDate")).ToString("d", currentCulture);

                    row.Cells["colTargetDate"].Value = reader.GetDateTime(reader.GetOrdinal("TargetDate")).ToString("d", currentCulture);

                    if (!reader.IsDBNull(reader.GetOrdinal("OriginalEstimate")))
                        row.Cells["colOriginalEstimate"].Value = reader.GetString(reader.GetOrdinal("OriginalEstimate"));
                    row.Cells["colUpdateOrgEst"].Value = Convert.ToBoolean(reader["UpdateOrgEst"]);
                    row.Cells["colWbsCode"].Value = reader["WbsCode"].ToString();
                    row.Cells["colState"].Value = reader["State"].ToString();
                }
                CalculateTotalDuration();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
		}

		private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadStoriesAsync(cmbArea.Text);

                _ = LoadTasksAsync(cmbArea.Text, cmbItemType.Text);
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmSettings f2 = new frmSettings(); //this is the change, code for redirect  
			f2.ShowDialog();
        }

        private void rbCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            txtTitle.Enabled = true;
            grpMain.Enabled = true;
            grpNewItem.Enabled = true;
            grpExistingItem.Enabled = false;

            chkCloseItem.Checked = false;
            chkCloseItem.Enabled = true;
            lblItemText.Text = "Description";

            //btnListActiveItems.Enabled = false;
		}
        private void rbUpdateTask_CheckedChanged(object sender, EventArgs e)
        {
			btnStart.Visible = true;
			btnPause.Visible = true;
			btnStop.Text = "Stop";
            btnStop.Enabled = false;
			btnCancel.Visible = true;
			lblDuration.Visible = true;
            cmbState.SelectedIndex = 0;

			txtTitle.Enabled = false;
            grpMain.Enabled = true;
            grpNewItem.Enabled = false;
            grpExistingItem.Enabled = true;

            chkCloseItem.Checked = false;
            chkCloseItem.Enabled = true;
            lblItemText.Text = "Discussion";
		}

        private void rbTimeEntry_CheckedChanged(object sender, EventArgs e)
        {
			btnStart.Visible = true;
			btnPause.Visible = true;
			btnStop.Text = "Stop";
			btnStop.Enabled = false;
			btnCancel.Visible = true;
			lblDuration.Visible = true;
			cmbState.SelectedIndex = 0;

			txtTitle.Enabled = true;
            grpMain.Enabled = false;
            grpNewItem.Enabled = false;
            grpExistingItem.Enabled = false;

            chkCloseItem.Checked = false;
            chkCloseItem.Enabled = false;
            lblItemText.Text = "Description";

            //btnListActiveItems.Enabled = false;

		}
        private async Task LoadTasksAsync(string areaPath, string itemType)
        {
            cmbTask.DataSource = null;
            cmbTask.Items.Clear();
            Dictionary<int, string> taskList = new Dictionary<int, string>();

            //get list of open tasks under a given area path
            //var workItems = await ado.GetItemList(itemType, areaPath: areaPath, state: "Active", assignedToMe: true);
			var workItems = await ado.GetItemList("Task", areaPath: areaPath, assignedToMe: true);

			//add tasks to a dictionary
			foreach (var workItem in workItems)
            {
                taskList.Add(Convert.ToInt32(workItem.Id), workItem.Id.ToString() + " - " + workItem.Fields["System.Title"].ToString());
            }

			workItems = await ado.GetItemList("Bug", areaPath: areaPath, assignedToMe: true);

			//add bugs to a dictionary
			foreach (var workItem in workItems)
			{
				taskList.Add(Convert.ToInt32(workItem.Id), workItem.Id.ToString() + " - " + workItem.Fields["System.Title"].ToString());
			}

			//populate combo box using task list.
			if (taskList.Count > 0)
            {
                taskList.Add(0, "");
                var sortedDict = taskList.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                cmbTask.DataSource = sortedDict.ToList();
                cmbTask.DisplayMember = "Value";
                cmbTask.ValueMember = "Key";
            }
        }

        private int FindCurrentIterationIndex(List<String> iterationList)
        {
            int ix = -1;
            string[] dateRanges = { };

            // The format of the date strings
            string dateFormat = "yyMMdd";
            DateTime dt;

            // The culture-specific settings for the date and time values
            CultureInfo culture = CultureInfo.CurrentCulture;

            // first get only data ranges
            foreach (var iteration in iterationList) 
            {
                //if (iteration == string.Empty) continue;

                string[] values = iteration.Split('\\');

                Array.Resize(ref dateRanges, dateRanges.Length + 1);
                dateRanges[dateRanges.Length - 1] = values[values.Length - 1].Replace('-', '_');
            }

            // The current date
            DateTime today = DateTime.Today;

            // Loop through each date range
            foreach (string dateRange in dateRanges)
            {
                ix++;
                if (dateRange == string.Empty) continue;

				// Split the date range into start and end dates
				string[] dates;
				if (dateRange.Contains("_"))
					dates = dateRange.Split('_');
				else
					continue;

				// Parse the start and end dates into DateTime objects
				DateTime.TryParseExact(dates[0], dateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                DateTime startDate = dt;

                DateTime.TryParseExact(dates[1], dateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                DateTime endDate = dt;

                if (today >= startDate && today <= endDate)
                    break;
            }

            return ix;
        }

        private string CreateTagList()
        //creates semicolon separated string value from tag selections.
        {
            List<string> tagList = new List<string>();            

            if (cmbTag1.SelectedIndex != -1) 
            {
                tagList.Add(cmbTag1.Text);
            }
            if (cmbTag2.SelectedIndex != -1)
            {
                tagList.Add(cmbTag2.Text);
            }
            if (cmbTag3.SelectedIndex != -1)
            {
                tagList.Add(cmbTag3.Text);
            }
			if (cmbTag4.SelectedIndex != -1)
			{
				tagList.Add(cmbTag4.Text);
			}

			return string.Join(";", tagList.ToArray()); 
        }

        private async void cmbStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStory.SelectedIndex == 0) return;

            //clear current selections
            cmbTag1.SelectedIndex = -1;
            cmbTag2.SelectedIndex = -1;
            cmbTag3.SelectedIndex = -1;
            cmbTag4.SelectedIndex = -1;

            if (cmbStory.SelectedItem == null) return;

            KeyValuePair<int, string> selectedStory = (KeyValuePair<int, string>)cmbStory.SelectedItem;
            int storyId = selectedStory.Key;

            // get tag of selected story
            itemTags = await ado.GetItemTags(storyId);

            if (itemTags == string.Empty) return;

            // set each tag selected in related tag selection combos
            string[] tags = itemTags.Split(';');

            //for each tag search the combo boxes, if found select it
            foreach (var tag in tags)
            {
                if (cmbTag1.SelectedIndex == -1)
                    cmbTag1.SelectedIndex = GetTagIndex(cmbTag1.Items, tag.ToString().Trim());

				if (cmbTag2.SelectedIndex == -1)
					cmbTag2.SelectedIndex = GetTagIndex(cmbTag2.Items, tag.ToString().Trim());
				
                if (cmbTag3.SelectedIndex == -1)
					cmbTag3.SelectedIndex = GetTagIndex(cmbTag3.Items, tag.ToString().Trim());
				
                if (cmbTag4.SelectedIndex == -1)
					cmbTag4.SelectedIndex = GetTagIndex(cmbTag4.Items, tag.ToString().Trim());
			}
        }

        private int GetTagIndex(ComboBox.ObjectCollection items, string tag )
        {
            int index = -1;
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].ToString() == tag)
				{
					index = i;
					break;
				}
			}
            return index;
		}

        private void frmTracker_Shown(object sender, EventArgs e)
        {
            // all setting must be defined to save the timer entry
            if (!isSettingsOk)
            {
                MessageBox.Show("Settings are missing. Restart application after all settings are entered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = false;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
            }
        }

        private void dtTargetDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtTargetDate.Value.Date < dtStartDate.Value.Date)
            {
                MessageBox.Show("Target date must be after than start date!", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtTargetDate.Value = dtStartDate.Value;
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtTargetDate.Value.Date < dtStartDate.Value.Date)
            {
                MessageBox.Show("Start date must be before than target date!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtStartDate.Value = dtTargetDate.Value;
            }
        }

        private void frmTracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SaveGridToFile();
		}

        private void saveListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
				SaveTimeEntriesToAdo(); 
                
                db.DeleteTimeEntries(DateTime.Now);
				SaveTimeEntries();

				MessageBox.Show("Save completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
            gridCellValueChanged = false;
        }

        private void frmTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }

            if (gridCellValueChanged == true)
            {
                DialogResult dg = DialogResult.None;

                dg = MessageBox.Show("Do you want to save grid data?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (dg)
                {
                    case DialogResult.Yes:
                        db.DeleteTimeEntries(DateTime.Now);
                        SaveTimeEntries();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private double CalculateHour(string duration)
        {
            double totalHours = 0;

            string[] timeParts = duration.Split(':');
            //Array.Resize(ref timeParts, timeParts.Length - 1);

            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hours) && int.TryParse(timeParts[1], out int minutes))
            {
                // Convert hours and adjusted minutes to total hours with minutes as fraction of an hour
                totalHours = Math.Round(hours + (minutes / 60.0), 1);

            }
            return totalHours;
        }

        private void CalculateTotalDuration()
        {
            TimeSpan totalDuration = TimeSpan.Zero;
            TimeSpan adoDuration = TimeSpan.Zero;
            TimeSpan otherDuration = TimeSpan.Zero;

            foreach (DataGridViewRow row in dgEntries.Rows)
            {                
                if (!row.IsNewRow && row.Cells["colDuration"].Value != null)
                {
                    // Parse the duration value from the cell
                    string durationString = row.Cells["colDuration"].Value.ToString();

                    TimeSpan duration;

                    if (TimeSpan.TryParse(durationString, out duration))
                    {
                        // Add the parsed duration to the total
                        totalDuration = totalDuration.Add(duration);
                    }
                }
            }

            slTotal.Text = "Total: " + totalDuration.ToString();
        }

        private void btnRefreshTaskBug_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadTasksAsync(cmbArea.Text, cmbItemType.Text);
            }
        }

        private void btnRefreshStory_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadStoriesAsync(cmbArea.Text);
            }
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            if (gridCellValueChanged == true && MessageBox.Show("Do you want to save grid data?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                db.DeleteTimeEntries(DateTime.Now);
                SaveTimeEntries();
            }

			this.Close();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            frmAbout f2 = new frmAbout(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void mnLoadData_Click(object sender, EventArgs e)
        {

			if (isTimerRunning)
			{
				MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DateTime selectedDate = DateTime.Now;
			using (var dialogForm = new frmDateSelection())
			{

				if (dialogForm.ShowDialog() == DialogResult.OK)
				{
					// Retrieve the value from the dialog form
					selectedDate = dialogForm.selectedDate;
				}
			}

			LoadTimeEntries(selectedDate);

            slDate.Text = selectedDate.ToShortDateString();

			//do not let to start time if date is not today.
			bool isTodaysData = string.Equals(selectedDate.ToShortDateString(), DateTime.Now.ToShortDateString());

			btnStart.Enabled = isTodaysData;

		}

        private void dgEntries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime dt;

            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgEntries.Rows[e.RowIndex];
            if (row == null) return;

            ///start time and end time cells can triggrer editing
            if (e.ColumnIndex == dgEntries.Columns["colStartTime"].Index || e.ColumnIndex == dgEntries.Columns["colEndTime"].Index)
            {
                //only unsaved row can be edited
                if (row.Cells["colSaved"].Value != null && Convert.ToBoolean(row.Cells["colSaved"].Value.ToString()) == true)
                    return;

                //show time edit form
                frmChangeDuration f2 = new frmChangeDuration();
                DateTime.TryParseExact(row.Cells[dgEntries.Columns["colStartTime"].Index].Value.ToString(), "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                f2.startTime = dt;

                DateTime.TryParseExact(row.Cells[dgEntries.Columns["colEndtime"].Index].Value.ToString(), "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                f2.endTime = dt;
                f2.ShowDialog();

                row.Cells[dgEntries.Columns["colStartTime"].Index].Value = f2.startTime.ToString("HH\\:mm");
                row.Cells[dgEntries.Columns["colEndtime"].Index].Value = f2.endTime.ToString("HH\\:mm");
                row.Cells[dgEntries.Columns["colDuration"].Index].Value = f2.duration;
                row.SetValues();

                //update the total hours according to the selected file
                CalculateTotalDuration();
                dgEntries.Sort(dgEntries.Columns["colStartTime"], ListSortDirection.Ascending);

                gridCellValueChanged = true;
			}
        }

        private void mnTodoList_Click(object sender, EventArgs e)
        {
            frmTodo f2 = new frmTodo(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void btnGetFromTodoList_Click(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialogForm = new frmTodo())
            {
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the value from the dialog form
                    txtTitle.Text = dialogForm.title;
                    txtDescription.Text = dialogForm.description;
                }
            }
        }

        private void mnFavoriteBoards_Click(object sender, EventArgs e)
        {
            frmFavoriteBoards f = new frmFavoriteBoards();
            f.ShowDialog();
        }

        private List<String> LoadMyFavoriteBoards()
        {
            List<string> myFavoriteBoardList = new List<string>();

			try
			{
				SQLiteDataReader reader = db.LoadFavoriteBoards();
				while (reader.Read())
				{
					myFavoriteBoardList.Add(reader["BoardName"].ToString());
				}

				if (myFavoriteBoardList.Count > 0)
				{
					myFavoriteBoardList.Sort();
					myFavoriteBoardList.Insert(0, "");
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error in loading favorite boards! /n" + exc.Message);
			}           
			
            return myFavoriteBoardList;
		}

		private void txtStartTime_Leave(object sender, EventArgs e)
        {
            DateTime startTime;

            if (DateTime.TryParse(txtStartTime.Text, out startTime) == false)
            {
                txtStartTime.Text = lblStartTime.Text;
            }
            else 
            {
                lblStartTime.Text = txtStartTime.Text;
                lblDuration.Text = DateTime.Now.Subtract(startTime).ToString(@"hh\:mm\:ss");
                elapsedTime = DateTime.Now.Subtract(startTime);
            }
        }

        private void btnOpenBoardLink_Click(object sender, EventArgs e)
        {
            if (cmbBoard.SelectedIndex < 1) return;

            string link = String.Format("{0}/{1}/_backlogs/backlog/{2}/Stories?showParents=true", ado.OrganizationUrl, cmbProject.Text, cmbBoard.Text);
            System.Diagnostics.Process.Start(link);
        }

        private void btnOpenStoryLink_Click(object sender, EventArgs e)
        {
            if (cmbStory.SelectedIndex < 1) return;
            
            string link = String.Format("{0}/{1}/_workitems/edit//{2}", ado.OrganizationUrl, cmbProject.Text, cmbStory.Text.Split('-')[0].Trim());
            System.Diagnostics.Process.Start(link);
        }

        private void btnOpenItemLink_Click(object sender, EventArgs e)
        {
            if (cmbTask.SelectedIndex < 1) return;

            string link = String.Format("{0}/{1}/_workitems/edit//{2}", ado.OrganizationUrl, cmbProject.Text, cmbTask.Text.Split('-')[0].Trim());
            System.Diagnostics.Process.Start(link);
        }

        private void chkCloseItem_CheckedChanged(object sender, EventArgs e)
        {
            chkUpdateOriginal.Enabled = chkCloseItem.Checked;
            chkUpdateOriginal.Checked = chkCloseItem.Checked;
        }

        private void txtOriginalEstimate_Leave(object sender, EventArgs e)
        {
            txtOriginalEstimate.Text = txtOriginalEstimate.Text.Replace('_', '0');
        }

		private void btnRefreshBoard_Click(object sender, EventArgs e)
		{
			List<String> myFavoriteBoardList;
			
			myFavoriteBoardList = LoadMyFavoriteBoards();

			//populate combobox using list
			cmbBoard.DataSource = myFavoriteBoardList.ToList();
			cmbBoard.DisplayMember = "Value";
            //
		}

		private void mnStartNewDay_Click(object sender, EventArgs e)
		{
			if (isTimerRunning)
			{
				MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

            if (MessageBox.Show("Any unsaved entries will be lost, are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                slDate.Text = DateTime.Now.ToString("d", currentCulture);
				dgEntries.RowCount = 0;
                btnStart.Enabled = true;

                dtTargetDate.Value = DateTime.Now;
                dtStartDate.Value = DateTime.Now;

                slTotal.Text = "Total:";
            }
        }

		private void LoadTags()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
			if (key != null)
			{

				if (key.GetValue("TagGroup1") != null)
				{
					string[] items = key.GetValue("TagGroup1").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					cmbTag1.Items.AddRange(items.Select(item => item.Trim()).ToArray());
				}

				if (key.GetValue("TagGroup2") != null)
				{
					string[] items = key.GetValue("TagGroup2").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					cmbTag2.Items.AddRange(items.Select(item => item.Trim()).ToArray());
				}

				if (key.GetValue("TagGroup3") != null)
				{
					string[] items = key.GetValue("TagGroup3").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					cmbTag3.Items.AddRange(items.Select(item => item.Trim()).ToArray());
				}

				if (key.GetValue("TagGroup4") != null)
				{
					string[] items = key.GetValue("TagGroup4").ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					cmbTag4.Items.AddRange(items.Select(item => item.Trim()).ToArray());
				}
			}
		}

		private void btnListActiveItems_Click(object sender, EventArgs e)
		{
            ADOTask adoTask = new ADOTask();

            using (var dialogForm = new frmActiveItems())
			{
				dialogForm.ado = ado;
                dialogForm.projectName = cmbProject.Text;
                dialogForm.ShowDialog();
			}
		}

        private void dgEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgEntries.Columns["colItemId"].Index)
            {
                DataGridViewRow row = dgEntries.Rows[e.RowIndex];
                if (row.Cells["colItemId"].Value != null)
                {
                    string link = String.Format("{0}/{1}/_workitems/edit//{2}", ado.OrganizationUrl, cmbProject.Text, row.Cells[dgEntries.Columns["colItemId"].Index].Value.ToString());
                    System.Diagnostics.Process.Start(link);
                }
            }
        }

		private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblItemtype.Text = cmbItemType.Text;
            if (cmbArea.Text != string.Empty)
            {
                _ = LoadTasksAsync(cmbArea.Text, cmbItemType.Text);
            }
		}

		private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
		{
            switch (cmbState.Text)
            {
                case "Active":
                    dtStartDate.Enabled = false;
                    dtStartDate.Value = DateTime.Now.Date;
                    chkCloseItem.Enabled = true;

                    btnStart.Visible = true;
                    btnPause.Visible = true;
					btnStop.Text = "Stop";
					btnStop.Enabled = false;
					btnCancel.Visible = true;
					lblDuration.Visible = true;
					break;
                case "New":
                    dtStartDate.Enabled = true;
                    chkCloseItem.Enabled = false;

                    btnStart.Visible = false;
                    btnPause.Visible = false;
                    btnStop.Text = "Add to List";
					btnStop.Enabled = true;
					btnCancel.Visible = false;
                    lblDuration.Visible = false;
                    break;
                default:
                    break;
            }
        }

		private void dgEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

		}

        private void cmbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTask.SelectedIndex > 0)
            {
                string sql = "SELECT Category, WbsBreakdown FROM NewItems ni WHERE ni.ItemId = " + cmbTask.SelectedValue;

                SQLiteDataReader rd = db.ExecuteSQL(sql);
                if (rd.HasRows)
                {
                    rd.Read();
                    string category = rd["Category"].ToString();
                    string WbsBreakdown = rd["WbsBreakdown"].ToString();

                    cmbCategory.Text = category;
                    cmbWbsCode.Text = WbsBreakdown;


                }

            }
        }
    }
}
