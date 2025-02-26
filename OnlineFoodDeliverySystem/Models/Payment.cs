using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string PaymentMethod {  get; set; }
        public string status { get; set; }
        public decimal amount { get; set; }

        public ICollection<Order>Orders { get; set; }
        public ICollection<MenuItem> MenuItems { get;set; }


    }
}
