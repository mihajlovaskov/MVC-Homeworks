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
        }

        //invoking the extension method that maps the Pizza model with the Pizza Model View
        //inside a method which invokes the corresponding View. The Mapper file/class is not used... 
        [Route("Extension")] 
        public IActionResult GetPizzasExtensionMethod() 
        { 
            List<Pizza> pizzaDb = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = pizzaDb.Select(x => Pizza.PizzaModelToPizzaViewModel(x))
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
            PizzaViewModel pizzaViewModels = PizzaMapper.ToPizzaViewModel(pizza);

            return View(pizzaViewModels);
        }

        //public IActionResult Error()
        //{
        //    return View();
        //}

    }
}
