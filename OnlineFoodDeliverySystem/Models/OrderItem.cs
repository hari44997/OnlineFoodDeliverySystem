using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class OrderItem
    {
        [Key]
        public int? OrderItemID { get; set; }
        public int? OrderID {  get; set; }
        public int? ItemID {  get; set; }
        public int? Quantity {  get; set; }
        public decimal? Price {  get; set; }

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
