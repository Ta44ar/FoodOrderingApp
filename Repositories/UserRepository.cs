using FoodOrderingApp.Data;
using FoodOrderingApp.DTOs.User;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Mappers;
using FoodOrderingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingApp.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppUserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => u.ToAppUserDto())
                .ToListAsync();
        }

        public async Task<AppUserDto> GetByIdAsync(int id)
        {
            return await _context.Users
                .Select(u => u.ToAppUserDto())
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AppUser?> UpdateUserDetailsAsync(AppUser appUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == appUser.Id);

            if (user == null)
            {
                user = new AppUser
                {
                    Id = appUser.Id,
                    UserName = appUser.UserName,
                    PhoneNumber = appUser.PhoneNumber,
                    BankAccountNumber = appUser.BankAccountNumber,
                    Role = "USER"
                };

                await _context.Users.AddAsync(user);
            }
            else
            {
                user.UserName = appUser.UserName;
                user.PhoneNumber = appUser.PhoneNumber;
                user.BankAccountNumber = appUser.BankAccountNumber;
            }

            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> UserExists(string username)
        {
            return _context.Users.AnyAsync(u => u.UserName == username);
        }
    }
}
