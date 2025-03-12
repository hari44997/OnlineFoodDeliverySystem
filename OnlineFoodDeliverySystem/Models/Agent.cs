namespace OnlineFoodDeliverySystem.Models
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string? Name { get; set; }
        public int? Rating { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }


    }
}
