using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;
//using static OnlineFoodDeliverySystem.Controllers.MenuItemsController;

/*namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        [ApiController]
        [Route("api/menuitems")]
        public class MenuItemController : ControllerBase
        {
            private readonly IMenuItemService _menuItemService;

            public MenuItemController(IMenuItemService menuItemService)
            {
                _menuItemService = menuItemService;
            }

            [HttpPost]
            public async Task<IActionResult> AddMenuItem(MenuItemDto menuItemDto)
            {
                var result = await _menuItemService.AddMenuItem(menuItemDto);
                return result ? Ok("Menu item added successfully") : BadRequest("Failed to add menu item");
            }

            [HttpGet("{restaurantId}")]
            public async Task<IActionResult> GetMenuItems(int restaurantId)
            {
                var menuItems = await _menuItemService.GetMenuItems(restaurantId);
                return Ok(menuItems);
            }
        }

        public class MenuItemService : IMenuItemService
        {
            private readonly AppDbContext _context;

            public MenuItemService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> AddMenuItem(MenuItemDto menuItemDto)
            {
                var menuItem = new MenuItem
                {
                    Name = menuItemDto.Name,
                    Description = menuItemDto.Description,
                    Price = menuItemDto.Price,
                    RestaurantID = menuItemDto.RestaurantID
                };

                _context.MenuItems.Add(menuItem);
                return await _context.SaveChangesAsync() > 0;
            }

            public async Task<IEnumerable<MenuItem>> GetMenuItems(int restaurantId)
            {
                return await _context.MenuItems.Where(m => m.RestaurantID == restaurantId).ToListAsync();
            }
        }

    }

}*/