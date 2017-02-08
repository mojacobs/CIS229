using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIS229_Lab4_MMJ.Models
{
    public class Ride
    {
        public virtual int RideId { get; set; }

        public virtual int CampusId { get; set; }

        [DisplayName("Student Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be an email address.")]
        public virtual string StudentEmail { get; set; }

        [DisplayName("Starting Crossroads")]
        public virtual string StartingCrossroads { get; set; }

        [DisplayName("Starting Town")]
        [Required(ErrorMessage = "You must select a starting town.")]
        public virtual string StartingTown { get; set; }

        [DisplayName("Day Of The Week")]
        [Required(ErrorMessage = "You must select a day of the week.")]
        [RegularExpression(@"(Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day", ErrorMessage = "Does not look like a valid day of the week.")]
        public virtual string DayOfWeek { get; set; }

        [DisplayName("Time Start")]
        public virtual TimeSpan TimeStart { get; set; }

        [DisplayName("Time End")]
        public virtual TimeSpan TimeEnd { get; set; }

        [Required(ErrorMessage = "You must select a campus.")]
        public virtual Campus Campus { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string Requirements { get; set; }
    }
}