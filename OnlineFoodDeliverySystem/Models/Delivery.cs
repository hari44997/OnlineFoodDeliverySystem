using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Delivery
    {
        [Key]

        public int DeliveryID { get; set; }
        public int OrderID {  get; set; }
        public int AgentID { get; set; }
        public string Status { get; set; } //In Progress,Delivered
        public TimeOnly EstimatedTimeOfArrival {  get; set; }
        public Order Order { get; set; }

        //public ICollection<Order> Orders { get; set; }
        
    }
}
