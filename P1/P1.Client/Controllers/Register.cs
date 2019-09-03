using Microsoft.AspNetCore.Mvc;
using P1.Domain.Models;

namespace P1.Client.Controllers
{
    public class Register : Controller
    {
      public IActionResult Index()
      {
        return View("Register");
      }

      
      public void RegisterNewUser()
      {
        User u = new User
        (
          "{Email}",
          "{Password}",
          new Name("{fname}", "{lname}"),
          new Order()
        );
      }
    }
}