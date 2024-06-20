using FoodOrderingApp.DTOs.Restaurant;
using FoodOrderingApp.Interfaces;

namespace FoodOrderingApp.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepo;

        public RestaurantService(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public async Task<List<RestaurantDto>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepo.GetAllAsync();

            if (restaurants == null)
            {
                Console.WriteLine("Restaurant repository returned null getting all restaurants.");
                return null;
            }
            else
            {
                return restaurants;
            }
            
        }

        public async Task<RestaurantDto> GetRestaurantByUuid(string restaurantUuid)
        {
            var restaurant = await _restaurantRepo.GetByUuidAsync(restaurantUuid);

            if (restaurant == null)
            {
                Console.WriteLine("Restaurant repository returned null getting restaurant.");
                return null;
            }
            else
            {
                return restaurant;
            }
        }
    }
}