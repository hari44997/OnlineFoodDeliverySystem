using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int itemId);
        Task AddMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(int id, MenuItem menuItem);
        Task DeleteMenuItemAsync(int itemId);
    }
}
