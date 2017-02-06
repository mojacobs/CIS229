using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229_Lab4_MMJ.Models
{
    public class Ride
    {
        public virtual int RideId { get; set; }
        public virtual int CampusId { get; set; }
        public virtual string StudentEmail { get; set; }
        public virtual string StartingCrossroads { get; set; }
        public virtual string StartingTown { get; set; }
        public virtual string DayOfWeek { get; set; }
        public virtual TimeSpan TimeStart { get; set; }
        public virtual TimeSpan TimeEnd { get; set; }
        public virtual Campus Campus { get; set; }
    }
}