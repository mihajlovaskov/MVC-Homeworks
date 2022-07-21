namespace BurgerAppRefactored.Domain
{
    public class ExtraOrderItem
    {
        public int Id { get; set; }
        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ExtraOrderItem() { }
        public ExtraOrderItem(int extraId,int orderId, int quantity, decimal price)
        {
            ExtraId = extraId;
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }
    }
}
