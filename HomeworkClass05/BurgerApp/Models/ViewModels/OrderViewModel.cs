using BurgerApp.Models.Enums;

namespace BurgerApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public string BurgerName { get; set; }
        public string Location { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Id { get; set; }
    }
}