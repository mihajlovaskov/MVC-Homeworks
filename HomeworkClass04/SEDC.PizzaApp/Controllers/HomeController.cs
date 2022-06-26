using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using System.Diagnostics;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //localhost:[port]/AboutUs
        [Route("AboutUs")]
        public IActionResult About()
        {
            return View();
        }

        //localhost:[port]/Home/Contact
        public IActionResult Contact()
        {
            return View();
        }

        // There are many other ways to handle the task properly (task: show a list of Users' full names in View by
        // using some method in Home controller), but I decided to use the ViewBag solution as to repeat
        // what was taught during Class 04
        public IActionResult SeeUsers()
        {
            ViewData["Title"] = "List of users:";
            ViewBag.data = StaticDb.Users;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}