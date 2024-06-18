using FoodOrderingApp.DTOs.User;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Interfaces
{
    public interface IUserRepository
    {
        Task<List<AppUserDto>> GetAllUsersAsync();
        Task<AppUserDto> GetByIdAsync(int id);
        Task<AppUser?> UpdateUserDetailsAsync(AppUser user);
        Task<bool> UserExists(string username);
    }
}
