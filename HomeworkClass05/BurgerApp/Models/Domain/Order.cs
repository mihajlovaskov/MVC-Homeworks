using BurgerApp.Models.Enums;

namespace BurgerApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
        public string Location { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}