using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class MenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllMenuItemsAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int itemId)
        {
            return await _menuItemRepository.GetMenuItemByIdAsync(itemId);
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.AddMenuItemAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.UpdateMenuItemAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            await _menuItemRepository.DeleteMenuItemAsync(itemId);
        }
    }
}
