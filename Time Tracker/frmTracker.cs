using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Timers;
using System.Collections.Generic;
//using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Threading;
using Microsoft.Win32;
using System.Collections;

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
        private string dataDirectory;

        ADOHelper ado = new ADOHelper();
        
        //CultureInfo culture = new CultureInfo("en-US");
        public frmTracker()
        {
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.CurrentCulture = culture;

        }

        private void frmTracker_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; // Set the timer interval to 1 second
            timer.Elapsed += Timer_Elapsed; // Add the event handler for the timerbn
            elapsedTime = TimeSpan.Zero; // Set the elapsed time to zero


            dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TimeTrackerData";
            //create data directory if not exists.
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            //isSettingsOk = CheckSettings();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Time Tracker for ADO");
            if (key != null)
            {
                //set the parameters for ADO
                ado.Organization = key.GetValue("Organization").ToString();
                ado.OrganizationUrl = key.GetValue("OrganizationUrl").ToString();
                ado.PersonalAccessToken = key.GetValue("PersonalAccessToken").ToString();
                assignedTo = key.GetValue("User").ToString();

                isSettingsOk = !(String.IsNullOrWhiteSpace(ado.Organization) ||
                                String.IsNullOrWhiteSpace(ado.OrganizationUrl) ||
                                String.IsNullOrWhiteSpace(ado.PersonalAccessToken) ||
                                String.IsNullOrWhiteSpace(assignedTo));
            }

            //load existing projects for the user
            if (isSettingsOk)
            {
                try
                {
                    LoadProjects();
                }
                catch (Exception exc)
                {
                    if (exc.InnerException != null)
                        MessageBox.Show("Error in loading projects!/n" + exc.InnerException.Message);
                    else
                        MessageBox.Show("Error in loading projects!/n" + exc.Message);
                }                

                ado.Project = cmbProject.Text;

                //SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.ConnectionString);

                //load today' s data
                string fileName = dataDirectory + "\\Entry " + DateTime.Now.ToString("yyyy\\-MM\\-dd") + ".hkn";
                LoadGridFromFile(fileName);
            }
            statusStrip1.Items[0].Text = DateTime.Now.ToString("dd\\-MM\\-yyyy");
            statusStrip1.Items[4].Text = assignedTo;

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
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
                if (txtTitle.Text == "")
                {
                    MessageBox.Show("You must enter a title!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                    MessageBox.Show("You must select a " + (rbTask.Checked ? "task!" : "bug!"), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (rbTimeEntry.Checked)
            {
                if (txtTitle.Text == "")
                {
                    MessageBox.Show("You must enter a title!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!isTimerRunning && !isTimerPaused)
            {
                MessageBox.Show("Timer is not started!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            row.Cells[dgEntries.Columns["colCreateDate"].Index].Value = DateTime.Now.ToString("dd\\-MM\\-yyyy");

            if (rbCreateNew.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = string.Empty;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = txtTitle.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text.Replace("\r\n", "<br>");
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = rbTask.Checked ? "Task" : "Bug";
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colStory"].Index].Value = cmbStory.Text;
                row.Cells[dgEntries.Columns["colParentId"].Index].Value = cmbStory.SelectedValue != null ? cmbStory.SelectedValue.ToString() : String.Empty;
                row.Cells[dgEntries.Columns["colTags"].Index].Value = CreateTagList();
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Create";
                row.Cells[dgEntries.Columns["colStartDate"].Index].Value = dtStartDate.Value.ToString("dd\\-MM\\-yyyy");
                row.Cells[dgEntries.Columns["colTargetDate"].Index].Value = dtTargetDate.Value.ToString("dd\\-MM\\-yyyy");

                txtOriginalEstimate.Text = txtOriginalEstimate.Text.Replace('_', '0');
                row.Cells[dgEntries.Columns["colOriginalEstimate"].Index].Value = Convert.ToDateTime(txtOriginalEstimate.Text).ToString("HH\\:mm");
            }
            else if (rbUpdateTask.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = cmbTask.SelectedValue;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = cmbTask.Text.Substring(cmbTask.Text.IndexOf("-") + 2);
                //row.Cells[dgEntries.Columns["colTitle"].Index].Value = cmbTask.Text.Split('-').Length == 2 ? cmbTask.Text.Split('-')[1].Trim() : cmbTask.Text.Split('-')[2].Trim();
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = rbTask.Checked ? "Task" : "Bug";
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text.Replace("\r\n", "<br>");
                row.Cells[dgEntries.Columns["colTags"].Index].Value = CreateTagList();
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Update";
                row.Cells[dgEntries.Columns["colTargetDate"].Index].Value = dtTargetDate.Value.ToString("dd\\-MM\\-yyyy");
                row.Cells[dgEntries.Columns["colUpdateOrgEst"].Index].Value = chkUpdateOriginal.Checked;
            }
            if (rbTimeEntry.Checked)
            {
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = txtTitle.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = string.Empty;
            }

            dgEntries.Rows.Add(row);

            lblDuration.Text = "00:00:00"; // Reset the label text
            CalculateTotalDuration();

            btnStart.Enabled = true;
            btnStart.Text = "Start";
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = false;

            txtTitle.Text = "";
            txtDescription.Text = "";
            txtStartTime.Text = "";
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
                _ = LoadAreaPathsAsync(cmbBoard.Text);

                cmbStory.DataSource = null;
                cmbStory.Items.Clear();
            }
        }

        private void btnDeleteRows_Click(object sender, EventArgs e)
        {
            if (dgEntries.SelectedRows.Count > 0)
            {
                dgEntries.Rows.RemoveAt(dgEntries.SelectedRows[0].Index);
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
            List<String> myFavoriteBoardList;

            //get list of boards
            boardList = ado.GetBoardList(projectId);

            myFavoriteBoardList = LoadMyFavoriteBoards();

            //populate combobox using list
            cmbBoard.DataSource = myFavoriteBoardList.Count == 0 ? boardList.ToList() : myFavoriteBoardList.ToList();
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

        private async Task LoadAreaPathsAsync(string board)
        {
            //clear combo first.
            cmbArea.DataSource = null;
            cmbArea.Items.Clear();
            List<string> areaList = new List<string>();

            //get list of area paths from epics. Epic count is less when compared to other item.
            //bigger count causes issue in loading data.
            var workItems = await ado.GetItemList("Epic");

            foreach (var workItem in workItems)
            {
                if (!workItem.Fields["System.AreaPath"].ToString().Contains(board))
                {
                    continue;
                }
                areaList.Add(workItem.Fields["System.AreaPath"].ToString());
            }

            //sort the list and add empty line to top
            areaList = areaList.Distinct().ToList();
            areaList.Sort();

            areaList.Insert(0, "");

            //populate combo box using list.
            cmbArea.DataSource = areaList.ToList();
            cmbStory.DisplayMember = "Value";
        }
        
        private void SaveGridToFile()
        {
            DateTime saveDate;
            
            //set date in file name to day loaded
            DateTime.TryParseExact(statusStrip1.Items[0].Text, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out saveDate);

            string fileName = dataDirectory + "\\Entry " + saveDate.ToString("yyyy\\-MM\\-dd") + ".hkn";

            StreamWriter writer = new StreamWriter(fileName);

            // Write the header row (optional)
            writer.WriteLine(string.Join("\t", dgEntries.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText)));

            // Loop through each row
            foreach (DataGridViewRow row in dgEntries.Rows)
            {
                // Skip header row (if you wrote it already)
                if (row.IsNewRow) continue;

                // Build the line string
                string line = string.Join("\t", row.Cells.Cast<DataGridViewCell>().Select(c => c.FormattedValue));

                // Write the line to the file
                writer.WriteLine(line);
            }
            writer.Close();
        }

        private void ProcessListForAdo()
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
                        DateTime.TryParseExact(row.Cells["colStartDate"].Value.ToString(), "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        newItem.StartDate = dt;

                        DateTime.TryParseExact(row.Cells["colTargetDate"].Value.ToString(), "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        newItem.TargetDate = dt;                        
                        
                        newItem.OriginalEstimate = CalculateHour(row.Cells["colOriginalEstimate"].Value.ToString());
                        newItem.CompletedWork = CalculateHour(row.Cells["colDuration"].Value.ToString());
                        newItem.ParentUserStoryId = row.Cells["colParentId"].Value.ToString();
                        newItem.Tags = row.Cells["colTags"].Value.ToString();
                        newItem.History = "Created by Time Tracker for ADO at " + DateTime.Now.ToString();
						newItem.UpdateOriginalEstimate = Convert.ToBoolean(row.Cells["colUpdateOrgEst"].Value.ToString());

                        if (newItem.UpdateOriginalEstimate == true)
                            newItem.OriginalEstimate = newItem.CompletedWork;

                        //create the ADO item
						int itemId = ado.CreateAdoItem(newItem);

                        //set item status again
                        bool closeItem = Convert.ToBoolean(row.Cells["colCloseItem"].Value.ToString());
                        newItem.State = closeItem ? "Closed" : "Active";
                        ado.SetItemState(itemId, newItem.State);

                        //update the item id
                        row.Cells["colItemId"].Value = itemId.ToString();
                        
                        break;
                    case "Update":
                        ADOTask updateItem = new ADOTask();

                        updateItem.Id = Convert.ToInt32(row.Cells["colItemId"].Value.ToString());
                        
                        DateTime.TryParseExact(row.Cells["colTargetDate"].Value.ToString(), "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);
                        updateItem.TargetDate = dt;

                        updateItem.IterationPath = row.Cells["colIteration"].Value.ToString();
                        updateItem.CompletedWork = CalculateHour(row.Cells["colDuration"].Value.ToString());
                        updateItem.History = row.Cells[dgEntries.Columns["colDescription"].Index].Value.ToString() + "<br>Updated by Time Tracker for ADO at " + DateTime.Now.ToString();
                        updateItem.UpdateOriginalEstimate = Convert.ToBoolean(row.Cells["colUpdateOrgEst"].Value.ToString());
                        
                        _ = ado.UpdateTaskAsync(updateItem);

                        closeItem = Convert.ToBoolean(row.Cells["colCloseItem"].Value.ToString());
                        if (closeItem == true)
                            ado.SetItemState(updateItem.Id, "Closed");

                        break;
                    
                    default:
                        break;
                }

                row.Cells["colSaved"].Value = true;
                row.SetValues();

                Thread.Sleep(2000);
            }
        }

        private void LoadGridFromFile(string fileName)
        {
            //check if the file exists
            if (!File.Exists(fileName)) return;

            dgEntries.Rows.Clear(); //clear existing data in grid

            StreamReader reader = new StreamReader(fileName);

            // Skip the header row
            string headerLine = reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                
                // Split the line based on the delimiter
                string[] values = line.Split('\t'); // Adjust delimiter if needed

                // Create a new DataRow
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgEntries);

                // Add values to each cell
                for (int i = 0; i < values.Length; i++)
                {
                    row.Cells[i].Value = values[i];
                }

                // Add the row to the DataGridView
                dgEntries.Rows.Add(row);
            }

            reader.Close();

            //update status strip
            CalculateTotalDuration();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadStoriesAsync(cmbArea.Text);

                _ = LoadTasksAsync(cmbArea.Text, rbTask.Checked ? "Task" : "Bug");
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
        }
        private void rbUpdateTask_CheckedChanged(object sender, EventArgs e)
        {
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
            txtTitle.Enabled = true;
            grpMain.Enabled = false;
            grpNewItem.Enabled = false;
            grpExistingItem.Enabled = false;

            chkCloseItem.Checked = false;
            chkCloseItem.Enabled = false;
            lblItemText.Text = "Description";
        }
        private async Task LoadTasksAsync(string areaPath, string itemType)
        {
            cmbTask.DataSource = null;
            cmbTask.Items.Clear();
            Dictionary<int, string> taskList = new Dictionary<int, string>();

            //get list of open tasks under a given area path
            var workItems = await ado.GetItemList(itemType, areaPath: areaPath, state: "Active", assignedToMe: true);

            //add tasks to a dictionary
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
                string[] dates = dateRange.Split('_');

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
                        
            return string.Join(";", tagList.ToArray()); 
        }

        private async void cmbStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStory.SelectedIndex == 0) return;

            //clear current selections
            cmbTag1.SelectedIndex = -1;
            cmbTag2.SelectedIndex = -1;
            cmbTag3.SelectedIndex = -1;

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
                for (int i = 0; i < cmbTag1.Items.Count; i++) 
                {
                    if (cmbTag1.Items[i].ToString() == tag.ToString().Trim()) 
                    { 
                        cmbTag1.SelectedIndex = i; 
                        break;
                    }
                }

                for (int i = 0; i < cmbTag2.Items.Count; i++)
                {
                    if (cmbTag2.Items[i].ToString() == tag.ToString().Trim())
                    {
                        cmbTag2.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbTag3.Items.Count; i++)
                {
                    if (cmbTag3.Items[i].ToString() == tag.ToString().Trim())
                    {
                        cmbTag3.SelectedIndex = i;
                        break;
                    }
                }
            }
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
            SaveGridToFile();
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
                ProcessListForAdo();
                SaveGridToFile();

                MessageBox.Show("Save completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
        }

        private void frmTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
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

                        if (String.IsNullOrEmpty(row.Cells["colOperationMode"].Value.ToString()))
                        {
                            otherDuration = otherDuration.Add(duration);
                        }
                        else
                        {
                            adoDuration = adoDuration.Add(duration);
                        }
                    }
                }
            }

            statusStrip1.Items[1].Text = "ADO: " + adoDuration.ToString();
            statusStrip1.Items[2].Text = "Others: " + otherDuration.ToString();
            statusStrip1.Items[3].Text = "Total: " + totalDuration.ToString();
        }

        private void rbTask_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTask.Checked)
            {
                lblItemtype.Text = rbTask.Text;

                if (cmbArea.SelectedIndex > 0)
                {
                    _ = LoadTasksAsync(cmbArea.Text, "Task");
                }
            }
        }

        private void rbBug_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBug.Checked)
            {
                lblItemtype.Text = rbBug.Text;

                if (cmbArea.SelectedIndex > 0)
                {
                    _ = LoadTasksAsync(cmbArea.Text, "Bug");
                }
            }
        }

        private void btnRefreshTaskBug_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadTasksAsync(cmbArea.Text, rbTask.Checked ? "Task" : "Bug");
            }
        }

        private void btnRefreshStory_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex > 0)
            {
                _ = LoadStoriesAsync(cmbArea.Text);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            //add time entry to the list
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgEntries);

            row.Cells[dgEntries.Columns["colCategory"].Index].Value = cmbCategory.Text;
            row.Cells[dgEntries.Columns["colStartTime"].Index].Value = lblStartTime.Text;
            row.Cells[dgEntries.Columns["colEndTime"].Index].Value = DateTime.Now.ToString("HH\\:mm");
            row.Cells[dgEntries.Columns["colDuration"].Index].Value = Convert.ToDateTime(lblDuration.Text).ToString("HH\\:mm");
            row.Cells[dgEntries.Columns["colCreateDate"].Index].Value = DateTime.Now.ToString("dd\\-MM\\-yyyy");

            if (rbCreateNew.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = string.Empty;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = txtTitle.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text;
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = rbTask.Checked ? "Task" : "Bug";
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colStory"].Index].Value = cmbStory.Text;
                row.Cells[dgEntries.Columns["colParentId"].Index].Value = cmbStory.SelectedValue != null ? cmbStory.SelectedValue.ToString() : String.Empty;
                row.Cells[dgEntries.Columns["colTags"].Index].Value = CreateTagList();
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Create";
            }
            else if (rbUpdateTask.Checked)
            {
                row.Cells[dgEntries.Columns["colItemId"].Index].Value = cmbTask.SelectedValue;
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = cmbTask.Text.Split('-')[1].Trim();
                row.Cells[dgEntries.Columns["colProject"].Index].Value = cmbProject.Text;
                row.Cells[dgEntries.Columns["colBoard"].Index].Value = cmbBoard.Text;
                row.Cells[dgEntries.Columns["colAreaPath"].Index].Value = cmbArea.Text;
                row.Cells[dgEntries.Columns["colItemType"].Index].Value = rbTask.Checked ? "Task" : "Bug";
                row.Cells[dgEntries.Columns["colCloseItem"].Index].Value = chkCloseItem.Checked;
                row.Cells[dgEntries.Columns["colIteration"].Index].Value = cmbIteration.Text;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = "Update";
            }
            if (rbTimeEntry.Checked)
            {
                row.Cells[dgEntries.Columns["colTitle"].Index].Value = txtTitle.Text;
                row.Cells[dgEntries.Columns["colDescription"].Index].Value = txtDescription.Text;
                row.Cells[dgEntries.Columns["colOperationMode"].Index].Value = string.Empty;
            }

            dgEntries.Rows.Add(row);

            lblDuration.Text = "00:00:00"; // Reset the label text
            CalculateTotalDuration();

            btnStart.Enabled = true;
            btnStart.Text = "Start";
            btnPause.Enabled = false;
            btnStop.Enabled = false;
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            SaveGridToFile();
            this.Close();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            frmAbout f2 = new frmAbout(); //this is the change, code for redirect  
            f2.ShowDialog();
        }

        private void mnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = dataDirectory;
            openFileDialog1.ShowDialog();
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
            }
            else if (e.ColumnIndex == dgEntries.Columns["colItemId"].Index)
            {

                if (row.Cells["colItemId"].Value != null)
                {
                    string link = String.Format("{0}/{1}/_workitems/edit//{2}", ado.OrganizationUrl, cmbProject.Text, row.Cells[dgEntries.Columns["colItemId"].Index].Value.ToString());
                    System.Diagnostics.Process.Start(link);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isTimerRunning)
            {
                MessageBox.Show("Timer is running. Stop timer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //save current list beofre loading data
            SaveGridToFile();
            
            string fileName = openFileDialog1.FileName;
            //load data to grid from file
            LoadGridFromFile(fileName);

            //set date in status strip
            string safeFileName = openFileDialog1.SafeFileName;
            string dateInFile = Convert.ToDateTime(safeFileName.Replace("Entry ", "").Replace(".hkn", "")).ToString("dd\\-MM\\-yyyy");

            //dgEntries.Rows[dgEntries.Rows.Count - 1].Cells[dgEntries.Columns["colCreateDate"].Index].Value.ToString();
            statusStrip1.Items[0].Text = dateInFile;

            //do not let to start time if date is not today.
            bool isTodaysData = string.Equals(dateInFile, DateTime.Now.ToString("dd\\-MM\\-yyyy"));

            btnStart.Enabled = isTodaysData;           
        }

        private void mnTodoList_Click(object sender, EventArgs e)
        {
            frmTodo f2 = new frmTodo(); //this is the change, code for redirect  
            f2.dataDirectory = dataDirectory;
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
                dialogForm.dataDirectory = dataDirectory;
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
            f.dataDirectory = dataDirectory;
            f.ShowDialog();
        }

        private List<String> LoadMyFavoriteBoards()
        {
            List<string> myBoards = new List<string>();
            

            string fileName = dataDirectory + "\\boards.txt";
            if (File.Exists(fileName))
            { 
                StreamReader reader = new StreamReader(fileName);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    myBoards.Add((string)line);
                }

                reader.Close();
            }
            
            if (myBoards.Count > 0)
            {
				myBoards.Sort();
				myBoards.Insert(0, "");
            }
			
            return myBoards;
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
			
            string todaysDate = DateTime.Now.ToString("dd\\-MM\\-yyyy");
            if ((todaysDate != statusStrip1.Items[0].Text) || (todaysDate == statusStrip1.Items[0].Text && MessageBox.Show("Your time entries will be deleted, are you sure?", "", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                statusStrip1.Items[0].Text = todaysDate;
                dgEntries.RowCount = 0;
			}
		}
	}
}
