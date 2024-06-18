using FoodOrderingApp.DTOs.Restaurant;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Mappers
{
    public static class RestaurantMappers
    {
        public static RestaurantDto ToRestaurantDto(this Restaurant restaurantModel)
        {
            return new RestaurantDto
            {
                Id = restaurantModel.Id,
                Uuid = restaurantModel.Uuid,
                Name = restaurantModel.Name,
                Description = restaurantModel.Description,
                DeliveryCost = restaurantModel.DeliveryCost,
                MinSumToDeliver = restaurantModel.MinSumToDeliver,
                FreeDeliverySum = restaurantModel.FreeDeliverySum,
                Dishes = restaurantModel.Dishes.Select(d => d.ToDishDto()).ToList(),
                Addons = restaurantModel.Addons.Select(a => a.ToAddonDto()).ToList()
            };
        }
    }
}
