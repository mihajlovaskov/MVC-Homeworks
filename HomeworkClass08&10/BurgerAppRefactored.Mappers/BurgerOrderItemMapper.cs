using BurgerAppRefactored.Domain;
using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class BurgerOrderItemMapper
    {
        public static BurgerOrderItemViewModel ToViewModel(this BurgerOrderItem burger)
        {
            return new BurgerOrderItemViewModel()
            {
                Id = burger.Id,
                Burger = burger.Burger.ToViewModel(),
                Quantity = burger.Quantity,
                Price = burger.Price,
                IsSelected = false,
                OrderId = burger.OrderId,
            };
        }
    }
}
