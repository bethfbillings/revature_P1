using System;
using System.Collections.Generic;
using System.Linq;
using P1.Data.Entities;

namespace P1.Domain.Models
{
  public class Order
  {
      private readonly p1Context _db = new p1Context();
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public TimeSpan Time { get; set; }

      public Order()
      {
        Date = DateTime.Now;
        Time = DateTime.Now.TimeOfDay;
      }

      public void FindId()
        {
          var orders = _db.Order.ToList();
          foreach (var ord in orders)
          {
            if ((ord.Date.Equals(Date)) && (ord.Time.Equals(Time)))
            {
              Id = ord.OrderId;
            }
          }
        }

      public void AddNewPPizza(Recipe r, Size s)
        {
          FindId();
          _db.PresetPizza.Add(new Data.Entities.PresetPizza
          {
            RecipeId = r.Id,
            SizeId = s.Id,
            OrderId = Id
          });
          _db.SaveChanges();
        }

        public void AddNewCPizza(Size s, Toppings t)
        {
          FindId();
          _db.CustomPizza.Add(new Data.Entities.CustomPizza
          {
            ToppingsId = t.Id,
            SizeId = s.Id,
            OrderId = Id
          });
          _db.SaveChanges();
        }

        //Order should be able to view its pizzas
        public List<Data.Entities.PresetPizza> GetPPizzaList()
        {
          return _db.PresetPizza.ToList();
        }

        //Order should be able to view its pizzas
        public List<Data.Entities.CustomPizza> GetCPizzaList()
        {
          return _db.CustomPizza.ToList();
        }

        //Order should be able to compute its cost
        public decimal ComputeCost()
        {
          var PPizzas = GetPPizzaList();
          var CPizzas = GetCPizzaList();
          decimal cost = 0;
          foreach (var Pizza in PPizzas)
          {
            var r = _db.Recipe.ElementAt(Pizza.RecipeId);
            cost = cost + _db.Toppings.ElementAt(r.ToppingsId).Price;
            cost = cost + _db.Crust.ElementAt(r.CrustId).Price;
            cost = cost + _db.Size.ElementAt(Pizza.SizeId).Price;
          }
          foreach (var Pizza in CPizzas)
          {
            cost = cost + _db.Size.ElementAt(Pizza.SizeId).Price;
            cost = cost + _db.Crust.ElementAt(Pizza.CrustId).Price;
            cost = cost + _db.Toppings.ElementAt(Pizza.ToppingsId).Price;
          }
          return cost;
        }

        //Order should be able to limit its cost to no more than $5000
        public bool LimitCost()
        {
          var cost = ComputeCost();
          if (cost <= 5000)
          {
            return true;
          }
          return false;
        }

        //Order should be able to limit its pizza count to no more than 100
        public bool LimitCount()
        {
          var count = GetPPizzaList().Count + GetCPizzaList().Count;
          if (count <= 100)
          {
            return true;
          } 
          return false;
        }

  }
}