using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string? Name { get; set; }
        [Required(ErrorMessage = "Enter Phone Number")]
        [MaxLength(10)]
        [RegularExpression("")]
        [DataType(DataType.PhoneNumber)]
        public int? Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        public string? Address { get; set; }

        public int? RoleID { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Role? Role { get; set; }

    }
}
