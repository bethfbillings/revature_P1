using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public int CrustId { get; set; }
        public int ToppingsId { get; set; }
        public string Name { get; set; }
    }
}
