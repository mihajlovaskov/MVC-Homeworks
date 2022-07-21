namespace BurgerAppRefactored.ViewModels
{
    public class BurgerOrderItemViewModel
    {
        public int Id { get; set; }
        public BurgerViewModel Burger { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
