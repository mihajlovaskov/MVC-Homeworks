using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurgerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;
        private readonly IBurgerOrderItemService _burgerOrderItemService;


        public HomeController(ILogger<HomeController> logger, IOrderService orderService, IBurgerService burgerService, IBurgerOrderItemService burgerOrderItemService)
        {
            _logger = logger;
            _orderService = orderService;
            _burgerService = burgerService;
            _burgerOrderItemService = burgerOrderItemService;
        }

        public IActionResult Index()
        {
            
           HomeViewModel homeViewModel = new HomeViewModel();
           homeViewModel.MostPopularBurger = _burgerOrderItemService.GetMostPopularBurger();
           return View(homeViewModel);
            
        }
        
        public IActionResult NoOrders()
        {
            var items = _orderService.GetAll();
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}