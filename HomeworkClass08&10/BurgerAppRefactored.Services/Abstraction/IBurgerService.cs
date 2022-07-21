using BurgerAppRefactored.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Services.Abstraction
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetAll();
        BurgerViewModel GetById(int id);
        int Create(BurgerViewModel model);
        void Edit(BurgerViewModel model);
        void Delete(int id);

    }
}
