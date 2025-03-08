using System.ComponentModel.DataAnnotations;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string? Status { get; set; }
        public double TotalAmount { get; set; }





        public Customer Customer { get; set; }
        //public int ItemID {  get; set; }
        public Payment Payment { get; set; }
        public Restaurant Restaurant { get; set; }
        //public MenuItem MenuItem { get; set; }
        public Delivery Delivery { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        

        


    }
}
