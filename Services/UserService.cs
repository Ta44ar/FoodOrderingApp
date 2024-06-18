using FoodOrderingApp.DTOs.User;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<AppUserDto>> GetAll()
        {
            var users = await _userRepo.GetAllUsersAsync();

            return users;
        }

        public async Task<AppUserDto> GetById(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            return user;
        }

        public async Task<AppUser> UpdateUser(AppUser user)
        {
            if (user == null)
            {
                await _userRepo.UpdateUserDetailsAsync(user);
                return user;
            } else
            {
                return null;
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return await _userRepo.UserExists(username);
        }
    }
}
