using System;
using System.Collections.Generic;

namespace P1.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public int NameId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Name Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
