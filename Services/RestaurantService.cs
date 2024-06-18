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

            return restaurants;
        }

        public async Task<RestaurantDto> GetRestaurantByUuid(string restaurantUuid)
        {
            var restaurant = await _restaurantRepo.GetByUuidAsync(restaurantUuid);

            return restaurant;
        }

        //public async Task<List<DishDto>> GetRestaurantDishes(int restaurantId)
        //{
        //    var restaurantDishes = await _restaurantRepo.GetAllDishesAsync(restaurantId);

        //    return restaurantDishes;
        //}

        //public async Task<List<AddonDto>> GetRestaurantAddons(int restaurantId)
        //{
        //    var restaurantAddons = await _restaurantRepo.GetAllAddonsAsync(restaurantId);

        //    return restaurantAddons;
        //}
    }
}