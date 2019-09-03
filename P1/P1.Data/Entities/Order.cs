using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Order
    {
        public Order()
        {
            CustomPizza = new HashSet<CustomPizza>();
        }

        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int UserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CustomPizza> CustomPizza { get; set; }
  }
}
