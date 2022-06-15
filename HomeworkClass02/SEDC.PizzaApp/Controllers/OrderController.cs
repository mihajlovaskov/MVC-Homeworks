using Microsoft.AspNetCore.Mvc;

using SEDC.PizzaApp.Models;


namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("ListOrders")]
        public IActionResult Index()
        {
            List<Order> orders = StaticDb.Orders;
            return View(orders); ;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return RedirectToAction("Error");
            }

            return View(order);
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult JsonData()
        {
            List<Order> orders = StaticDb.Orders;
            return new JsonResult(orders);
        }
        [Route("Redirects")]
        public IActionResult RedirectionToHomeIndex()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
