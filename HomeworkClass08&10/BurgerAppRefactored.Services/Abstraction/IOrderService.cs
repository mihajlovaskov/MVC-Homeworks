using BurgerAppRefactored.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.Services.Abstraction
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        void Create(OrderViewModel model);
        void Edit(OrderViewModel model);
        void Delete(int id);
        void CompleteOrder(int id);
    }
}