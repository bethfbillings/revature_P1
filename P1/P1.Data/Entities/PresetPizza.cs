using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class PresetPizza
    {
        public int PresetPizzaId { get; set; }
        public int RecipeId { get; set; }
        public int OrderId { get; set; }

        public int SizeId { get; set; }

    }
}
