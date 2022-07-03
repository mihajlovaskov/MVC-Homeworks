using BurgerApp.Models.Domain;

namespace BurgerApp
{
    public static class StaticDb
    {
        public static int BurgerId = 2;
        public static int OrderId = 2;

        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
                Id = 1,
                Name = "Hamburger",
                Price = 200,
                IsVegan = false,
                IsVegetarian = false,
                HasFries = true
            },

            new Burger()
            {
                Id=2,
                Name = "Cheeseburger",
                Price = 150,
                IsVegan = false,
                IsVegetarian = true,
                HasFries = true
            },
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                FullName = "Stojko Stojkovski",
                Address = "Ilindenska 5",
                IsDelivered = false,
                Burger = Burgers.First(x => x.Id == 1),
                BurgerId = 1,
                Location = "Centar",
                PaymentMethod = Models.Enums.PaymentMethod.Cash
            },

            new Order()
            {
                Id = 2,
                FullName = "Trajko Trajkov",
                Address = "Partizanska 8",
                IsDelivered = true,
                Burger = Burgers.First(x => x.Id == 2),
                BurgerId = 2,
                Location = "Karposh",
                PaymentMethod = Models.Enums.PaymentMethod.Card
            },
        };
    }
}