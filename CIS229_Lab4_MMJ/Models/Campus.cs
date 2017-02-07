using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CIS229_Lab4_MMJ.Models
{
    public class Campus
    {
        public virtual int CampusId { get; set; }

        [DisplayName("Campus")]
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }
    }
}