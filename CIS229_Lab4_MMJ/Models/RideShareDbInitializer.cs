using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;


namespace CIS229_Lab4_MMJ.Models
{
    public class RideShareDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RideShareDB>
    {
        protected override void Seed(RideShareDB context)
        {
            context.Campus.Add(new Campus
            {
                Name = "OCB",
                Address = "1600 Chester Avenue",
                City = "Bremerton"
            });
            context.Campus.Add(new Campus
            {
                Name = "OCP",
                Address = "1000 Olympic College Way NW",
                City = "Poulsbo"
            });
            context.Campus.Add(new Campus
            {
                Name = "OCS",
                Address = "937 W Alpine Way",
                City = "Shelton"
            });

            base.Seed(context);
        }
    }
}