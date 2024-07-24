namespace TimeTracker
{
	partial class frmDateSelection
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
			this.dtReportDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSelectDate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dtReportDate
			// 
			this.dtReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtReportDate.Location = new System.Drawing.Point(98, 59);
			this.dtReportDate.Name = "dtReportDate";
			this.dtReportDate.Size = new System.Drawing.Size(104, 20);
			this.dtReportDate.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(59, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select a date to load data from";
			// 
			// btnSelectDate
			// 
			this.btnSelectDate.Location = new System.Drawing.Point(110, 99);
			this.btnSelectDate.Name = "btnSelectDate";
			this.btnSelectDate.Size = new System.Drawing.Size(80, 23);
			this.btnSelectDate.TabIndex = 2;
			this.btnSelectDate.Text = "Load";
			this.btnSelectDate.UseVisualStyleBackColor = true;
			this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
			// 
			// frmDateSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 160);
			this.Controls.Add(this.btnSelectDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtReportDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmDateSelection";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Date";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtReportDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelectDate;
	}
}