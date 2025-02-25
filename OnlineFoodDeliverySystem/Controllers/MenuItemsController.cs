using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly MenuItemDbContext _context;
        public MenuItemsController(MenuItemDbContext context) 
        {
            this._context = context;
        }
        [HttpPost]
        public void AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        [HttpPut]
        public MenuItem UpdateMenuItem(int id, string name)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(x => x.ItemId==id);
            if (menuItem != null)
            {
                menuItem.Name = name;
                _context.SaveChanges();
            }
            return menuItem;
        }
        [HttpDelete]
          
            public MenuItem RemoveMenuItem(string name)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(x => x.Name == name);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                _context.SaveChanges();
            }
            return menuItem;
        }
    }
            
}