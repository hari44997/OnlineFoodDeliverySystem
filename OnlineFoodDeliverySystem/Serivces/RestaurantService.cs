using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;
using OnlineFoodDeliverySystem.Exceptions;

namespace OnlineFoodDeliverySystem.Services
{
    public class RestaurantService:IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
           await _restaurantRepository.AddRestaurantAsync(restaurant);
        }

        public Task DeleteRestaurantAsync(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants = _restaurantRepository.GetallRestaurantsAsync();
            return restaurants;
        }

        public Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant with id {restaurantId} does not exists");
            }
            return restaurant;
        }

        public async Task UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var restaurantExists = _restaurantRepository.GetRestaurantByIdAsync(id);
            if (restaurantExists == null)
            {
                throw new NotFoundException($"Restaurant with id {restaurant.RestaurantID} does not exists");
            }
            await _restaurantRepository.UpdateRestaurantAsync(id, restaurant);
        }
    }
}
