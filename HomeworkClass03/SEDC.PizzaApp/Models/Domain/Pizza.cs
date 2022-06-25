using SEDC.PizzaApp.Models.Enums;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsOnPromotion { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool HasExtras { get; set; }

        //using extension method, instead of PizzaMapper Class, for creating a mapper from Pizza model to Pizza View Model
        public static PizzaViewModel PizzaModelToPizzaViewModel(Pizza pizzaDb)
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
