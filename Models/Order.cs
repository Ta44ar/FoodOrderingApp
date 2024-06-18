using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingApp.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public AppUser AppUser { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string? DishName { get; set; }
        public int? DishId { get; set; }
        public Dish? Dish { get; set; }
        public List<OrderAddon?> OrderAddons { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsCommentEditing { get; set; } = false;
        public string MessageContent {  get; set; } = string.Empty;
    }
}