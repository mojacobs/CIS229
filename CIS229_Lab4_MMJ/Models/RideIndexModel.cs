using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS229_Lab4_MMJ.Models
{
    public class RideIndexModel
    {
        public IEnumerable<Ride> Rides { get; set; }

        public IEnumerable<SelectListItem> Campuses { get; set; }

        public int SelectedCampusId { get; set; }
    }
}