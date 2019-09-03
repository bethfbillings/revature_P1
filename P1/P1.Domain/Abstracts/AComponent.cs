using System.ComponentModel.DataAnnotations;

namespace P1.Domain.Abstracts
{
    public abstract class AComponent
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a name!")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } 
    }
}