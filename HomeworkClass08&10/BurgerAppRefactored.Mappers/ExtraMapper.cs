using BurgerAppRefactored.Domain;
using BurgerAppRefactored.ViewModels;

namespace BurgerAppRefactored.Mappers
{
    public static class ExtraMapper
    {
        public static ExtraViewModel ToViewModel(this Extra extra)
        {
            return new ExtraViewModel
            {
                Id = extra.Id,
                Name = extra.Name,
                Price = extra.Price
            };
        }

        public static List<ExtraViewModel> ExtraViewModels(this List<Extra> extra)
        {
            return extra.Select(x => x.ToViewModel()).ToList();
        }
    }
}
