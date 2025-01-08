using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class ADOTask
    {
        public int Id {  get; set; }
        public string ItemType { get; set; }
        public string AssignedTo { get; set; }
        public string ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AreaPath { get; set; }
        public string IterationPath { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public double OriginalEstimate { get; set; }
        public double CompletedWork { get; set; }
        public string Tags { get; set; }
        public string History { get; set; }
        public Boolean UpdateOriginalEstimate { get; set; }
		public string WBS { get; set; }
	}
}
