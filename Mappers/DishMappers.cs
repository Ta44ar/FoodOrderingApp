using FoodOrderingApp.DTOs.Dish;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Mappers
{
    public static class DishMappers
    {
        public static DishDto ToDishDto(this Dish dishModel)
        {
            return new DishDto
            {
                Id = dishModel.Id,
                Name = dishModel.Name,
                Price = dishModel.Price,
                Description = dishModel.Description,
                RestaurantId = dishModel.RestaurantId
            };
        }
    }
}
