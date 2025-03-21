using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineFoodDeliverySystem.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }

        [Required]
        [StringLength(100)]
        public string? RestaurantName { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public ICollection<MenuItem>? MenuItems { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}
