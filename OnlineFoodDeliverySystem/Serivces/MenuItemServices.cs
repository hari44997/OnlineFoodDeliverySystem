using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class MenuItemServices:IMenuItemService
    {
        private readonly FoodDbContext _context;

        public MenuItemServices(FoodDbContext context)
        {
            _context = context;
        }

        public int AddMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public int DeleteMenuItem(int id)
        {
            throw new NotImplementedException();
        }

        public MenuItem GetMenuItemById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public int UpdateItemPrice(int id, double newPrice)
        {
            throw new NotImplementedException();
        }

        public int UpdateMenuItem(int id, MenuItem menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
