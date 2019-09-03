namespace P1.Domain.Models
{
    class PresetPizza
    {
        public int Id { get; set; }
        public Recipe Recipe;
        public Order Order;

        public PresetPizza(Recipe NewRecipe, Order NewOrder)
        {
          Recipe = NewRecipe;
          Order = NewOrder;
        }
    }
}