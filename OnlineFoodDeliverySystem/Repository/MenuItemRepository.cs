using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly FoodDbContext _context;

        public MenuItemRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int itemId)
        {
            return await _context.MenuItems.FindAsync(itemId);
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(int id, MenuItem menuItem)
        {
            var menuItemToUpdate = await _context.MenuItems.FindAsync(id);
            if (menuItemToUpdate != null)
            {
                menuItemToUpdate.Name = menuItem.Name;
                menuItemToUpdate.Description = menuItem.Description;
                menuItemToUpdate.Price = menuItem.Price;
                menuItemToUpdate.RestaurantID = menuItem.RestaurantID;
                _context.MenuItems.Update(menuItemToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            var menuItemToDelete = await _context.MenuItems.FindAsync(itemId);
            if (menuItemToDelete != null)
            {
                _context.MenuItems.Remove(menuItemToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}