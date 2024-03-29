﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P1.Client.Models;
using P1.Data.Entities;
using P1.Domain.Models;

namespace P1.Client.Controllers
{
    public class HomeController : Controller
    {

        private readonly p1Context _db = new p1Context();
        public IActionResult Index()
        {
            return View();
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

        public IActionResult OrderPizza()
        {
          return View("ThankYou");
        }
    }
}
