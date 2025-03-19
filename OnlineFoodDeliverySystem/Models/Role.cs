using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string[] Names { get; set; } = { "Admin", "Customer", "Agent" };

        //Navigation Property
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Agent>? Agents { get; set; }
        public ICollection<Admin>? Admins { get; set; }
    }
}
