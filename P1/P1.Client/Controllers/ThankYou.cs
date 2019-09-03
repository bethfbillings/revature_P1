using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using P1.Client.Models;

namespace P1.Client.Controllers
{
    public class ThankYou : Controller
    {

        public IActionResult Index()
        {
            return View("ThankYou");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}