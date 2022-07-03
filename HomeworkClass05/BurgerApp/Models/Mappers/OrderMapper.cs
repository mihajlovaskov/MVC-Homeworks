using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;

namespace BurgerApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                //BurgerId = order.BurgerId,
                BurgerName = order.Burger.Name,
                Location = order.Location,
                PaymentMethod = order.PaymentMethod
            };
        }
    }
}