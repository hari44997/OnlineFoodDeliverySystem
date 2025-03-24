using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace OnlineFoodDeliverySystem.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? Phone { get; set; }

        public ICollection<Delivery>? Deliveries { get; set; }

        
        public int? RoleID { get; set; }

        // Navigation Property
        public Role? Role { get; set; }
    }
}
