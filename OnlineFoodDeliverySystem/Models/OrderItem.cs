﻿using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        public int? OrderID { get; set; }

        public int? ItemID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int? Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal? Price { get; set; }

        // Navigation Properties
        public Order? Order { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
