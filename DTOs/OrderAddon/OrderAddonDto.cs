using FoodOrderingApp.DTOs.Addon;
using FoodOrderingApp.DTOs.Order;

namespace FoodOrderingApp.DTOs.OrderAddon
{
    public class OrderAddonDto
    {
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
        public int AddonId { get; set; }
        public AddonDto Addon { get; set; }
        public int Quantity { get; set; }
    }
}
