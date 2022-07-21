using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurgerWebApp.Controllers
{
    public class ExtraOrderItemController : Controller
    {
        private readonly IExtraService _extraService;
        private readonly IExtraOrderItemService _extraOrderItemService;

        public ExtraOrderItemController(IExtraService extraService, IExtraOrderItemService extraOrderItemService)
        {
            _extraService = extraService;
            _extraOrderItemService = extraOrderItemService;
        }

        public IActionResult Create(int id)
        {
            ViewBag.extras = _extraService.GetAll().Select(x => new SelectListItem(x.Name.ToString(), x.Id.ToString())).ToList();
            return View(new ExtraOrderItemViewModel() { OrderId = id });
        }

        [HttpPost]
        public IActionResult Create(ExtraOrderItemViewModel model)
        {
            _extraOrderItemService.Create(model);
            return RedirectToAction("Edit", "Order", new { id = model.OrderId });
        }

        public IActionResult Edit(int id)
        {
            var item = _extraOrderItemService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(ExtraOrderItemViewModel model)
        {
            _extraOrderItemService.Edit(model);
            return RedirectToAction("Edit", "Order", new { id = model.OrderId });

        }

        public IActionResult Delete(int id)
        {
            int orderId = _extraOrderItemService.Delete(id);
            return RedirectToAction("Edit", "Order", new { id = orderId });
        }
    }
}