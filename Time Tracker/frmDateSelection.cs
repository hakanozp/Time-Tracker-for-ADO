using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
	public partial class frmDateSelection : Form
	{
		public DateTime selectedDate;
		public frmDateSelection()
		{
			InitializeComponent();
		}

		private void btnSelectDate_Click(object sender, EventArgs e)
		{
			selectedDate = dtReportDate.Value;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void frmDateSelection_Load(object sender, EventArgs e)
		{

		}
	}
}
