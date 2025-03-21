using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Services;

namespace OnlineFoodDeliverySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem([FromBody] MenuItem menuItem)
        {
            await _menuItemService.AddMenuItemAsync(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItem.ItemID }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
        {
            //if (id != menuItem.ItemID)
            //{
            //    return BadRequest();
            //}
            await _menuItemService.UpdateMenuItemAsync(id, menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItemAsync(id);
            return NoContent();
        }
    }
}