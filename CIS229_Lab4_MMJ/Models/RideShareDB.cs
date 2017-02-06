using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CIS229_Lab4_MMJ.Models
{
    public class RideShareDB : DbContext
    {
        public RideShareDB() : base("name=RideShareDB")
        {
        }

        public System.Data.Entity.DbSet<CIS229_Lab4_MMJ.Models.Ride> Rides { get; set; }
        public System.Data.Entity.DbSet<CIS229_Lab4_MMJ.Models.Campus> Campus { get; set; }
    }
}
