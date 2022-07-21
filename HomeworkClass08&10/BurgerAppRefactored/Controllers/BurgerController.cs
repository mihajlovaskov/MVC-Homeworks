using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerAppRefactored.Controllers
{
    public class BurgerController : Controller
    {
        private readonly IBurgerService _burgerService;


        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            List<BurgerViewModel> burgers = _burgerService.GetAll();
            return View(burgers);
        }

        public IActionResult Details(int id)
        {
            BurgerViewModel burger = _burgerService.GetById(id);
            return View(burger);
        }

        public IActionResult Edit(int id)
        {
            BurgerViewModel burger = _burgerService.GetById(id);
            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(BurgerViewModel model)
        {
            _burgerService.Edit(model);
            return RedirectToAction("Index", "Burger");
        }

        public IActionResult Create()
        {
            return View(new BurgerViewModel());
        }

        [HttpPost]
        public IActionResult Create(BurgerViewModel model)
        {
            int id = _burgerService.Create(model);
            return RedirectToAction("Details", "Burger", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            _burgerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
