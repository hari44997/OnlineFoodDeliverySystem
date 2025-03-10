namespace OnlineFoodDeliverySystem.Repository
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetMenuItems();
        int AddMenuItem(MenuItem menuItem);
        MenuItem GetMenuItemById(int id);
        int UpdateItemPrice(int id, double newPrice);
        int DeleteMenuItem(int id);
        int UpdateMenuItem(int id, MenuItem menuItem);
    }
}
