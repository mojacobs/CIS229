using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229_Lab4_MMJ.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public int CampusId { get; set; }
        public string StudentEmail { get; set; }
        public string StartingCrossroads { get; set; }
        public string StartingTown { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public virtual Campus Campus { get; set; }
    }
}