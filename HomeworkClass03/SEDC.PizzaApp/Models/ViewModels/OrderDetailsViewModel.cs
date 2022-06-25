using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public string PizzaName { get;set; }
        public string UserFullname { get;set; }
        public decimal Price { get;set; }
        public PaymentMethod PaymentMethod { get;set; }
        public string UserAddress { get; set; }
        public bool HasExtras { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
