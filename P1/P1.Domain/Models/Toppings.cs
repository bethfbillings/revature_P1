using System.Collections.Generic;

namespace P1.Domain.Models
{
    public class Toppings
    {
        public int Id { get; set; }
        string ToppingsList { get; set; }
        decimal Price { get; set; }

        public Toppings(List<Topping> t)
        {
          string s = "";
          decimal p = 0;
          foreach(var top in t)
          {
            s = s + " " + top.Name; 
            p = p + top.Price;
          }
          ToppingsList = s;
          Price = p;
        }

    }
}