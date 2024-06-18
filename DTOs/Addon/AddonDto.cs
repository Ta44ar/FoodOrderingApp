namespace FoodOrderingApp.DTOs.Addon

{
    public class AddonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId {  get; set; }
    }
}
