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
            var rest = _context.Restaurants.Find(restaurantId);
            if (rest != null)
            {
                _context.Restaurants.Remove(rest);
                await _context.SaveChangesAsync();
            }            

        }

        public async Task<IEnumerable<Restaurant>> GetallRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var rest = _context.Restaurants.Find(id);
            rest.RestaurantName = restaurant.RestaurantName;
            rest.Rating = restaurant.Rating;
            _context.Restaurants.Update(rest);
            await _context.SaveChangesAsync();
        }
    }
}
