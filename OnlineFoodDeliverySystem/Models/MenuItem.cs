using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemID { get; set; }
        public int CustomerID{ get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal? Price { get; set; }

        public int? RestaurantID { get; set; }

        // Navigation Properties
        public Restaurant? Restaurant { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
