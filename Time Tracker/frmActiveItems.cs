using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
	public partial class frmActiveItems : Form
	{
		public string projectName;
		public ADOHelper ado;
		public ADOTask adoTask;

		public frmActiveItems()
		{
			InitializeComponent();
		}

		private void frmActiveItems_Load(object sender, EventArgs e)
		{
			_ = LoadActiveItems();
		}

		private async Task LoadActiveItems()
		{
			
			Dictionary<int, string> storyList = new Dictionary<int, string>();

			var workItems = await ado.GetOpenItems(projectName);

			foreach (var workItem in workItems)
			{
				//"System.Id", "System.Title", "System.State", "System.AreaPath", "System.WorkItemType", "System.IterationPath",
				
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(dgActiveItems);

				row.Cells[dgActiveItems.Columns["colId"].Index].Value = workItem.Id.ToString();
				row.Cells[dgActiveItems.Columns["colTitle"].Index].Value = workItem.Fields["System.Title"].ToString();
				row.Cells[dgActiveItems.Columns["colAreaPath"].Index].Value = workItem.Fields["System.AreaPath"].ToString();
				row.Cells[dgActiveItems.Columns["colItemType"].Index].Value = workItem.Fields["System.WorkItemType"].ToString();
				row.Cells[dgActiveItems.Columns["colState"].Index].Value = workItem.Fields["System.State"].ToString();
				row.Cells[dgActiveItems.Columns["colIterationPath"].Index].Value = workItem.Fields["System.IterationPath"].ToString();
				if (workItems[0].Fields.ContainsKey("Microsoft.VSTS.Scheduling.OriginalEstimate"))
					row.Cells[dgActiveItems.Columns["colOriginalEstimate"].Index].Value = workItem.Fields["Microsoft.VSTS.Scheduling.OriginalEstimate"].ToString();

				if (workItems[0].Fields.ContainsKey("Microsoft.VSTS.Scheduling.CompletedWork"))
					row.Cells[dgActiveItems.Columns["colCompeted"].Index].Value = workItem.Fields["Microsoft.VSTS.Scheduling.CompletedWork"].ToString();

				dgActiveItems.Rows.Add(row);
			}
		}

		private void dgActiveItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgActiveItems.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgActiveItems.Rows[e.RowIndex];

				adoTask = new ADOTask();
				adoTask.Id = Convert.ToInt32(row.Cells[dgActiveItems.Columns["colId"].Index].Value.ToString());
				adoTask.AreaPath = row.Cells[dgActiveItems.Columns["colAreaPath"].Index].Value.ToString();
				adoTask.Title = row.Cells[dgActiveItems.Columns["colTitle"].Index].Value.ToString();
				adoTask.ItemType = row.Cells[dgActiveItems.Columns["colItemType"].Index].Value.ToString();
				adoTask.State = row.Cells[dgActiveItems.Columns["colState"].Index].Value.ToString();
				adoTask.IterationPath = row.Cells[dgActiveItems.Columns["colIterationPath"].Index].Value.ToString();
				DialogResult = DialogResult.OK;
				Close();
			}

		}

		private void dgActiveItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dgActiveItems.Columns["colId"].Index)
			{
				DataGridViewRow row = dgActiveItems.Rows[e.RowIndex];
				if (row.Cells["colId"].Value != null)
				{
					string link = String.Format("{0}/{1}/_workitems/edit//{2}", ado.OrganizationUrl, "PBI_DS", row.Cells[dgActiveItems.Columns["colId"].Index].Value.ToString());
					System.Diagnostics.Process.Start(link);
				}
			}
		}
	}
}
