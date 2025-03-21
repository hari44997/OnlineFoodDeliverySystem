using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;
using OnlineFoodDeliverySystem.Exceptions;
namespace OnlineFoodDeliverySystem.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            var rest = await _restaurantRepository.GetRestaurantByIdAsync(restaurant.RestaurantID);
            if (rest != null)
            {
                throw new NotFoundException($"Restaurant with id {restaurant.RestaurantID} already exists");

            }
            await _restaurantRepository.AddRestaurantAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var rest = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            if (rest == null)
            {
                throw new NotFoundException($"Restaurant with id {restaurantId} not found");
            }
            await _restaurantRepository.DeleteRestaurantAsync(restaurantId);
        }

        public  List<Restaurant> GetAllRestaurantsAsync()
        {
            var rest =  _restaurantRepository.GetallRestaurantsAsync();
            return rest;

        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            Restaurant rest = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            if (rest == null)
            {
                throw new NotFoundException($"Restaurant with id {restaurantId} not found");

            }
            return rest;
        }


        public async Task UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var rest = await _restaurantRepository.GetRestaurantByIdAsync(id);
            if (rest == null)
            {
                throw new NotFoundException($"Restaurant with id {id} not found");
            }
            await _restaurantRepository.UpdateRestaurantAsync(id, restaurant);

        }
    }
}
