using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int? OrderID { get; set; }
        public PaymentMethod PaymentMethod {  get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Initiated;

        [DataType(DataType.Currency)]
        public decimal? amount { get; set; }

        public Order? Order { get; set; }

    }
    public enum PaymentStatus
    {
        Initiated,
        Failed,
        Successful
    }

    public enum PaymentMethod
    {
        Card,
        Wallet,
        UPI
    }
}
