using FoodOrderingApp.DTOs.Dish;
using FoodOrderingApp.DTOs.OrderAddon;

namespace FoodOrderingApp.DTOs.Order
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderAddons = new List<OrderAddonDto>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public DishDto? Dish { get; set; }
        public int? DishId { get; set; }
        public string? DishName { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public bool IsCommentEditing { get; set; }
        public List<OrderAddonDto> OrderAddons { get; set; }
        public string MessageContent { get; set; }
    }
}
