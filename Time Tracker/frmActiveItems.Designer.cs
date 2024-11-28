namespace TimeTracker
{
	partial class frmActiveItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgActiveItems = new System.Windows.Forms.DataGridView();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnCloseSelected = new System.Windows.Forms.Button();
            this.chkUpdateOriginal = new System.Windows.Forms.CheckBox();
            this.colItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUpdateOrgEst = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginalEstimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIterationPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWbsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActiveItems
            // 
            this.dgActiveItems.AllowUserToAddRows = false;
            this.dgActiveItems.AllowUserToDeleteRows = false;
            this.dgActiveItems.AllowUserToOrderColumns = true;
            this.dgActiveItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemType,
            this.colSelect,
            this.colUpdateOrgEst,
            this.colId,
            this.colTitle,
            this.colState,
            this.colOriginalEstimate,
            this.colCompleted,
            this.colAreaPath,
            this.colIterationPath,
            this.colWbsCode});
            this.dgActiveItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgActiveItems.Location = new System.Drawing.Point(0, 52);
            this.dgActiveItems.MultiSelect = false;
            this.dgActiveItems.Name = "dgActiveItems";
            this.dgActiveItems.Size = new System.Drawing.Size(1088, 398);
            this.dgActiveItems.TabIndex = 0;
            this.dgActiveItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveItems_CellContentClick);
            this.dgActiveItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveItems_CellDoubleClick);
            this.dgActiveItems.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgActiveItems_ColumnHeaderMouseDoubleClick);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(12, 23);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(101, 23);
            this.btnRefreshList.TabIndex = 1;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnCloseSelected
            // 
            this.btnCloseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSelected.Location = new System.Drawing.Point(131, 23);
            this.btnCloseSelected.Name = "btnCloseSelected";
            this.btnCloseSelected.Size = new System.Drawing.Size(137, 23);
            this.btnCloseSelected.TabIndex = 2;
            this.btnCloseSelected.Text = "Close Selected Items";
            this.btnCloseSelected.UseVisualStyleBackColor = true;
            this.btnCloseSelected.Click += new System.EventHandler(this.btnCloseSelected_Click);
            // 
            // chkUpdateOriginal
            // 
            this.chkUpdateOriginal.AutoSize = true;
            this.chkUpdateOriginal.Location = new System.Drawing.Point(284, 27);
            this.chkUpdateOriginal.Name = "chkUpdateOriginal";
            this.chkUpdateOriginal.Size = new System.Drawing.Size(202, 17);
            this.chkUpdateOriginal.TabIndex = 78;
            this.chkUpdateOriginal.Text = "Update original estimate when closed";
            this.chkUpdateOriginal.UseVisualStyleBackColor = true;
            // 
            // colItemType
            // 
            this.colItemType.HeaderText = "Item Type";
            this.colItemType.Name = "colItemType";
            this.colItemType.ReadOnly = true;
            this.colItemType.Width = 75;
            // 
            // colSelect
            // 
            this.colSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 43;
            // 
            // colUpdateOrgEst
            // 
            this.colUpdateOrgEst.HeaderText = "Update Org.Est.";
            this.colUpdateOrgEst.Name = "colUpdateOrgEst";
            this.colUpdateOrgEst.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUpdateOrgEst.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUpdateOrgEst.Width = 60;
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colId.Width = 41;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 52;
            // 
            // colState
            // 
            this.colState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colState.HeaderText = "State";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 57;
            // 
            // colOriginalEstimate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOriginalEstimate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOriginalEstimate.HeaderText = "Original Estimate";
            this.colOriginalEstimate.Name = "colOriginalEstimate";
            this.colOriginalEstimate.ReadOnly = true;
            this.colOriginalEstimate.Width = 60;
            // 
            // colCompleted
            // 
            this.colCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCompleted.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCompleted.HeaderText = "Competed Work";
            this.colCompleted.Name = "colCompleted";
            this.colCompleted.ReadOnly = true;
            this.colCompleted.Width = 60;
            // 
            // colAreaPath
            // 
            this.colAreaPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAreaPath.HeaderText = "Area Path";
            this.colAreaPath.Name = "colAreaPath";
            this.colAreaPath.ReadOnly = true;
            this.colAreaPath.Width = 73;
            // 
            // colIterationPath
            // 
            this.colIterationPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIterationPath.HeaderText = "Iteration Path";
            this.colIterationPath.Name = "colIterationPath";
            this.colIterationPath.ReadOnly = true;
            this.colIterationPath.Width = 88;
            // 
            // colWbsCode
            // 
            this.colWbsCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colWbsCode.HeaderText = "WBS Code";
            this.colWbsCode.Name = "colWbsCode";
            this.colWbsCode.Width = 79;
            // 
            // frmActiveItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 450);
            this.Controls.Add(this.chkUpdateOriginal);
            this.Controls.Add(this.btnCloseSelected);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.dgActiveItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActiveItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Active Items";
            this.Load += new System.EventHandler(this.frmActiveItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgActiveItems;
		private System.Windows.Forms.Button btnRefreshList;
		private System.Windows.Forms.Button btnCloseSelected;
		private System.Windows.Forms.CheckBox chkUpdateOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUpdateOrgEst;
        private System.Windows.Forms.DataGridViewLinkColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalEstimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIterationPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWbsCode;
    }
}