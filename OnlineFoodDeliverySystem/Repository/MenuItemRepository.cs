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
            MenuItem MenuItemPriceUpdate = _context.MenuItems.FirstOrDefault(m =>  m.ItemID == id);
            if(MenuItemPriceUpdate != null)
            {
                MenuItemPriceUpdate.Price = newPrice;
                return _context.SaveChanges();
            }
            return _context.SaveChanges();
        }

        public int DeleteMenuItem(int id)
        {
            var DeleteMenuItem = _context.MenuItems.FirstOrDefault(m =>m.ItemID == id);
            if(DeleteMenuItem != null)
            {
                _context.MenuItems.Remove(DeleteMenuItem);
                return _context.SaveChanges();
            }
            return _context.SaveChanges();
        }
    }
}
