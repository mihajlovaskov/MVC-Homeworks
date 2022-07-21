using BurgerAppRefactored.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Services.Abstraction
{
    public interface IExtraService
    {
        List<ExtraViewModel> GetAll();
        ExtraViewModel GetById(int id);
        void Create(ExtraViewModel model);
        void Edit(ExtraViewModel model);
        void Delete(int id);
    }
}
