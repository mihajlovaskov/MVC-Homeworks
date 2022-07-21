using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerAppRefactored.Controllers
{
    public class BurgerOrderItemController : Controller
    {

        private readonly IBurgerOrderItemService _burgerOrderItemService;
        private readonly IBurgerService _burgerService;

        public BurgerOrderItemController(IBurgerOrderItemService burgerOrderItemService, IBurgerService burgerService)
        {
            _burgerOrderItemService = burgerOrderItemService;
            _burgerService = burgerService;
        }

        public IActionResult Create(int id)
        {
            ViewBag.burgers = _burgerService.GetAll().Select(x => new SelectListItem(x.Name.ToString(), x.Id.ToString())).ToList();
            return View(new BurgerOrderItemViewModel() { OrderId = id });
        }
        [HttpPost]
        public IActionResult Create(BurgerOrderItemViewModel model)
        {
            _burgerOrderItemService.Create(model);
            return RedirectToAction("Edit", "Order", new { id = model.OrderId });
        }
        public IActionResult Edit(int id)
        {
            var item = _burgerOrderItemService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(BurgerOrderItemViewModel model)
        {
            _burgerOrderItemService.Edit(model);
            return RedirectToAction("Edit", "Order", new { Id = model.OrderId });
        }
        public IActionResult Delete(int id)
        {
            var orderId = _burgerOrderItemService.Delete(id);
            return RedirectToAction("Edit", "Order", new { id = orderId });
        }
    }
}