using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;

namespace BurgerApp.Models.Mappers
{
    public static class OrderDetailsMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                BurgerName = order.Burger.Name,
                Location = order.Location,
                PaymentMethod = order.PaymentMethod,
                Price = order.Burger.Price
            };
        }
    }
}