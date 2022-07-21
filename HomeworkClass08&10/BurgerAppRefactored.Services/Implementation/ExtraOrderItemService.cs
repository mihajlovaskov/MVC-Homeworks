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
    public class ExtraOrderItemService : IExtraOrderItemService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Extra> _extraRepository;
        private readonly IRepository<ExtraOrderItem> _extraOrderItemRepository;

        public ExtraOrderItemService(IRepository<Order> orderRepository, IRepository<Extra> extraRepository, IRepository<ExtraOrderItem> extraOrderItemRepository)
        {
            _orderRepository = orderRepository;
            _extraRepository = extraRepository;
            _extraOrderItemRepository = extraOrderItemRepository;
        }

        public void Create(ExtraOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with id: {model.OrderId} does not exist");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            var extra = _extraRepository.GetById(model.Extra.Id);
            if (extra == null)
            {
                throw new Exception("Please select a valid burger");
            }
            else if (model.Quantity <= 0)
            {
                throw new Exception("Quantity cannot be 0 or less");
            }
            if (order.Extras.Any(x => x.ExtraId == extra.Id))
            {
                var existingBurger = order.Extras.First(x => x.ExtraId == extra.Id);
                existingBurger.Quantity += model.Quantity;
            }
            else
            {
                order.Extras.Add(new ExtraOrderItem(extra.Id, order.Id, model.Quantity, extra.Price));
            }
            _orderRepository.Update(order);
        }


        public void Edit(ExtraOrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);
            if (order == null)
            {
                throw new Exception($"Order with Id : {model.OrderId} does not exist.");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            if (model.Quantity <= 0)
            {
                throw new Exception($"Quantity cannot be 0 or less");
            }
            var editItem = order.Extras.FirstOrDefault(x => x.Id == model.Id);
            editItem.Quantity = model.Quantity;
            _orderRepository.Update(order);
        }

        public ExtraOrderItemViewModel GetById(int id)
        {
            var item = _extraOrderItemRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Item with id:{id} does not exist");
            }
            return item.ToViewModel();
        }

        public int Delete(int id)
        {
            var order = _orderRepository.GetAll().FirstOrDefault(x => x.Extras.Any(y => y.Id == id));
            if (order == null)
            {
                throw new Exception($"Order with id :{order.Id} does not contain item with id : {id}");
            }
            if (order.IsOrderCompleted)
            {
                throw new Exception("Order is already completed you cannot edit at this time");
            }
            var item = order.Extras.FirstOrDefault(x => x.Id == id);
            order.Extras.Remove(item);
            _orderRepository.Update(order);
            return order.Id;
        }
    }
}
