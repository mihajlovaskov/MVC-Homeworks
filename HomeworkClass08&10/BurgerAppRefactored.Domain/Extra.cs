using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Domain
{
    public class Extra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Extra() { }
        public Extra(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        public void Update(ExtraViewModel model)
        {
            Name = model.Name;
            Price = model.Price;
        }
    }
}
