using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string? AdminName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? AdminEmail { get; set; }
        [DataType(DataType.Password)]
        public string? AdminPassword { get; set; }
    }
}
