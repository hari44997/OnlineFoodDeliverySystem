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

        public List<MenuItem> GetMenuItems()
        {
            return _context.MenuItems.ToList();
        }

        public int AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            return _context.SaveChanges();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _context.MenuItems.FirstOrDefault(m => m.ItemID == id);
        }

        public int UpdateItemPrice(int id, double newPrice)
        {
            MenuItem MenuItemPriceUpdate = _context.MenuItems.FirstOrDefault(o => o.ItemID==id);
            MenuItemPriceUpdate.Price = newPrice;
            return _context.SaveChanges();
        }
        public int UpdateMenuItem(int id, MenuItem menuItem)
        {
            MenuItem m = _context.MenuItems.FirstOrDefault(p => p.ItemID==id);
            m.ItemID=id;
            m.Name = menuItem.Name;
            m.Description = menuItem.Description;
            m.Price = menuItem.Price;
            return _context.SaveChanges();
        }
        public int DeleteMenuItem(int id)
        {
            var DeleteMenuItem = _context.MenuItems.FirstOrDefault(m =>m.ItemID == id);
            _context.MenuItems.Remove(DeleteMenuItem);
            return _context.SaveChanges();
        }
    }
}
