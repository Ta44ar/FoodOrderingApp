using FoodOrderingApp.DTOs.Addon;
using FoodOrderingApp.DTOs.Dish;
using FoodOrderingApp.DTOs.Restaurant;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantDto>> GetAllAsync();
        Task<RestaurantDto> GetByUuidAsync(string uuid);

        //Task<List<DishDto>> GetAllDishesAsync(int id);
        //Task<List<AddonDto>> GetAllAddonsAsync(int id);
    }
}
