using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Location
    {
        public Location()
        {
            Order = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Province { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
