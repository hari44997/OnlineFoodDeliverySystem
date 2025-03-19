using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int AdminID { get; set; }
        public string? AdminName { get; set; }

        //Email Address
        [DataType(DataType.EmailAddress)]
        public string? AdminEmail { get; set; }

        //Password
        [DataType(DataType.Password)]
        public string? AdminPassword { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
    }
}
