using Automarket.DAL.Interfaces;
using Automarket.Models;
using AutomarketDomaun.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Automarket.Controllers
{
    public class HomeController : Controller
    {
       

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
    }


}