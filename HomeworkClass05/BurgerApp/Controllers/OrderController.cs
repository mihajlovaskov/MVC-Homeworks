using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult SeeOrders()
        {
            List<Order> allOrders = StaticDb.Orders;
            List<OrderDetailsViewModel> allOrderViewModels = allOrders.Select(x => x.ToOrderDetailsViewModel()).ToList();

            ViewData["Header"] = "List of orders:";

            return View(allOrderViewModels);
        }

        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();


            ViewBag.Burgers = StaticDb.Burgers.Select(x => new BurgerDDViewModel
            {
                Id = x.Id,
                Name = x.Name
            });

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = StaticDb.OrderId + 1,
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                IsDelivered = false,
                Burger = burgerDb,
                Location = orderViewModel.Location,
                PaymentMethod = orderViewModel.PaymentMethod,
            };

            StaticDb.Orders.Add(newOrder);
            StaticDb.OrderId++;

            return RedirectToAction("SeeOrders");

        }

        public IActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            if (!StaticDb.Orders.Any(x => x.Id == id))
            {
                return View("ResourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            ViewBag.Burgers = StaticDb.Burgers.Select(x => new BurgerDDViewModel
            {
                Id = x.Id,
                Name = x.Name
            });
            OrderViewModel orderViewModel = new OrderViewModel
            {
                IsDelivered = order.IsDelivered,
                PaymentMethod = order.PaymentMethod,
                FullName = order.FullName,
                Address = order.Address,
                BurgerName = order.Burger.Name,
                Location = order.Location,
                Id = order.Id,
            };
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id);
            if (order == null)
            {
                return View("ResourceNotFound");
            }

            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burger == null)
            {
                return View("ResourceNotFound");
            }

            order.Burger = burger;
            order.FullName = orderViewModel.FullName;
            order.Location = orderViewModel.Location;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.Address = orderViewModel.Address;

            return RedirectToAction("SeeOrders");
        }

        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.RemoveAt(index);

            return RedirectToAction("SeeOrders");

        }

    }
}