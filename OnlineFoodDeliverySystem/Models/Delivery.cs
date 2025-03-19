using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Delivery
    {
        [Key]

        public int DeliveryID { get; set; }
        public int? OrderID {  get; set; }
        public int? AgentID { get; set; }
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Progress;

        [DataType(DataType.DateTime)]
        public DateTime EstimatedTimeOfArrival {  get; set; }
        public Order? Order { get; set; }

        public Agent? Agent { get; set; }
        
    }

    public enum DeliveryStatus
    {
        Progress,
        Delivered
    }
}
