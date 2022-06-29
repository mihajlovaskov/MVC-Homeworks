using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class UsersMapper
    {
        public static UsersViewModel ToUsersViewModel(User usersDb)
        {
            return new UsersViewModel
            {
                Id = usersDb.Id,
                FirstName = usersDb.FirstName,
                LastName = usersDb.LastName,
                PhoneNumber = usersDb.PhoneNumber,
            };
        }
    }
}
