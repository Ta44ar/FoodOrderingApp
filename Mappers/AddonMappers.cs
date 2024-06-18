using FoodOrderingApp.DTOs.Addon;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Mappers
{
    public static class AddonMappers
    {
        public static AddonDto ToAddonDto(this Addon addonModel)
        {
            return new AddonDto
            {
                Id = addonModel.Id,
                Name = addonModel.Name,
                Price = addonModel.Price,
                RestaurantId = addonModel.RestaurantId
            };
        }
    }
}
