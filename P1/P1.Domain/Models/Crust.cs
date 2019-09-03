using P1.Domain.Abstracts;
using P1.Data.Entities;

namespace P1.Domain.Models
{
    public class Crust : AComponent
    {
      public Crust(string NewName, decimal NewPrice)
      {
        Name = NewName;
        Price = NewPrice; 
      }

      
    }

}