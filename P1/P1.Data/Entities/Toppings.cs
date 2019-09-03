using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Toppings
    {
        public Toppings()
        {
            CustomPizza = new HashSet<CustomPizza>();
        }

        public int ToppingsId { get; set; }
        public string List { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CustomPizza> CustomPizza { get; set; }
    }
}
