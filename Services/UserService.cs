using FoodOrderingApp.DTOs.User;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Models;
using Microsoft.Graph.Models;

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

            if (users == null)
            {
                Console.WriteLine("User repository returned null getting all o them.");
                return null;
            }
            else
            {
                return users;
            }
        }

        public async Task<AppUserDto> GetById(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
            {
                Console.WriteLine("User repository returned null getting one by Id.");
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<AppUser> UpdateUser(AppUser user)
        {
            try
            {
                await _userRepo.UpdateUserDetailsAsync(user);
                return user;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return await _userRepo.UserExists(username);
        }
    }
}
