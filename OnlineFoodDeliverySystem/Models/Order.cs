using System.ComponentModel.DataAnnotations;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required,]
        public int? CustomerID { get; set; }
        public int? RestaurantID { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [DataType(DataType.Currency)]
        public double? TotalAmount { get; set; }

        public DateTime? OrderDate { get; set; } = DateTime.UtcNow;





        public Customer? Customer { get; set; }
        public Payment? Payment { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Delivery? Delivery { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
    public enum OrderStatus
    {
        Pending,
        Accepted,
        Preparing,
        Delivered
    }
}
