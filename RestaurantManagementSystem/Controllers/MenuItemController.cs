using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController :ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet("get-all-menu-items")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllMenuItems()
        {
            try
            {
                var menuItems = await _menuItemService.GetAllMenuItems();
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-menu-item-by-id")]
        [AllowAnonymous]
        public async Task<ActionResult> GetMenuItemById([FromQuery] int id)
        {
            try
            {
                var menuItem = await _menuItemService.GetMenuItemById(id);
                return Ok(menuItem);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-menu-item")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> AddMenuItem([FromBody] AddMenuItemModel menuItem)
        {
            try
            {
                await _menuItemService.AddMenuItem(menuItem);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-menu-item")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> UpdateMenuItem([FromBody]MenuItem menuItem)
        {
            try
            {
                await _menuItemService.UpdateMenuItem(menuItem);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-menu-item")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteMenuItem([FromBody] MenuItem menuItem)
        {
            try
            {
                await _menuItemService.DeleteMenuItem(menuItem);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
