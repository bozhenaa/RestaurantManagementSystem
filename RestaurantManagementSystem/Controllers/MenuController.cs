using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            return Ok(await _menuService.GetAllMenus());
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu(int id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMenu([FromBody] string name)
        {
            var newMenu = await _menuService.CreateMenu(name);
            return Ok(newMenu);
        }

        
        [HttpPost("{menuId}/add-dish/{dishId}")]
        public async Task<IActionResult> AddDishToMenu(int menuId, int dishId)
        {
            await _menuService.AddDishToMenu(menuId, dishId);
            return Ok();
        }

       
        [HttpDelete("{menuId}/remove-dish/{dishId}")]
        public async Task<IActionResult> RemoveDish(int menuId, int dishId)
        {
            await _menuService.RemoveDishFromMenu(menuId, dishId);
            return Ok();
        }

        
        [HttpDelete("{menuId}")]
        public async Task<IActionResult> DeleteMenu(int menuId)
        {
            await _menuService.DeleteMenu(menuId);
            return Ok();
        }
    }
}
