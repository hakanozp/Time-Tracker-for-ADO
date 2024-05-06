namespace TimeTracker
{
    partial class frmSettings
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
			this.tabSettings = new System.Windows.Forms.TabControl();
			this.tabAdo = new System.Windows.Forms.TabPage();
			this.tabTags = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPersonelAccessToken = new System.Windows.Forms.TextBox();
			this.txtOrganizationUrl = new System.Windows.Forms.TextBox();
			this.txtOrganization = new System.Windows.Forms.TextBox();
			this.txtTags1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTags2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTags3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTags4 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabSettings.SuspendLayout();
			this.tabAdo.SuspendLayout();
			this.tabTags.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.tabAdo);
			this.tabSettings.Controls.Add(this.tabTags);
			this.tabSettings.Location = new System.Drawing.Point(21, 12);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.SelectedIndex = 0;
			this.tabSettings.Size = new System.Drawing.Size(598, 254);
			this.tabSettings.TabIndex = 12;
			// 
			// tabAdo
			// 
			this.tabAdo.BackColor = System.Drawing.SystemColors.Control;
			this.tabAdo.Controls.Add(this.label5);
			this.tabAdo.Controls.Add(this.txtUser);
			this.tabAdo.Controls.Add(this.btnSave);
			this.tabAdo.Controls.Add(this.label4);
			this.tabAdo.Controls.Add(this.label3);
			this.tabAdo.Controls.Add(this.label2);
			this.tabAdo.Controls.Add(this.txtPersonelAccessToken);
			this.tabAdo.Controls.Add(this.txtOrganizationUrl);
			this.tabAdo.Controls.Add(this.txtOrganization);
			this.tabAdo.Location = new System.Drawing.Point(4, 22);
			this.tabAdo.Name = "tabAdo";
			this.tabAdo.Padding = new System.Windows.Forms.Padding(3);
			this.tabAdo.Size = new System.Drawing.Size(590, 228);
			this.tabAdo.TabIndex = 0;
			this.tabAdo.Text = "ADO Connection Settings";
			// 
			// tabTags
			// 
			this.tabTags.BackColor = System.Drawing.SystemColors.Control;
			this.tabTags.Controls.Add(this.label10);
			this.tabTags.Controls.Add(this.label9);
			this.tabTags.Controls.Add(this.txtTags4);
			this.tabTags.Controls.Add(this.label8);
			this.tabTags.Controls.Add(this.txtTags3);
			this.tabTags.Controls.Add(this.label7);
			this.tabTags.Controls.Add(this.txtTags2);
			this.tabTags.Controls.Add(this.label6);
			this.tabTags.Controls.Add(this.txtTags1);
			this.tabTags.Location = new System.Drawing.Point(4, 22);
			this.tabTags.Name = "tabTags";
			this.tabTags.Padding = new System.Windows.Forms.Padding(3);
			this.tabTags.Size = new System.Drawing.Size(590, 228);
			this.tabTags.TabIndex = 1;
			this.tabTags.Text = "Tags";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(18, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 16);
			this.label5.TabIndex = 19;
			this.label5.Text = "User";
			// 
			// txtUser
			// 
			this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUser.Location = new System.Drawing.Point(178, 97);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(299, 22);
			this.txtUser.TabIndex = 18;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(178, 142);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 30);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "Save Settings";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(18, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(151, 16);
			this.label4.TabIndex = 16;
			this.label4.Text = "Personel Access Token";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(18, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "Organization URL";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(18, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Organization";
			// 
			// txtPersonelAccessToken
			// 
			this.txtPersonelAccessToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPersonelAccessToken.Location = new System.Drawing.Point(178, 71);
			this.txtPersonelAccessToken.Name = "txtPersonelAccessToken";
			this.txtPersonelAccessToken.Size = new System.Drawing.Size(400, 22);
			this.txtPersonelAccessToken.TabIndex = 13;
			// 
			// txtOrganizationUrl
			// 
			this.txtOrganizationUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOrganizationUrl.Location = new System.Drawing.Point(178, 45);
			this.txtOrganizationUrl.Name = "txtOrganizationUrl";
			this.txtOrganizationUrl.Size = new System.Drawing.Size(245, 22);
			this.txtOrganizationUrl.TabIndex = 12;
			// 
			// txtOrganization
			// 
			this.txtOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOrganization.Location = new System.Drawing.Point(178, 19);
			this.txtOrganization.Name = "txtOrganization";
			this.txtOrganization.Size = new System.Drawing.Size(167, 22);
			this.txtOrganization.TabIndex = 11;
			// 
			// txtTags1
			// 
			this.txtTags1.Location = new System.Drawing.Point(16, 25);
			this.txtTags1.Multiline = true;
			this.txtTags1.Name = "txtTags1";
			this.txtTags1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTags1.Size = new System.Drawing.Size(111, 167);
			this.txtTags1.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Tag Group 1";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(154, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Tag Group 2";
			// 
			// txtTags2
			// 
			this.txtTags2.Location = new System.Drawing.Point(153, 25);
			this.txtTags2.Multiline = true;
			this.txtTags2.Name = "txtTags2";
			this.txtTags2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTags2.Size = new System.Drawing.Size(111, 167);
			this.txtTags2.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(289, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Tag Group 3";
			// 
			// txtTags3
			// 
			this.txtTags3.Location = new System.Drawing.Point(288, 25);
			this.txtTags3.Multiline = true;
			this.txtTags3.Name = "txtTags3";
			this.txtTags3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTags3.Size = new System.Drawing.Size(111, 167);
			this.txtTags3.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(425, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Tag Group 4";
			// 
			// txtTags4
			// 
			this.txtTags4.Location = new System.Drawing.Point(424, 25);
			this.txtTags4.Multiline = true;
			this.txtTags4.Name = "txtTags4";
			this.txtTags4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTags4.Size = new System.Drawing.Size(111, 167);
			this.txtTags4.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 206);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(132, 13);
			this.label10.TabIndex = 8;
			this.label10.Text = "Enter one tag on each line";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 279);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(274, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "*Settings will be applied when you restart the application!";
			// 
			// frmSettings
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(637, 308);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tabSettings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSettings_FormClosed);
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.tabSettings.ResumeLayout(false);
			this.tabAdo.ResumeLayout(false);
			this.tabAdo.PerformLayout();
			this.tabTags.ResumeLayout(false);
			this.tabTags.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.TabControl tabSettings;
		private System.Windows.Forms.TabPage tabAdo;
		private System.Windows.Forms.TabPage tabTags;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPersonelAccessToken;
		private System.Windows.Forms.TextBox txtOrganizationUrl;
		private System.Windows.Forms.TextBox txtOrganization;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTags1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTags4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtTags3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTags2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
	}
}