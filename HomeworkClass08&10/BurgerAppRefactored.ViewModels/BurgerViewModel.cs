namespace BurgerAppRefactored.ViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
