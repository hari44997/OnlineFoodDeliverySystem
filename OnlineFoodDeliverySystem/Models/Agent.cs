using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace OnlineFoodDeliverySystem.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int? Phone { get; set; }
        public ICollection<Delivery>? Deliveries { get; set; }

        public int? RoleID { get; set; }

        public Role? Role { get; set; }


    }
}
