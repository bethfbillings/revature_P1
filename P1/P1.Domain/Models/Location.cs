using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P1.Data.Entities;

namespace P1.Domain.Models
{
    public class Location
    {
        private readonly p1Context _db = new p1Context();

        public int Id { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Province { get; set; }

        public Location(string NewStreet, string NewTown, string NewProvince)
        {
          Street = NewStreet;
          Town = NewTown;
          Province = NewProvince;
        }

        public Location()
        {
          
        }

        public void FindId()
        {
          var locs = _db.Location.ToList();
          foreach (var loc in locs)
          {
            if (loc.Street.Equals(Street))
            {
              Id = loc.LocationId;
            }
          }
        }

        public void AddNewCrust(Crust c)
        {
          _db.Crust.Add(new P1.Data.Entities.Crust
          {
            Name = c.Name,
            Price = c.Price
          });
          _db.SaveChanges();
        }

        public void AddNewTopping(Topping t)
        {
          _db.Crust.Add(new P1.Data.Entities.Crust
          {
            Name = t.Name,
            Price = t.Price
          });
          _db.SaveChanges();
        }

        public void AddNewSize(Size s)
        {
          _db.Size.Add(new P1.Data.Entities.Size
          {
            Name = s.Name,
            Price = s.Price
          });
          _db.SaveChanges();
        }

        public void AddNewRecipe(Recipe r)
        {
          _db.Recipe.Add(new P1.Data.Entities.Recipe
          {
            Name = r.Name,
            CrustId = r.Crust.Id,
            ToppingsId = r.Toppings.Id
          });
          _db.SaveChanges();
        }

        public List<Data.Entities.Crust> GetCrustList()
        {
          return _db.Crust.ToList();
        }

        public List<Data.Entities.Size> GetSizeList()
        {
          return _db.Size.ToList();
        }

        //Location should be able to view its inventory
        public List<Data.Entities.Topping> ViewInventory()
        {
          FindId();
          var AllToppings = _db.Topping.ToList();
          var LocToppings = new List<Data.Entities.Topping>();
          foreach (var Topping in AllToppings)
          {
            if (Topping.LocationId.Equals(Id))
            {
              LocToppings.Add(Topping);
            }
          }
          return LocToppings;
        }

        public List<Data.Entities.Recipe> GetRecipeList()
        {
          return _db.Recipe.ToList();
        }

        public List<Data.Entities.Order> GetLocOrders()
        {
          FindId();
          var AllOrders = _db.Order.ToList();
          var LocOrders = new List<Data.Entities.Order>();
          foreach (var Order in AllOrders)
          {
            if (Order.LocationId.Equals(Id))
            {
              LocOrders.Add(Order);
            }
          }
          return LocOrders;
        }

        //Location should be able to view its orders (number of pizzas sold)
        public int ViewOrders()
        {
          int orders = 0;
          var PPizzas = _db.PresetPizza.ToList();
          var CPizzas = _db.CustomPizza.ToList();
          var LocOrders = GetLocOrders();
          foreach (var Order in LocOrders)
          {
            foreach (var Pizza in PPizzas)
            {
              if (Pizza.OrderId.Equals(Order.LocationId))
              {
                orders++;
              }
            }
            foreach (var Pizza in CPizzas)
            {
              if (Pizza.OrderId.Equals(Order.LocationId))
              {
                orders++;
              }
            }
          }
          return orders;
        }

        //Location should be able to view its users
        public List<Data.Entities.User> ViewUsers()
        {
          var LocOrders = GetLocOrders();
          var Users = _db.User.ToList();
          var LocUsers = new List<Data.Entities.User>();
          foreach (var User in Users)
          {
            foreach (var Order in LocOrders)
            {
              if (Order.UserId.Equals(User.UserId))
              {
                if (!LocUsers.Contains(User))
                {
                  LocUsers.Add(User);
                }
              }
            }
          }
          return LocUsers;
        }

        //Location should be able to view its sales
        public int ViewSales()
        {
          return ViewUsers().Count;
        }
    }
}