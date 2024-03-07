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
    public partial class frmChangeDuration : Form
    {
        public DateTime startTime;
        public DateTime endTime;
        public string duration;

        
        public frmChangeDuration()
        {
            InitializeComponent();
        }

        private void frmChangeDuration_Load(object sender, EventArgs e)
        {

            txtStartTime.Text = startTime.ToShortTimeString();
            txtEndTime.Text = endTime.ToShortTimeString();

            TimeSpan duration = endTime.Subtract(startTime);
            lblDuration.Text = duration.ToString(@"hh\:mm"); 

        }

        private void txtStartTime_Leave(object sender, EventArgs e)
        {
            startTime = Convert.ToDateTime(txtStartTime.Text);
            endTime = Convert.ToDateTime(txtEndTime.Text);

            lblDuration.Text = endTime.Subtract(startTime).ToString(@"hh\:mm");
            duration = lblDuration.Text;

        }

        private void txtEndTime_Leave(object sender, EventArgs e)
        {
            startTime = Convert.ToDateTime(txtStartTime.Text);
            endTime = Convert.ToDateTime(txtEndTime.Text);

            lblDuration.Text = endTime.Subtract(startTime).ToString(@"hh\:mm");
            duration = lblDuration.Text;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
