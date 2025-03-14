using OnlineFoodDeliverySystem.Models;
namespace OnlineFoodDeliverySystem.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int restaurantId);
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(int id, Restaurant restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
    }
}
