using P1.Domain.Abstracts;

namespace P1.Domain.Models
{
    public class Topping : AComponent
    {
      public Topping(string NewName, decimal NewPrice)
      {
        Name = NewName;
        Price = NewPrice;
      }
    }
}