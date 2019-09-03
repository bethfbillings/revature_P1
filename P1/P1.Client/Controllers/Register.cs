using Microsoft.AspNetCore.Mvc;
using P1.Data.Entities;
using P1.Domain.Models;

namespace P1.Client.Controllers
{
    public class Register : Controller
    {
      P1.Client.Models.Register r = new P1.Client.Models.Register();
      private readonly p1Context _db = new p1Context();
      
      [HttpGet]
      public IActionResult Index()
      {
        return View("Register");
      }

      [HttpPost]
      public IActionResult Index(string newEmail, string newPassword, string fname, string lname)
      {
        RegisterNewUser(newEmail, newPassword, fname, lname);
        return View("Register");
      }
      
      public void RegisterNewUser(string newEmail, string newPassword, string fname, string lname)
      {
        _db.User.Add(new Data.Entities.User
        {
          Email = newEmail,
          Password = newPassword,
          Name = new Data.Entities.Name{
            FirstName = fname, 
            LastName = lname } 
        });
        _db.SaveChanges();
      }
    }
}