namespace P1.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Crust Crust { get; set; }

        public Toppings Toppings { get; set; }

        public Recipe(string NewName, Crust NewCrust, Toppings NewToppings)
        {
          Name = NewName;
          Crust = NewCrust;
          Toppings = NewToppings;
        }
    }
}