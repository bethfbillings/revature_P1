using P1.Domain.Abstracts;

namespace P1.Domain.Models
{
    public class Size : AComponent
    {
      public Size(string NewName, decimal NewPrice)
      {
        Name = NewName;
        Price = NewPrice;
      }
    }
}