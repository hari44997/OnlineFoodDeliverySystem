using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain both letters and numbers.")]
        public string? Password { get; set; }

       
        public int? RoleID { get; set; }

        // Navigation Property
        public Role? Role { get; set; }
    }
}