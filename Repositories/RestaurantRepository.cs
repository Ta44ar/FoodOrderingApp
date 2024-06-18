using FoodOrderingApp.Data;
using FoodOrderingApp.DTOs.Restaurant;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingApp.Services
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RestaurantDto>> GetAllAsync()
        {
            var restaurants = await _context.Restaurants
                .Select(r => new RestaurantDto
                {
                    Uuid = r.Uuid,
                    Name = r.Name,
                    Description = r.Description
                })
                .ToListAsync();

            return restaurants;
        }

        public async Task<RestaurantDto> GetByUuidAsync(string uuid)
        {
            var selectedRestaurant = await _context.Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Addons)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Uuid.Equals(uuid));

            return selectedRestaurant.ToRestaurantDto();
        }
    }
}
