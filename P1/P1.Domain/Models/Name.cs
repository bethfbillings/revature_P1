using P1.Domain.Abstracts;

namespace P1.Domain.Models
{
    public class Name 
    {
        public int Id { get; set; }
        public string FirstName;
        public string LastName;

        public Name(string first, string last)
        {
          FirstName = first;
          LastName = last; 
        }
    }
}