using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;

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
            var items = _context.MenuItems.Find(id);
            items.Name = menuItem.Name;
            items.Description = menuItem.Description;
            items.Price = menuItem.Price;
            _context.MenuItems.Update(items);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(itemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
