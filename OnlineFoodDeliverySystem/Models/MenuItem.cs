using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem
{
    public class MenuItem
    {
        [Key]
        public int ItemID {  get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public int Price { get; set; }
        public int RestaruntID {  get; set; }
        public Order Order { get; set; }
    }
}
