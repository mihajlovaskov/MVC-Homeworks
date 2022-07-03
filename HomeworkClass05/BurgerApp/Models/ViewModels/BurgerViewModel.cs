using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModels
{
    public class BurgerViewModel
    {
        [Display(Name = "Burger name")]
        public string Name { get; set; }

        [Display(Name = "Vegetarian")]
        public bool IsVegetarian { get; set; }

        [Display(Name = "Vegan")]
        public bool IsVegan { get; set; }

        [Display(Name = "Fries")]
        public bool HasFries { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
    }
}