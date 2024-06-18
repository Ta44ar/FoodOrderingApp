using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingApp.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [Required]
        public string Uuid { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Dish>? Dishes { get; set; }
        public List<Addon>? Addons { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal DeliveryCost { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal MinSumToDeliver { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal FreeDeliverySum { get; set; }
    }
}
