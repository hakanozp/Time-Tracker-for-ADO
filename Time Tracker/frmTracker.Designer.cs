﻿namespace TimeTracker
{
    partial class frmTracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTracker));
            this.dgEntries = new System.Windows.Forms.DataGridView();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalEstimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCloseItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUpdateOrgEst = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWbsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.slTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.slUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.slVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnTimeTracker = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSaveList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSaveAndSendtoADO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStartNewDay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowActiveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnTodoList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFavoriteBoards = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpNewItem = new System.Windows.Forms.GroupBox();
            this.btnAddNewStory = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.cmbTag4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOriginalEstimate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenStoryLink = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRefreshStory = new System.Windows.Forms.Button();
            this.cmbIteration = new System.Windows.Forms.ComboBox();
            this.dtTargetDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTag3 = new System.Windows.Forms.ComboBox();
            this.cmbTag2 = new System.Windows.Forms.ComboBox();
            this.cmbTag1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbWbsCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.grpText = new System.Windows.Forms.GroupBox();
            this.dtCreateDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.chkUpdateOriginal = new System.Windows.Forms.CheckBox();
            this.btnGetFromTodoList = new System.Windows.Forms.Button();
            this.lblItemText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkCloseItem = new System.Windows.Forms.CheckBox();
            this.grpExistingItem = new System.Windows.Forms.GroupBox();
            this.btnOpenSupportApp = new System.Windows.Forms.Button();
            this.btnOpenItemLink = new System.Windows.Forms.Button();
            this.btnRefreshTaskBug = new System.Windows.Forms.Button();
            this.lblItemtype = new System.Windows.Forms.Label();
            this.cmbTask = new System.Windows.Forms.ComboBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.btnListActiveItems = new System.Windows.Forms.Button();
            this.btnRefreshBoard = new System.Windows.Forms.Button();
            this.btnOpenBoardLink = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoard = new System.Windows.Forms.ComboBox();
            this.rbUpdateTask = new System.Windows.Forms.RadioButton();
            this.rbCreateNew = new System.Windows.Forms.RadioButton();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntries)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpNewItem.SuspendLayout();
            this.grpText.SuspendLayout();
            this.grpExistingItem.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEntries
            // 
            this.dgEntries.AllowUserToAddRows = false;
            this.dgEntries.AllowUserToDeleteRows = false;
            this.dgEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colItemId,
            this.colItemType,
            this.colTitle,
            this.colBoard,
            this.colStory,
            this.colStartTime,
            this.colEndTime,
            this.colDuration,
            this.colTags,
            this.colDescription,
            this.colProject,
            this.colAreaPath,
            this.colIteration,
            this.colStartDate,
            this.colTargetDate,
            this.colOriginalEstimate,
            this.colCloseItem,
            this.colParentId,
            this.colCreateDate,
            this.colOperationMode,
            this.colSaved,
            this.colUpdateOrgEst,
            this.colWbsCode,
            this.colState});
            this.dgEntries.Location = new System.Drawing.Point(0, 424);
            this.dgEntries.Name = "dgEntries";
            this.dgEntries.ReadOnly = true;
            this.dgEntries.Size = new System.Drawing.Size(1104, 235);
            this.dgEntries.TabIndex = 13;
            this.dgEntries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntries_CellContentClick);
            this.dgEntries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntries_CellDoubleClick);
            this.dgEntries.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntries_CellValueChanged);
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 74;
            // 
            // colItemId
            // 
            this.colItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItemId.HeaderText = "Item Id";
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            this.colItemId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colItemId.Width = 70;
            // 
            // colItemType
            // 
            this.colItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemType.HeaderText = "Item Type";
            this.colItemType.Name = "colItemType";
            this.colItemType.ReadOnly = true;
            this.colItemType.Width = 73;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 52;
            // 
            // colBoard
            // 
            this.colBoard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBoard.HeaderText = "Board";
            this.colBoard.Name = "colBoard";
            this.colBoard.ReadOnly = true;
            this.colBoard.Width = 60;
            // 
            // colStory
            // 
            this.colStory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStory.HeaderText = "Parent Story";
            this.colStory.Name = "colStory";
            this.colStory.ReadOnly = true;
            this.colStory.Width = 83;
            // 
            // colStartTime
            // 
            this.colStartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStartTime.HeaderText = "Start Time";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            this.colStartTime.Width = 80;
            // 
            // colEndTime
            // 
            this.colEndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEndTime.HeaderText = "End Time";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Width = 80;
            // 
            // colDuration
            // 
            this.colDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDuration.HeaderText = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            this.colDuration.Width = 72;
            // 
            // colTags
            // 
            this.colTags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTags.HeaderText = "Tags";
            this.colTags.Name = "colTags";
            this.colTags.ReadOnly = true;
            this.colTags.Width = 56;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDescription.HeaderText = "Description/Discussion";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 141;
            // 
            // colProject
            // 
            this.colProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProject.HeaderText = "Project";
            this.colProject.Name = "colProject";
            this.colProject.ReadOnly = true;
            this.colProject.Width = 65;
            // 
            // colAreaPath
            // 
            this.colAreaPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAreaPath.HeaderText = "Area Path";
            this.colAreaPath.Name = "colAreaPath";
            this.colAreaPath.ReadOnly = true;
            this.colAreaPath.Width = 73;
            // 
            // colIteration
            // 
            this.colIteration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIteration.HeaderText = "Iteration";
            this.colIteration.Name = "colIteration";
            this.colIteration.ReadOnly = true;
            this.colIteration.Width = 70;
            // 
            // colStartDate
            // 
            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colTargetDate
            // 
            this.colTargetDate.HeaderText = "Target Date";
            this.colTargetDate.Name = "colTargetDate";
            this.colTargetDate.ReadOnly = true;
            // 
            // colOriginalEstimate
            // 
            this.colOriginalEstimate.HeaderText = "Original Estimate";
            this.colOriginalEstimate.Name = "colOriginalEstimate";
            this.colOriginalEstimate.ReadOnly = true;
            this.colOriginalEstimate.Width = 120;
            // 
            // colCloseItem
            // 
            this.colCloseItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCloseItem.HeaderText = "Close Item";
            this.colCloseItem.Name = "colCloseItem";
            this.colCloseItem.ReadOnly = true;
            this.colCloseItem.Width = 56;
            // 
            // colParentId
            // 
            this.colParentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colParentId.HeaderText = "Parent Id";
            this.colParentId.Name = "colParentId";
            this.colParentId.ReadOnly = true;
            this.colParentId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colParentId.Width = 75;
            // 
            // colCreateDate
            // 
            this.colCreateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCreateDate.HeaderText = "Create Date";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            this.colCreateDate.Width = 82;
            // 
            // colOperationMode
            // 
            this.colOperationMode.HeaderText = "Operation";
            this.colOperationMode.Name = "colOperationMode";
            this.colOperationMode.ReadOnly = true;
            this.colOperationMode.Width = 80;
            // 
            // colSaved
            // 
            this.colSaved.HeaderText = "Saved";
            this.colSaved.Name = "colSaved";
            this.colSaved.ReadOnly = true;
            this.colSaved.Width = 70;
            // 
            // colUpdateOrgEst
            // 
            this.colUpdateOrgEst.HeaderText = "Update Org.Est.";
            this.colUpdateOrgEst.Name = "colUpdateOrgEst";
            this.colUpdateOrgEst.ReadOnly = true;
            // 
            // colWbsCode
            // 
            this.colWbsCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colWbsCode.HeaderText = "WBS Code";
            this.colWbsCode.Name = "colWbsCode";
            this.colWbsCode.ReadOnly = true;
            this.colWbsCode.Width = 79;
            // 
            // colState
            // 
            this.colState.HeaderText = "State";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStartTime.Location = new System.Drawing.Point(603, 660);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(66, 26);
            this.lblStartTime.TabIndex = 20;
            this.lblStartTime.Text = "00:00";
            this.lblStartTime.Visible = false;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(2, 665);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(110, 21);
            this.btnDeleteRow.TabIndex = 0;
            this.btnDeleteRow.Text = "Delete selected row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRows_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slDate,
            this.slTotal,
            this.slUser,
            this.slVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 688);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1104, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slDate
            // 
            this.slDate.AutoSize = false;
            this.slDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.slDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.slDate.Name = "slDate";
            this.slDate.Size = new System.Drawing.Size(90, 17);
            this.slDate.Text = "Date";
            this.slDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slTotal
            // 
            this.slTotal.AutoSize = false;
            this.slTotal.Name = "slTotal";
            this.slTotal.Size = new System.Drawing.Size(100, 17);
            this.slTotal.Text = "Total: ";
            this.slTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slUser
            // 
            this.slUser.AutoSize = false;
            this.slUser.Name = "slUser";
            this.slUser.Size = new System.Drawing.Size(250, 17);
            this.slUser.Text = "User:";
            this.slUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slVersion
            // 
            this.slVersion.AutoSize = false;
            this.slVersion.Name = "slVersion";
            this.slVersion.Size = new System.Drawing.Size(100, 17);
            this.slVersion.Text = "Version:";
            this.slVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTimeTracker,
            this.mnTools,
            this.mnAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 27);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnTimeTracker
            // 
            this.mnTimeTracker.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSaveList,
            this.mnSaveAndSendtoADO,
            this.toolStripMenuItem1,
            this.mnSettings,
            this.toolStripMenuItem2,
            this.mnExit});
            this.mnTimeTracker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnTimeTracker.Name = "mnTimeTracker";
            this.mnTimeTracker.Size = new System.Drawing.Size(41, 23);
            this.mnTimeTracker.Text = "File";
            // 
            // mnSaveList
            // 
            this.mnSaveList.Image = ((System.Drawing.Image)(resources.GetObject("mnSaveList.Image")));
            this.mnSaveList.Name = "mnSaveList";
            this.mnSaveList.Size = new System.Drawing.Size(243, 24);
            this.mnSaveList.Text = "Save List";
            this.mnSaveList.Click += new System.EventHandler(this.mnSaveList_Click);
            // 
            // mnSaveAndSendtoADO
            // 
            this.mnSaveAndSendtoADO.Name = "mnSaveAndSendtoADO";
            this.mnSaveAndSendtoADO.Size = new System.Drawing.Size(243, 24);
            this.mnSaveAndSendtoADO.Text = "Save List and Send to ADO";
            this.mnSaveAndSendtoADO.Click += new System.EventHandler(this.mnSaveAndSendtoADO_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 6);
            // 
            // mnSettings
            // 
            this.mnSettings.Name = "mnSettings";
            this.mnSettings.Size = new System.Drawing.Size(243, 24);
            this.mnSettings.Text = "Settings...";
            this.mnSettings.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(243, 24);
            this.mnExit.Text = "Exit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnTools
            // 
            this.mnTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnLoadData,
            this.mnStartNewDay,
            this.toolStripSeparator1,
            this.mnuShowActiveItems,
            this.toolStripSeparator2,
            this.mnTodoList,
            this.mnFavoriteBoards});
            this.mnTools.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mnTools.Name = "mnTools";
            this.mnTools.Size = new System.Drawing.Size(52, 23);
            this.mnTools.Text = "Tools";
            // 
            // mnLoadData
            // 
            this.mnLoadData.Name = "mnLoadData";
            this.mnLoadData.Size = new System.Drawing.Size(203, 24);
            this.mnLoadData.Text = "Load data";
            this.mnLoadData.Click += new System.EventHandler(this.mnLoadData_Click);
            // 
            // mnStartNewDay
            // 
            this.mnStartNewDay.Name = "mnStartNewDay";
            this.mnStartNewDay.Size = new System.Drawing.Size(203, 24);
            this.mnStartNewDay.Text = "Start New Day";
            this.mnStartNewDay.Click += new System.EventHandler(this.mnStartNewDay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // mnuShowActiveItems
            // 
            this.mnuShowActiveItems.Name = "mnuShowActiveItems";
            this.mnuShowActiveItems.Size = new System.Drawing.Size(203, 24);
            this.mnuShowActiveItems.Text = "Show Active Items";
            this.mnuShowActiveItems.Click += new System.EventHandler(this.mnuShowActiveItems_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // mnTodoList
            // 
            this.mnTodoList.Name = "mnTodoList";
            this.mnTodoList.Size = new System.Drawing.Size(203, 24);
            this.mnTodoList.Text = "My to-do List...";
            this.mnTodoList.Click += new System.EventHandler(this.mnTodoList_Click);
            // 
            // mnFavoriteBoards
            // 
            this.mnFavoriteBoards.Name = "mnFavoriteBoards";
            this.mnFavoriteBoards.Size = new System.Drawing.Size(203, 24);
            this.mnFavoriteBoards.Text = "My favorite boards...";
            this.mnFavoriteBoards.Click += new System.EventHandler(this.mnFavoriteBoards_Click);
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(52, 23);
            this.mnAbout.Text = "About";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // grpNewItem
            // 
            this.grpNewItem.Controls.Add(this.btnAddNewStory);
            this.grpNewItem.Controls.Add(this.label14);
            this.grpNewItem.Controls.Add(this.cmbState);
            this.grpNewItem.Controls.Add(this.cmbItemType);
            this.grpNewItem.Controls.Add(this.cmbTag4);
            this.grpNewItem.Controls.Add(this.label5);
            this.grpNewItem.Controls.Add(this.txtOriginalEstimate);
            this.grpNewItem.Controls.Add(this.label6);
            this.grpNewItem.Controls.Add(this.btnOpenStoryLink);
            this.grpNewItem.Controls.Add(this.label9);
            this.grpNewItem.Controls.Add(this.btnRefreshStory);
            this.grpNewItem.Controls.Add(this.cmbIteration);
            this.grpNewItem.Controls.Add(this.dtTargetDate);
            this.grpNewItem.Controls.Add(this.label13);
            this.grpNewItem.Controls.Add(this.dtStartDate);
            this.grpNewItem.Controls.Add(this.label12);
            this.grpNewItem.Controls.Add(this.label11);
            this.grpNewItem.Controls.Add(this.cmbTag3);
            this.grpNewItem.Controls.Add(this.cmbTag2);
            this.grpNewItem.Controls.Add(this.cmbTag1);
            this.grpNewItem.Controls.Add(this.label2);
            this.grpNewItem.Controls.Add(this.cmbStory);
            this.grpNewItem.Location = new System.Drawing.Point(12, 164);
            this.grpNewItem.Name = "grpNewItem";
            this.grpNewItem.Size = new System.Drawing.Size(508, 198);
            this.grpNewItem.TabIndex = 37;
            this.grpNewItem.TabStop = false;
            // 
            // btnAddNewStory
            // 
            this.btnAddNewStory.BackgroundImage = global::TimeTracker.Properties.Resources.new_file;
            this.btnAddNewStory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNewStory.Location = new System.Drawing.Point(478, 74);
            this.btnAddNewStory.Name = "btnAddNewStory";
            this.btnAddNewStory.Size = new System.Drawing.Size(23, 23);
            this.btnAddNewStory.TabIndex = 79;
            this.btnAddNewStory.UseVisualStyleBackColor = true;
            this.btnAddNewStory.Click += new System.EventHandler(this.btnAddNewStory_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(217, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 78;
            this.label14.Text = "State";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "Active",
            "New"});
            this.cmbState.Location = new System.Drawing.Point(263, 15);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(82, 21);
            this.cmbState.TabIndex = 77;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // cmbItemType
            // 
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Items.AddRange(new object[] {
            "Task",
            "Bug"});
            this.cmbItemType.Location = new System.Drawing.Point(98, 15);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(82, 21);
            this.cmbItemType.TabIndex = 76;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            // 
            // cmbTag4
            // 
            this.cmbTag4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag4.FormattingEnabled = true;
            this.cmbTag4.Location = new System.Drawing.Point(350, 104);
            this.cmbTag4.Name = "cmbTag4";
            this.cmbTag4.Size = new System.Drawing.Size(80, 21);
            this.cmbTag4.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(213, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Original Estimate";
            // 
            // txtOriginalEstimate
            // 
            this.txtOriginalEstimate.BeepOnError = true;
            this.txtOriginalEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalEstimate.Location = new System.Drawing.Point(322, 134);
            this.txtOriginalEstimate.Mask = "00:00";
            this.txtOriginalEstimate.Name = "txtOriginalEstimate";
            this.txtOriginalEstimate.Size = new System.Drawing.Size(52, 20);
            this.txtOriginalEstimate.TabIndex = 74;
            this.txtOriginalEstimate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOriginalEstimate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtOriginalEstimate.ValidatingType = typeof(System.DateTime);
            this.txtOriginalEstimate.Leave += new System.EventHandler(this.txtOriginalEstimate_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Item Type";
            // 
            // btnOpenStoryLink
            // 
            this.btnOpenStoryLink.BackgroundImage = global::TimeTracker.Properties.Resources.Azure_DevOps;
            this.btnOpenStoryLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenStoryLink.Location = new System.Drawing.Point(454, 74);
            this.btnOpenStoryLink.Name = "btnOpenStoryLink";
            this.btnOpenStoryLink.Size = new System.Drawing.Size(23, 23);
            this.btnOpenStoryLink.TabIndex = 73;
            this.btnOpenStoryLink.UseVisualStyleBackColor = true;
            this.btnOpenStoryLink.Click += new System.EventHandler(this.btnOpenStoryLink_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Iteration";
            // 
            // btnRefreshStory
            // 
            this.btnRefreshStory.BackgroundImage = global::TimeTracker.Properties.Resources.refresh;
            this.btnRefreshStory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshStory.Location = new System.Drawing.Point(430, 74);
            this.btnRefreshStory.Name = "btnRefreshStory";
            this.btnRefreshStory.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshStory.TabIndex = 71;
            this.btnRefreshStory.UseVisualStyleBackColor = true;
            this.btnRefreshStory.Click += new System.EventHandler(this.btnRefreshStory_Click);
            // 
            // cmbIteration
            // 
            this.cmbIteration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIteration.FormattingEnabled = true;
            this.cmbIteration.Location = new System.Drawing.Point(98, 45);
            this.cmbIteration.Name = "cmbIteration";
            this.cmbIteration.Size = new System.Drawing.Size(248, 21);
            this.cmbIteration.TabIndex = 65;
            // 
            // dtTargetDate
            // 
            this.dtTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTargetDate.Location = new System.Drawing.Point(98, 163);
            this.dtTargetDate.Name = "dtTargetDate";
            this.dtTargetDate.Size = new System.Drawing.Size(93, 20);
            this.dtTargetDate.TabIndex = 70;
            this.dtTargetDate.ValueChanged += new System.EventHandler(this.dtTargetDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Target Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Enabled = false;
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(98, 134);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(93, 20);
            this.dtStartDate.TabIndex = 68;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Start Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Tags";
            // 
            // cmbTag3
            // 
            this.cmbTag3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag3.FormattingEnabled = true;
            this.cmbTag3.Location = new System.Drawing.Point(266, 104);
            this.cmbTag3.Name = "cmbTag3";
            this.cmbTag3.Size = new System.Drawing.Size(80, 21);
            this.cmbTag3.TabIndex = 65;
            // 
            // cmbTag2
            // 
            this.cmbTag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag2.FormattingEnabled = true;
            this.cmbTag2.Location = new System.Drawing.Point(182, 104);
            this.cmbTag2.Name = "cmbTag2";
            this.cmbTag2.Size = new System.Drawing.Size(80, 21);
            this.cmbTag2.TabIndex = 64;
            // 
            // cmbTag1
            // 
            this.cmbTag1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag1.FormattingEnabled = true;
            this.cmbTag1.Location = new System.Drawing.Point(98, 104);
            this.cmbTag1.Name = "cmbTag1";
            this.cmbTag1.Size = new System.Drawing.Size(80, 21);
            this.cmbTag1.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Parent Story";
            // 
            // cmbStory
            // 
            this.cmbStory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStory.FormattingEnabled = true;
            this.cmbStory.Location = new System.Drawing.Point(98, 75);
            this.cmbStory.Name = "cmbStory";
            this.cmbStory.Size = new System.Drawing.Size(330, 21);
            this.cmbStory.TabIndex = 38;
            this.cmbStory.SelectedIndexChanged += new System.EventHandler(this.cmbStory_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "WBS";
            // 
            // cmbWbsCode
            // 
            this.cmbWbsCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWbsCode.FormattingEnabled = true;
            this.cmbWbsCode.Items.AddRange(new object[] {
            "",
            "Run-Incidents / Break Fix",
            "Run-Legal & Compliance",
            "Run-Service Requests",
            "Run-Minor Enhancements (<2 weeks)",
            "Run-Tech Debt / Technology Lifecycle",
            "Run-Access & Authorization",
            "Run-Patching / Monitoring",
            "Run-Application Maintenance",
            "Run-Other",
            "",
            "Project-Discovery",
            "Project-Proof of Concepts",
            "Project-Working Demands",
            "Project-Major Enhancements (>2 weeks)",
            "Project-Strategic Initiatives",
            "Project-Project Management",
            "Project-Other"});
            this.cmbWbsCode.Location = new System.Drawing.Point(100, 95);
            this.cmbWbsCode.Name = "cmbWbsCode";
            this.cmbWbsCode.Size = new System.Drawing.Size(216, 21);
            this.cmbWbsCode.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Development",
            "User Support",
            "Meeting",
            "Daily Work",
            "Learning",
            "Others"});
            this.cmbCategory.Location = new System.Drawing.Point(100, 124);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 73;
            // 
            // grpText
            // 
            this.grpText.Controls.Add(this.dtCreateDate);
            this.grpText.Controls.Add(this.label15);
            this.grpText.Controls.Add(this.label10);
            this.grpText.Controls.Add(this.chkUpdateOriginal);
            this.grpText.Controls.Add(this.btnGetFromTodoList);
            this.grpText.Controls.Add(this.cmbWbsCode);
            this.grpText.Controls.Add(this.lblItemText);
            this.grpText.Controls.Add(this.label4);
            this.grpText.Controls.Add(this.label3);
            this.grpText.Controls.Add(this.txtDescription);
            this.grpText.Controls.Add(this.txtTitle);
            this.grpText.Controls.Add(this.cmbCategory);
            this.grpText.Controls.Add(this.chkCloseItem);
            this.grpText.Location = new System.Drawing.Point(526, 62);
            this.grpText.Name = "grpText";
            this.grpText.Size = new System.Drawing.Size(566, 234);
            this.grpText.TabIndex = 38;
            this.grpText.TabStop = false;
            // 
            // dtCreateDate
            // 
            this.dtCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDate.Location = new System.Drawing.Point(100, 153);
            this.dtCreateDate.Name = "dtCreateDate";
            this.dtCreateDate.Size = new System.Drawing.Size(93, 20);
            this.dtCreateDate.TabIndex = 81;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "Create Date";
            // 
            // chkUpdateOriginal
            // 
            this.chkUpdateOriginal.AutoSize = true;
            this.chkUpdateOriginal.Enabled = false;
            this.chkUpdateOriginal.Location = new System.Drawing.Point(129, 209);
            this.chkUpdateOriginal.Name = "chkUpdateOriginal";
            this.chkUpdateOriginal.Size = new System.Drawing.Size(202, 17);
            this.chkUpdateOriginal.TabIndex = 77;
            this.chkUpdateOriginal.Text = "Update original estimate when closed";
            this.chkUpdateOriginal.UseVisualStyleBackColor = true;
            // 
            // btnGetFromTodoList
            // 
            this.btnGetFromTodoList.BackgroundImage = global::TimeTracker.Properties.Resources.to_do_list;
            this.btnGetFromTodoList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetFromTodoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFromTodoList.Location = new System.Drawing.Point(528, 14);
            this.btnGetFromTodoList.Name = "btnGetFromTodoList";
            this.btnGetFromTodoList.Size = new System.Drawing.Size(22, 22);
            this.btnGetFromTodoList.TabIndex = 73;
            this.btnGetFromTodoList.UseVisualStyleBackColor = true;
            this.btnGetFromTodoList.Click += new System.EventHandler(this.btnGetFromTodoList_Click);
            // 
            // lblItemText
            // 
            this.lblItemText.AutoSize = true;
            this.lblItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemText.Location = new System.Drawing.Point(19, 51);
            this.lblItemText.Name = "lblItemText";
            this.lblItemText.Size = new System.Drawing.Size(71, 13);
            this.lblItemText.TabIndex = 25;
            this.lblItemText.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Title";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(451, 45);
            this.txtDescription.TabIndex = 23;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 14);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(428, 20);
            this.txtTitle.TabIndex = 22;
            // 
            // chkCloseItem
            // 
            this.chkCloseItem.AutoSize = true;
            this.chkCloseItem.Location = new System.Drawing.Point(100, 186);
            this.chkCloseItem.Name = "chkCloseItem";
            this.chkCloseItem.Size = new System.Drawing.Size(150, 17);
            this.chkCloseItem.TabIndex = 62;
            this.chkCloseItem.Text = "Close item when list saved";
            this.chkCloseItem.UseVisualStyleBackColor = true;
            this.chkCloseItem.CheckedChanged += new System.EventHandler(this.chkCloseItem_CheckedChanged);
            // 
            // grpExistingItem
            // 
            this.grpExistingItem.Controls.Add(this.btnOpenSupportApp);
            this.grpExistingItem.Controls.Add(this.btnOpenItemLink);
            this.grpExistingItem.Controls.Add(this.btnRefreshTaskBug);
            this.grpExistingItem.Controls.Add(this.lblItemtype);
            this.grpExistingItem.Controls.Add(this.cmbTask);
            this.grpExistingItem.Enabled = false;
            this.grpExistingItem.Location = new System.Drawing.Point(12, 362);
            this.grpExistingItem.Name = "grpExistingItem";
            this.grpExistingItem.Size = new System.Drawing.Size(508, 50);
            this.grpExistingItem.TabIndex = 43;
            this.grpExistingItem.TabStop = false;
            // 
            // btnOpenSupportApp
            // 
            this.btnOpenSupportApp.BackgroundImage = global::TimeTracker.Properties.Resources.icons8_power_apps_80;
            this.btnOpenSupportApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenSupportApp.Location = new System.Drawing.Point(478, 16);
            this.btnOpenSupportApp.Name = "btnOpenSupportApp";
            this.btnOpenSupportApp.Size = new System.Drawing.Size(23, 23);
            this.btnOpenSupportApp.TabIndex = 80;
            this.btnOpenSupportApp.UseVisualStyleBackColor = true;
            this.btnOpenSupportApp.Click += new System.EventHandler(this.btnOpenSupportApp_Click);
            // 
            // btnOpenItemLink
            // 
            this.btnOpenItemLink.BackgroundImage = global::TimeTracker.Properties.Resources.Azure_DevOps;
            this.btnOpenItemLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenItemLink.Location = new System.Drawing.Point(454, 16);
            this.btnOpenItemLink.Name = "btnOpenItemLink";
            this.btnOpenItemLink.Size = new System.Drawing.Size(23, 23);
            this.btnOpenItemLink.TabIndex = 73;
            this.btnOpenItemLink.UseVisualStyleBackColor = true;
            this.btnOpenItemLink.Click += new System.EventHandler(this.btnOpenItemLink_Click);
            // 
            // btnRefreshTaskBug
            // 
            this.btnRefreshTaskBug.BackgroundImage = global::TimeTracker.Properties.Resources.refresh;
            this.btnRefreshTaskBug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshTaskBug.Location = new System.Drawing.Point(430, 16);
            this.btnRefreshTaskBug.Name = "btnRefreshTaskBug";
            this.btnRefreshTaskBug.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshTaskBug.TabIndex = 72;
            this.btnRefreshTaskBug.UseVisualStyleBackColor = true;
            this.btnRefreshTaskBug.Click += new System.EventHandler(this.btnRefreshTaskBug_Click);
            // 
            // lblItemtype
            // 
            this.lblItemtype.AutoSize = true;
            this.lblItemtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemtype.Location = new System.Drawing.Point(16, 20);
            this.lblItemtype.Name = "lblItemtype";
            this.lblItemtype.Size = new System.Drawing.Size(35, 13);
            this.lblItemtype.TabIndex = 42;
            this.lblItemtype.Text = "Task";
            // 
            // cmbTask
            // 
            this.cmbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(97, 17);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(330, 21);
            this.cmbTask.TabIndex = 41;
            this.cmbTask.SelectedIndexChanged += new System.EventHandler(this.cmbTask_SelectedIndexChanged);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.btnListActiveItems);
            this.grpMain.Controls.Add(this.btnRefreshBoard);
            this.grpMain.Controls.Add(this.btnOpenBoardLink);
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.cmbArea);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.cmbProject);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.cmbBoard);
            this.grpMain.Location = new System.Drawing.Point(12, 60);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(508, 105);
            this.grpMain.TabIndex = 50;
            this.grpMain.TabStop = false;
            // 
            // btnListActiveItems
            // 
            this.btnListActiveItems.BackgroundImage = global::TimeTracker.Properties.Resources.to_do_list;
            this.btnListActiveItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListActiveItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListActiveItems.Location = new System.Drawing.Point(478, 44);
            this.btnListActiveItems.Name = "btnListActiveItems";
            this.btnListActiveItems.Size = new System.Drawing.Size(23, 23);
            this.btnListActiveItems.TabIndex = 75;
            this.btnListActiveItems.UseVisualStyleBackColor = true;
            this.btnListActiveItems.Visible = false;
            this.btnListActiveItems.Click += new System.EventHandler(this.btnListActiveItems_Click);
            // 
            // btnRefreshBoard
            // 
            this.btnRefreshBoard.BackgroundImage = global::TimeTracker.Properties.Resources.refresh;
            this.btnRefreshBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshBoard.Location = new System.Drawing.Point(430, 44);
            this.btnRefreshBoard.Name = "btnRefreshBoard";
            this.btnRefreshBoard.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshBoard.TabIndex = 73;
            this.btnRefreshBoard.UseVisualStyleBackColor = true;
            this.btnRefreshBoard.Click += new System.EventHandler(this.btnRefreshBoard_Click);
            // 
            // btnOpenBoardLink
            // 
            this.btnOpenBoardLink.BackgroundImage = global::TimeTracker.Properties.Resources.Azure_DevOps;
            this.btnOpenBoardLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenBoardLink.Location = new System.Drawing.Point(454, 44);
            this.btnOpenBoardLink.Name = "btnOpenBoardLink";
            this.btnOpenBoardLink.Size = new System.Drawing.Size(23, 23);
            this.btnOpenBoardLink.TabIndex = 72;
            this.btnOpenBoardLink.UseVisualStyleBackColor = true;
            this.btnOpenBoardLink.Click += new System.EventHandler(this.btnOpenBoardLink_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Area Path";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(98, 74);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(347, 21);
            this.cmbArea.TabIndex = 53;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(98, 15);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(131, 21);
            this.cmbProject.TabIndex = 51;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Board";
            // 
            // cmbBoard
            // 
            this.cmbBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoard.FormattingEnabled = true;
            this.cmbBoard.Location = new System.Drawing.Point(98, 45);
            this.cmbBoard.Name = "cmbBoard";
            this.cmbBoard.Size = new System.Drawing.Size(330, 21);
            this.cmbBoard.TabIndex = 49;
            this.cmbBoard.SelectedIndexChanged += new System.EventHandler(this.cmbBoard_SelectedIndexChanged);
            // 
            // rbUpdateTask
            // 
            this.rbUpdateTask.AutoSize = true;
            this.rbUpdateTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUpdateTask.ForeColor = System.Drawing.Color.Navy;
            this.rbUpdateTask.Location = new System.Drawing.Point(173, 37);
            this.rbUpdateTask.Name = "rbUpdateTask";
            this.rbUpdateTask.Size = new System.Drawing.Size(140, 17);
            this.rbUpdateTask.TabIndex = 64;
            this.rbUpdateTask.Text = "Update existing item";
            this.rbUpdateTask.UseVisualStyleBackColor = true;
            this.rbUpdateTask.CheckedChanged += new System.EventHandler(this.rbUpdateTask_CheckedChanged);
            // 
            // rbCreateNew
            // 
            this.rbCreateNew.AutoSize = true;
            this.rbCreateNew.Checked = true;
            this.rbCreateNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCreateNew.ForeColor = System.Drawing.Color.Navy;
            this.rbCreateNew.Location = new System.Drawing.Point(31, 37);
            this.rbCreateNew.Name = "rbCreateNew";
            this.rbCreateNew.Size = new System.Drawing.Size(127, 17);
            this.rbCreateNew.TabIndex = 63;
            this.rbCreateNew.TabStop = true;
            this.rbCreateNew.Text = "Create a new item";
            this.rbCreateNew.UseVisualStyleBackColor = true;
            this.rbCreateNew.CheckedChanged += new System.EventHandler(this.rbCreateNew_CheckedChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Location = new System.Drawing.Point(738, 357);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(143, 37);
            this.lblDuration.TabIndex = 72;
            this.lblDuration.Text = "00:00:00";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(809, 314);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 31);
            this.btnStop.TabIndex = 71;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.Orange;
            this.btnPause.Location = new System.Drawing.Point(702, 314);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 31);
            this.btnPause.TabIndex = 70;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Green;
            this.btnStart.Location = new System.Drawing.Point(595, 314);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 31);
            this.btnStart.TabIndex = 69;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.Location = new System.Drawing.Point(916, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 75;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtStartTime
            // 
            this.txtStartTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartTime.Location = new System.Drawing.Point(1023, 660);
            this.txtStartTime.Mask = "00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(81, 28);
            this.txtStartTime.TabIndex = 76;
            this.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartTime.ValidatingType = typeof(System.DateTime);
            this.txtStartTime.Leave += new System.EventHandler(this.txtStartTime_Leave);
            // 
            // frmTracker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1104, 710);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rbUpdateTask);
            this.Controls.Add(this.rbCreateNew);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpExistingItem);
            this.Controls.Add(this.grpNewItem);
            this.Controls.Add(this.grpText);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dgEntries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Tracker for ADO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTracker_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTracker_FormClosed);
            this.Load += new System.EventHandler(this.frmTracker_Load);
            this.Shown += new System.EventHandler(this.frmTracker_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgEntries)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpNewItem.ResumeLayout(false);
            this.grpNewItem.PerformLayout();
            this.grpText.ResumeLayout(false);
            this.grpText.PerformLayout();
            this.grpExistingItem.ResumeLayout(false);
            this.grpExistingItem.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgEntries;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slDate;
        private System.Windows.Forms.ToolStripStatusLabel slTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnTimeTracker;
        private System.Windows.Forms.ToolStripMenuItem mnSaveList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.GroupBox grpNewItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStory;
        private System.Windows.Forms.GroupBox grpText;
        private System.Windows.Forms.Label lblItemText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox grpExistingItem;
        private System.Windows.Forms.Label lblItemtype;
        private System.Windows.Forms.ComboBox cmbTask;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoard;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTag3;
        private System.Windows.Forms.ComboBox cmbTag2;
        private System.Windows.Forms.ComboBox cmbTag1;
        private System.Windows.Forms.DateTimePicker dtTargetDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbUpdateTask;
        private System.Windows.Forms.RadioButton rbCreateNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefreshStory;
        private System.Windows.Forms.Button btnRefreshTaskBug;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem mnLoadData;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem mnTodoList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnGetFromTodoList;
        private System.Windows.Forms.ToolStripMenuItem mnFavoriteBoards;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbIteration;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.Button btnOpenBoardLink;
        private System.Windows.Forms.Button btnOpenStoryLink;
        private System.Windows.Forms.Button btnOpenItemLink;
        private System.Windows.Forms.ToolStripStatusLabel slUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtOriginalEstimate;
		private System.Windows.Forms.Button btnRefreshBoard;
		private System.Windows.Forms.ToolStripMenuItem mnStartNewDay;
		private System.Windows.Forms.ComboBox cmbTag4;
        private System.Windows.Forms.ToolStripStatusLabel slVersion;
		private System.Windows.Forms.Button btnListActiveItems;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbWbsCode;
		private System.Windows.Forms.ComboBox cmbItemType;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbState;
		private System.Windows.Forms.CheckBox chkUpdateOriginal;
		private System.Windows.Forms.CheckBox chkCloseItem;
        private System.Windows.Forms.ToolStripMenuItem mnSaveAndSendtoADO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DateTimePicker dtCreateDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddNewStory;
        private System.Windows.Forms.ToolStripMenuItem mnuShowActiveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewLinkColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalEstimate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCloseItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSaved;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUpdateOrgEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWbsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.Button btnOpenSupportApp;
        private System.Windows.Forms.ToolStripMenuItem mnTools;
    }
}

