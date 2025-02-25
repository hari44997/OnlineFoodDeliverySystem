using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string? Status { get; set; }
        public double TotalAmount { get; set; }

    }
}
