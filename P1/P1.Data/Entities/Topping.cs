using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Topping
    {
        public int ToppingId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
