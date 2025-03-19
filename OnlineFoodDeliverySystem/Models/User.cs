using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class User

    {
        [Key]
        public int UserID { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
    }
}
