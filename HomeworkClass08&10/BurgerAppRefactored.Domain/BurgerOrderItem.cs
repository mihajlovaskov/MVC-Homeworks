namespace BurgerAppRefactored.Domain
{
    public class BurgerOrderItem
    {
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public BurgerOrderItem() { }
        public BurgerOrderItem(int burgerId, int orderId, int quantity, decimal price)
        {
            BurgerId = burgerId;
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }
    }
}
