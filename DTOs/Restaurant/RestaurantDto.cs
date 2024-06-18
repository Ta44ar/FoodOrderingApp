using FoodOrderingApp.DTOs.Addon;
using FoodOrderingApp.DTOs.Dish;

namespace FoodOrderingApp.DTOs.Restaurant
{
    public class RestaurantDto
    {
        public RestaurantDto()
        {
            Dishes = new List<DishDto>();
            Addons = new List<AddonDto>();
        }

        public string Uuid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal MinSumToDeliver { get; set; }
        public decimal FreeDeliverySum { get; set; }
        public List<DishDto> Dishes { get; set; }
        public List<AddonDto> Addons { get; set; }

    }
}