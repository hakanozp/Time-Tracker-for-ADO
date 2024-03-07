using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmTodo : Form
    {

        public string title { get; private set; }
        public string description { get; private set; }
        public string dataDirectory;

        public frmTodo()
        {
            InitializeComponent();
        }

        private void frmTodo_Load(object sender, EventArgs e)
        {
            LoadDataFromFile();
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
            SaveGridToFile();
        }

        private void SaveGridToFile()
        {
            //set date in file name to day loaded
            string fileName = dataDirectory + "\\todo.txt";

            StreamWriter writer = new StreamWriter(fileName);

            // Write the header row (optional)
            writer.WriteLine(string.Join("\t", dgTodoList.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText)));

            // Loop through each row
            foreach (DataGridViewRow row in dgTodoList.Rows)
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

        private void LoadDataFromFile()
        {
            string fileName = dataDirectory + "\\todo.txt";
            if (!File.Exists(fileName)) return;

            dgTodoList.Rows.Clear(); //clear existing data in grid

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
                row.CreateCells(dgTodoList);

                // Add values to each cell
                for (int i = 0; i < values.Length; i++)
                {
                    row.Cells[i].Value = values[i];
                }

                // Add the row to the DataGridView
                dgTodoList.Rows.Add(row);
            }

            reader.Close();

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
