using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmTodo : Form
    {

        public string title { get; private set; }
        public string description { get; private set; }

        DBHelper db = new DBHelper();

        public frmTodo()
        {
            InitializeComponent();
        }

        private void frmTodo_Load(object sender, EventArgs e)
        {
            dgTodoList.Rows.Clear();
            LoadTodoList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("You must enter a title!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgTodoList);

            row.Cells[dgTodoList.Columns["colTitle"].Index].Value = txtTitle.Text;
            row.Cells[dgTodoList.Columns["colDescription"].Index].Value = txtDescription.Text;

            dgTodoList.Rows.Add(row);

            txtTitle.Text = "";
            txtDescription.Text = "";

        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgTodoList.SelectedRows.Count > 0)
            {
                dgTodoList.Rows.RemoveAt(dgTodoList.SelectedRows[0].Index);
                return;
            }

            if (dgTodoList.SelectedCells.Count > 0)
            {
                MessageBox.Show("You must select a row to delete it!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void frmTodo_FormClosed(object sender, FormClosedEventArgs e)
        {
			SaveTodoList();
        }

        private void SaveTodoList()
        {
			try
			{
				db.SaveTodoList(dgTodoList.Rows);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error in saving favorite boards! /n" + exc.Message);
			}
		}

        private void LoadTodoList()
        {
			try
			{
				dgTodoList.Rows.Clear(); //clear existing data in grid

				SQLiteDataReader reader = db.LoadTodoList();
				while (reader.Read())
				{
					int rowIndex = dgTodoList.Rows.Add();
					DataGridViewRow row = dgTodoList.Rows[rowIndex];

					row.Cells["colTitle"].Value = reader["Title"].ToString();
					row.Cells["colDescription"].Value = reader["Description"].ToString();
				}
				reader.Close();

			}
			catch (Exception exc)
			{
				MessageBox.Show("Error in saving favorite boards! /n" + exc.Message);
			}
        }

        private void dgTodoList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTodoList.SelectedRows.Count > 0)
            {

                DataGridViewRow row = dgTodoList.Rows[e.RowIndex];

                title = row.Cells[dgTodoList.Columns["colTitle"].Index].Value.ToString();
                description = row.Cells[dgTodoList.Columns["colDescription"].Index].Value.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
