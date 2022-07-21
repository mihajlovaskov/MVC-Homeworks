using BurgerAppRefactored.Domain;
using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class ExtraOrderItemMapper
    {
        public static ExtraOrderItemViewModel ToViewModel(this ExtraOrderItem extra)
        {
            return new ExtraOrderItemViewModel
            {
                Id = extra.Id,
                Extra = extra.Extra.ToViewModel(),
                Quantity = extra.Quantity,
                Price = extra.Price,
                IsSelected = false,
                OrderId = extra.OrderId
            };
        }
    }
}
