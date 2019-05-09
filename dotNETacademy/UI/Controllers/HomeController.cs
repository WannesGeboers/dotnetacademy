using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNETacademy.Models;
using dotNETacademy.ViewModel;

namespace dotNETacademy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //controle bij inloggen
            //laad automatisch de hoofdpagina van de ingelogde persoon

            if(User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return View();
            }


            
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
