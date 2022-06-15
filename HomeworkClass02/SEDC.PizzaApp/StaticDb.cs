using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza> {
        new Pizza()
        {
            Id = 1,
            Name = "Capri",
            Price = 300,
            IsOnPromotion = true
        },
        new Pizza()
        {
            Id = 2,
            Name = "Pepperoni",
            Price = 400,
            IsOnPromotion = false
        },
    };

        public static List<Order> Orders = new List<Order> {
        new Order()
        {
            Id = 1,
            Name = "Pepperoni",
            Price = 300,
            Size = "small"
        },
        new Order()
        {
            Id = 2,
            Name = "Capri",
            Price = 400,
            Size = "medium"
        },
          new Order()
        {
            Id = 3,
            Name = "Pepperoni",
            Price = 400,
            Size = "small"
        }
    };

    }
}
