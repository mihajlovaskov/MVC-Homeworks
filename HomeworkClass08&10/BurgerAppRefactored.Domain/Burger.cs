using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Domain
{
    public class Burger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public decimal Price { get; set; }
        public Burger() { }
        public Burger(string name, string ingredients, string imageUrl, bool isVegan, bool isVegetarian, decimal price)
        {
            Name = name;
            Ingredients = ingredients;
            ImageUrl = imageUrl;
            IsVegan = isVegan;
            IsVegetarian = isVegetarian;
            Price = price;
        }

        public void Update(BurgerViewModel model)
        {
            Name = model.Name;
            Ingredients = model.Ingredients;
            ImageUrl = model.ImageUrl;
            IsVegan = model.IsVegan;
            IsVegetarian = model.IsVegetarian;
            Price = model.Price;
        }
    }
}

