using System;
using System.Collections.Generic;
using System.Linq;
using P1.Data.Entities;

namespace P1.Domain.Models
{
  public class User
  {
      private readonly p1Context _db = new p1Context();
      public int Id { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public Name Name { get; set; }
      public Order Order { get; set; }

      public User(string NewEmail, string NewPassword, Name NewName, Order NewOrder)
      {
        Email = NewEmail;
        Password = NewPassword;
        Name = NewName;
        Order = NewOrder;
        _db.User.Add(new P1.Data.Entities.User
          {
            Name = new Data.Entities.Name{
              FirstName = Name.FirstName,
              LastName = Name.LastName
            },
            Email = NewEmail,
            Password = NewPassword
          });
        _db.SaveChanges();

      }

      public void FindId()
        {
          var users = _db.User.ToList();
          foreach (var user in users)
          {
            if (user.Email.Equals(Email))
            {
              Id = user.UserId;
            }
          }
        }

      public void AddNewOrder()
      {
          FindId();
          var o = new Order();
          _db.Order.Add(new P1.Data.Entities.Order
          {
            UserId = Id,
            Date = o.Date,
            Time = o.Time
          });
          _db.SaveChanges();
      }

      //User should be able to view its order history
      public List<Data.Entities.Order> ViewOrderHistory()
      {
        return _db.Order.Where(a => a.UserId == Id).ToList();
      }

      //User should be able to only order from 1 location per day
      public bool ValidateDay()
      {
        DateTime today = DateTime.Now;
        foreach (var day in ViewOrderHistory())
        {
          if (day.Date.Date == today.Date)
          {
            return false;
          }
        }
        return true;
      }

      public bool ValidateAccount(string e, string p)
      {
        var users = _db.User.ToList();
        foreach (var user in users)
        {
          if((user.Email == Email) && (user.Password == Password))
          {
            return true;
          }
        }
        return false;
      }

      
  }
}