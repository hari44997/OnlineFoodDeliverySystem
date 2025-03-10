using System.ComponentModel.DataAnnotations;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class MenuItem
    {
        [Key]
        public int ItemID {  get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public double Price { get; set; }
        public int RestaruntID {  get; set; }
        public Restaurant Restaurant{ get; set; }
        public ICollection<OrderItem>  OrderItems{ get; set; }
    }
}
