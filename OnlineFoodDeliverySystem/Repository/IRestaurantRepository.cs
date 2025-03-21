using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetallRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int restaurantId);
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(int id, Restaurant restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
    }
}
