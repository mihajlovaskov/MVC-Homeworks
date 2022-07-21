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
    public class ExtraService : IExtraService
    {
        private readonly IRepository<Extra> _extraRepository;

        public ExtraService(IRepository<Extra> extraRepository)
        {
            _extraRepository = extraRepository;
        }

        public List<ExtraViewModel> GetAll()
        {
            return _extraRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }
        public ExtraViewModel GetById(int id)
        {
            Extra model = _extraRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"Extra with id: {id} does not exist");
            }
            return model.ToViewModel();
        }
        public void Create(ExtraViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.Price <= 0)
            {
                throw new Exception("All inputs must be filled and price cannot be 0 or less");
            }
            if (_extraRepository.GetAll().Any(x => x.Name == model.Name))
            {
                throw new Exception("Extra with that name already exists");
            }
            _extraRepository.Insert(new Extra(model.Name, model.Price));
        }
        public void Edit(ExtraViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.Price <= 0)
            {
                throw new Exception("All inputs must be filled and price cannot be 0 or less");
            }
            if (_extraRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception("Extra with that name already exists");
            }
            Extra extra = _extraRepository.GetById(model.Id);
            if (extra == null)
            {
                throw new Exception($"Extra with id : {model.Id} does not exist");
            }
            extra.Update(model);
            _extraRepository.Update(extra);
        }
        public void Delete(int id)
        {
            Extra extraToDelete = _extraRepository.GetById(id);
            if (extraToDelete == null)
            {
                throw new Exception($"Extra with id : {id} does not exist");
            }
            _extraRepository.DeleteById(id);
        }
    }
}
