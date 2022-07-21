namespace BurgerAppRefactored.ViewModels
{
    public class ExtraOrderItemViewModel
    {
        public int Id { get; set; }
        public ExtraViewModel Extra { get; set; }
        public OrderViewModel Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }

    }
}
