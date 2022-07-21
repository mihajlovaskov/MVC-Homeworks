namespace BurgerAppRefactored.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public List<ExtraOrderItemViewModel> Extras { get; set; }
        public List<BurgerOrderItemViewModel> Burgers { get; set; }
        public bool IsOrderCompleted { get; set; }
        public decimal TotalPrice => (Burgers != null ? Burgers.Sum(x => x.Price * x.Quantity) : 0) + (Extras != null ? Extras.Sum(x => x.Quantity * x.Price) : 0);
    }
}