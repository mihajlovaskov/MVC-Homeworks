using BurgerAppRefactored.Domain;
using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order model)
        {
            return new OrderViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Extras = model.Extras.Select(x => x.ToViewModel()).ToList(),
                Burgers = model.Burgers.Select(x => x.ToViewModel()).ToList(),
                IsOrderCompleted = model.IsOrderCompleted
            };
        }
        public static List<OrderViewModel> OrderViewModels(this List<Order> orders)
        {
            return orders.Select(x => x.ToViewModel()).ToList();
        }
    }
}
