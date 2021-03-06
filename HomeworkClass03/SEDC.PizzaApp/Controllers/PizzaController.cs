using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {

            List<Pizza> pizzaDb = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = pizzaDb.Select(x => x.ToPizzaViewModel())
                .ToList();
            //return View(dbPizzas);
            return View(pizzaViewModels);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                //return RedirectToAction("Error");
                return new EmptyResult();
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                //return RedirectToAction("Error");
                return new EmptyResult();
            }
            PizzaViewModel pizzaViewModels = pizza.ToPizzaViewModel();

            return View(pizzaViewModels);
        }

        //public IActionResult Error()
        //{
        //    return View();
        //}

    }
}
