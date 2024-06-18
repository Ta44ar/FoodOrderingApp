using FoodOrderingApp.DTOs.User;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Mappers
{
    public static class AppUserMappers
    {
        public static AppUserDto ToAppUserDto(this AppUser appUser)
        {
            return new AppUserDto
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                PhoneNumber = appUser.PhoneNumber,
                BankAccountNumber = appUser.BankAccountNumber,
                Role = appUser.Role
            };
        }
    }
}
