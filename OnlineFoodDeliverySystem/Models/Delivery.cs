using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }

        [Required]
        public int? OrderID { get; set; }

        [Required]
        public int? AgentID { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EstimatedTimeOfArrival { get; set; }

        // Navigation Properties
        public Order? Order { get; set; }
        public Agent? Agent { get; set; }
    }
}
