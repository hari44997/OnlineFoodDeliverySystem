using System.ComponentModel.DataAnnotations;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }


        public int? CustomerID { get; set; }


        public int? RestaurantID { get; set; }

        public int? AgentID { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 100000.00, ErrorMessage = "Total amount must be between 0.01 and 100000.00")]
        public double? TotalAmount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Agent? Agent { get; set; }
        public Customer? Customer { get; set; }
        public Payment? Payment { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Delivery? Delivery { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}