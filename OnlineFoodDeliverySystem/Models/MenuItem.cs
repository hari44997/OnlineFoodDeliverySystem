using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem
{
    public class MenuItem
    {
        [Key]
        public int ItemId {  get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public int Price { get; set; }
        //public int RestaruntId() { }
    }
}
