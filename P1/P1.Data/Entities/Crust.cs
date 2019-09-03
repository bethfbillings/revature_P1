using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Crust
    {
        public Crust()
        {
            CustomPizza = new HashSet<CustomPizza>();
        }

        public int CrustId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CustomPizza> CustomPizza { get; set; }
    }
}
