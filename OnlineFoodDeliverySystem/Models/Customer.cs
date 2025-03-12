using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace OnlineFoodDeliverySystem
{
    public class Customer
    {
        [Key]
        public int? CustomerID { get; set; }
        public string? Name { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public ICollection<Order> ?Orders { get; set; }

    }
}
