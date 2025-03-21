using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public int? Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? CustomerEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain both letters and numbers.")]
        public string? CustomerPassword { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        public int? RoleID { get; set; }

        // Navigation Property
        public ICollection<Order>? Orders { get; set; }
        public Role? Role { get; set; }
    }
}
