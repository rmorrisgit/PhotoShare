using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        // constructor 
        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
