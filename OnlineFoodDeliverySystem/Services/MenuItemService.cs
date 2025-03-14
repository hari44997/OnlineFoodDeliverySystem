using OnlineFoodDeliverySystem.Repository;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Services;
using OnlineFoodDeliverySystem.Exceptions;

namespace OnlineFoodDeliverySystem.Services
{
    public class MenuItemService:IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            
            var Menuitems = await _menuItemRepository.GetAllMenuItemsAsync();
            return Menuitems.ToList();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int itemId)
        {
            MenuItem menuItem = await _menuItemRepository.GetMenuItemByIdAsync(itemId);
            if(menuItem == null)
            {
                throw new NotFoundException($"MenuItem with id {itemId} does not exists");
            }
            return menuItem;
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            var Additem = await _menuItemRepository.GetMenuItemByIdAsync(menuItem.ItemID);
            if(menuItem != null)
            {
                throw new AlreadyExistsException($"MenuItem with id {menuItem.ItemID} already exists");
            }
            await _menuItemRepository.AddMenuItemAsync(menuItem);

        }

        public async Task UpdateMenuItemAsync(int id, MenuItem menuItem)
        {
            var UpdateItem = await _menuItemRepository.GetMenuItemByIdAsync(id);
            if(UpdateItem == null)
            {
                throw new NotFoundException($"MenuItem with id {menuItem.ItemID} does not exists");
            }
            await _menuItemRepository.UpdateMenuItemAsync(id, menuItem);
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            var deleteItem = await _menuItemRepository.GetMenuItemByIdAsync(itemId);
            if(deleteItem == null)
            {
                throw new NotFoundException($"MenuItem with id {itemId} does not exists");
            }
            await _menuItemRepository.DeleteMenuItemAsync(itemId);
        }
    }
}
