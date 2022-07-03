using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult BurgersMenu()
        {
            List<BurgerViewModel> burgers = StaticDb.Burgers.Select(x => x.ToBurgerViewModel()).ToList();

            return View(burgers);
        }

        public IActionResult CreateBurger()
        {
            BurgerViewModel burgerViewModel = new BurgerViewModel();

            return View(burgerViewModel);
        }

        [HttpPost]
        public IActionResult CreateBurgerPost(BurgerViewModel burgerViewModel)
        {
            bool doesBurgerExist = StaticDb.Burgers.Any(x => x.Name == burgerViewModel.Name);

            if (doesBurgerExist)
            {
                return View("DoesBurgerExist");
            }

            Burger burger = new Burger
            {
                Name = burgerViewModel.Name,
                IsVegan = burgerViewModel.IsVegan,
                IsVegetarian = burgerViewModel.IsVegetarian,
                HasFries = burgerViewModel.HasFries,
                Price = burgerViewModel.Price,
                Id = StaticDb.BurgerId + 1
            };

            StaticDb.Burgers.Add(burger);
            StaticDb.BurgerId++;

            return RedirectToAction("BurgersMenu");

        }

        public IActionResult EditBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burger == null)
            {
                return NotFound();
            }

            BurgerViewModel burgerViewModel = new BurgerViewModel
            {
                Name = burger.Name,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                Price = burger.Price,
                Id = burger.Id
            };


            return View(burgerViewModel);

        }

        public IActionResult EditBurgerPost(BurgerViewModel burgerViewModel)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id);

            if (burger == null)
            {
                return View("ResourceNotFound");
            }

            burger.Price = burgerViewModel.Price;
            burger.Name = burgerViewModel.Name;
            burger.IsVegetarian = burgerViewModel.IsVegetarian;
            burger.IsVegan = burgerViewModel.IsVegan;
            burger.HasFries = burgerViewModel.HasFries;

            return RedirectToAction("BurgersMenu");

        }

        public IActionResult DeleteBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burger == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Burgers.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Burgers.RemoveAt(index);

            return RedirectToAction("BurgersMenu");


        }
    }
}