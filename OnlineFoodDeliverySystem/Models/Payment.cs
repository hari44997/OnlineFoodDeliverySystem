using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        
        public int? OrderID { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 100000.00, ErrorMessage = "Amount must be between 0.01 and 100000.00")]
        public decimal? Amount { get; set; }

        // Navigation Property
        public Order? Order { get; set; }
    }
}