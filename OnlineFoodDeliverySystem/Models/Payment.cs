using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string PaymentMethod {  get; set; }
        public string Status { get; set; }
        public decimal amount { get; set; }

        public Order Order { get; set; }

    }
}
