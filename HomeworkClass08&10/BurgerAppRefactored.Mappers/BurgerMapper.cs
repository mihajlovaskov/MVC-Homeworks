using BurgerAppRefactored.Domain;
using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerViewModel ToViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Ingredients = burger.Ingredients,
                ImageUrl = burger.ImageUrl,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                Price = burger.Price
            };
        }

        public static List<BurgerViewModel> BurgerViewModels(this List<Burger> burgers)
        {
            return burgers.Select(x => x.ToViewModel()).ToList();
        }
    }
}
