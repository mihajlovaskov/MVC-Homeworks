using BurgerAppRefactored.DataAccess.Abstraction;
using BurgerAppRefactored.Domain;
using BurgerAppRefactored.Mappers;
using BurgerAppRefactored.Services.Abstraction;
using BurgerAppRefactored.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Services.Implementation
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepository;
        
        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public List<BurgerViewModel> GetAll()
        {
            return _burgerRepository.GetAll().Select(x => x.ToViewModel()).ToList();

        }
        public BurgerViewModel GetById(int id)
        {
            var item = _burgerRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Burger with id : {id} does not exist");
            }
            return item.ToViewModel();
        }

        public int Create(BurgerViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Ingredients) || string.IsNullOrEmpty(model.ImageUrl) || model.Price <= 0)
            {
                throw new Exception("All input fields must be filled , price cannot be 0 or less");
            }
            if (_burgerRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                throw new Exception("Burger with that name already exists");
            }
            Burger newBurger = new Burger(model.Name, model.Ingredients, model.ImageUrl, model.IsVegan, model.IsVegetarian, model.Price);
            _burgerRepository.Insert(newBurger);
            return newBurger.Id;
        }

        public void Edit(BurgerViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Ingredients) || string.IsNullOrEmpty(model.ImageUrl) || model.Price <= 0)
            {
                throw new Exception("All input fields must be filled , price cannot be 0 or less");
            }
            if (_burgerRepository.GetAll().Any(x => x.Name == model.Name && x.Id != model.Id))
            {
                throw new Exception("Burger with that name already exists");
            }
            Burger burger = _burgerRepository.GetById(model.Id);
            if (burger == null)
            {
                throw new Exception("The endpoint does not exist");
            }
            burger.Update(model);
            _burgerRepository.Update(burger);
        }


        public void Delete(int id)
        {
            Burger burgerToDelete = _burgerRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (burgerToDelete == null)
            {
                throw new Exception("Cannot perform that action");
            }
            _burgerRepository.DeleteById(id);
        }

    }
}
