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
			this.colItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colId = new System.Windows.Forms.DataGridViewLinkColumn();
			this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAreaPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colIterationPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colOriginalEstimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCompeted = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colId,
            this.colTitle,
            this.colState,
            this.colAreaPath,
            this.colIterationPath,
            this.colOriginalEstimate,
            this.colCompeted});
			this.dgActiveItems.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgActiveItems.Location = new System.Drawing.Point(0, 61);
			this.dgActiveItems.Name = "dgActiveItems";
			this.dgActiveItems.ReadOnly = true;
			this.dgActiveItems.Size = new System.Drawing.Size(908, 371);
			this.dgActiveItems.TabIndex = 0;
			this.dgActiveItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveItems_CellContentClick);
			this.dgActiveItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveItems_CellDoubleClick);
			// 
			// colItemType
			// 
			this.colItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colItemType.HeaderText = "Item Type";
			this.colItemType.Name = "colItemType";
			this.colItemType.ReadOnly = true;
			this.colItemType.Width = 79;
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
			// colAreaPath
			// 
			this.colAreaPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colAreaPath.HeaderText = "Area Path";
			this.colAreaPath.Name = "colAreaPath";
			this.colAreaPath.ReadOnly = true;
			this.colAreaPath.Width = 79;
			// 
			// colIterationPath
			// 
			this.colIterationPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colIterationPath.HeaderText = "Iteration Path";
			this.colIterationPath.Name = "colIterationPath";
			this.colIterationPath.ReadOnly = true;
			this.colIterationPath.Width = 95;
			// 
			// colOriginalEstimate
			// 
			this.colOriginalEstimate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.colOriginalEstimate.DefaultCellStyle = dataGridViewCellStyle1;
			this.colOriginalEstimate.HeaderText = "Original Estimate";
			this.colOriginalEstimate.Name = "colOriginalEstimate";
			this.colOriginalEstimate.ReadOnly = true;
			this.colOriginalEstimate.Width = 101;
			// 
			// colCompeted
			// 
			this.colCompeted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.colCompeted.DefaultCellStyle = dataGridViewCellStyle2;
			this.colCompeted.HeaderText = "Competed Work";
			this.colCompeted.Name = "colCompeted";
			this.colCompeted.ReadOnly = true;
			// 
			// frmActiveItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 432);
			this.Controls.Add(this.dgActiveItems);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmActiveItems";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmActiveItems";
			this.Load += new System.EventHandler(this.frmActiveItems_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgActiveItems)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgActiveItems;
		private System.Windows.Forms.DataGridViewTextBoxColumn colItemType;
		private System.Windows.Forms.DataGridViewLinkColumn colId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn colState;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAreaPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIterationPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOriginalEstimate;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCompeted;
	}
}