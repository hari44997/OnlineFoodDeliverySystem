using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodDbContext _context;

        public RestaurantRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurantToDelete = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurantToDelete != null)
            {
                _context.Restaurants.Remove(restaurantToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public List<Restaurant> GetallRestaurantsAsync()
        {
            var restaurants = _context.Restaurants.ToList();
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var restaurantToUpdate = await _context.Restaurants.FindAsync(id);
            if (restaurantToUpdate != null)
            {
                restaurantToUpdate.RestaurantName = restaurant.RestaurantName;
                restaurantToUpdate.Rating = restaurant.Rating;
                _context.Restaurants.Update(restaurantToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}