using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;

namespace BurgerApp.Models.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerViewModel ToBurgerViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
                Price = burger.Price
            };
        }
    }
}