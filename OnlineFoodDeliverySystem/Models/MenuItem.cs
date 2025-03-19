using System.ComponentModel.DataAnnotations;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class MenuItem
    {
        [Key]
        public int ItemID {  get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public int? RestaruntID {  get; set; }
        public Restaurant? Restaurant{ get; set; }
        public ICollection<OrderItem>?  OrderItems{ get; set; }
    }
}
