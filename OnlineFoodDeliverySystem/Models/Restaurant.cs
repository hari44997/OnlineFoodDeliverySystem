namespace OnlineFoodDeliverySystem.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string? RestaurantName { get; set; }
        public int? Rating { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
