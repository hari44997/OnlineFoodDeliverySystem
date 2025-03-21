using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Services
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int itemId);
        Task AddMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(int id, MenuItem menuItem);
        Task DeleteMenuItemAsync(int itemId);
    }
}
