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

        private DateTime tmpStartTime;
        private DateTime tmpEndTime;


        
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
            if (DateTime.TryParse(txtStartTime.Text, out startTime) == false)
            {
                txtStartTime.Text = tmpStartTime.ToShortTimeString();
                startTime = tmpStartTime;
            }
            endTime = Convert.ToDateTime(txtEndTime.Text);

            lblDuration.Text = endTime.Subtract(startTime).ToString(@"hh\:mm");
            duration = lblDuration.Text;

        }

        private void txtEndTime_Leave(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtEndTime.Text, out endTime) == false)
            {
                txtEndTime.Text = tmpEndTime.ToShortTimeString();
                endTime = tmpEndTime;
            }
            startTime = Convert.ToDateTime(txtStartTime.Text);
            
            lblDuration.Text = endTime.Subtract(startTime).ToString(@"hh\:mm");
            duration = lblDuration.Text;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStartTime_Enter(object sender, EventArgs e)
        {
            DateTime.TryParse(txtStartTime.Text, out tmpStartTime);
        }

        private void txtEndTime_Enter(object sender, EventArgs e)
        {
            DateTime.TryParse(txtEndTime.Text, out tmpEndTime);
        }
    }
}
