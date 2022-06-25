using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel(Pizza pizzaDb)
        {
            return new PizzaViewModel
            {
                Id = pizzaDb.Id,
                Name = pizzaDb.Name,
                PizzaSize = pizzaDb.PizzaSize,
                HasExtras = pizzaDb.HasExtras,
                Price = CorrectionInPrice(pizzaDb)
            };
        }
        public static decimal CorrectionInPrice(Pizza pizzaDb)
        {
            if (pizzaDb.HasExtras)
            {
                return pizzaDb.Price + 10;
            }
            else return pizzaDb.Price = pizzaDb.Price;
        }
    }
}
