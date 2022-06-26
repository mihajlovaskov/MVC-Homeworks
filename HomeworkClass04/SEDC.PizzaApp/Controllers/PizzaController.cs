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
            List<PizzaViewModel> pizzaViewModels = pizzaDb.Select(x => PizzaMapper.ToPizzaViewModel(x))
                .ToList();
            //return View(dbPizzas);
            return View(pizzaViewModels);

            //List<Pizza> dbPizzas = StaticDb.Pizzas;
            //return View(dbPizzas);
        }

        public IActionResult Details(int? id)
        {
            //if(id == null)
            //{
            //    return RedirectToAction("Error");
            //}

            //Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            //if(pizza == null)
            //{
            //    //return RedirectToAction("Error");
            //    return View("ResourceNotFound");
            //}

            //return View(pizza);

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
            PizzaViewModel pizzaViewModels = PizzaMapper.ToPizzaViewModel(pizza);

            return View(pizzaViewModels);

        }

        //public IActionResult Error()
        //{
        //    return View();
        //}

    }
}
