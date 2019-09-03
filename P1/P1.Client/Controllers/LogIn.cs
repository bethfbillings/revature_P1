using Microsoft.AspNetCore.Mvc;
using P1.Domain.Models;

namespace P1.Client.Controllers
{
    public class LogIn : Controller
    {
      public IActionResult Index()
      {
        return View("LogIn");
      }

      
      public void RegisterNewUser()
      {
      
      }
    }
}