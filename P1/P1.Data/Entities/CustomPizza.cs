using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class CustomPizza
    {
        public int CustomPizzaId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public int ToppingsId { get; set; }
        public int OrderId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Order Order { get; set; }
        public virtual Size Size { get; set; }
        public virtual Toppings Toppings { get; set; }
    }
}
