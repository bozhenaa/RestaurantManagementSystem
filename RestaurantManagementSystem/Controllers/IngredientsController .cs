using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMenuItemIngredientRepository _menuItemIngredientRepository;

        public IngredientsController(
            IIngredientRepository ingredientRepository,
            IMenuItemIngredientRepository menuItemIngredientRepository)
        {
            _ingredientRepository = ingredientRepository;
            _menuItemIngredientRepository = menuItemIngredientRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepository.GetAll();
            return Ok(ingredients);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(int id)
        {
            var ingredient = await _ingredientRepository.GetById(id);
            if (ingredient == null)
                return NotFound();
            return Ok(ingredient);
        }

        
        [HttpPost("create")]
        public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] CreateIngredientModel dto)
        {
            if (dto == null)
                return BadRequest("Ingredient is null.");

           
            var ingredient = new Ingredient
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                Unit = dto.Unit
            };

            await _ingredientRepository.Add(ingredient);

           
            foreach (var link in dto.MenuItemIngredients)
            {
                var menuItemIngredient = new MenuItemIngredient
                {
                    MenuItemId = link.MenuItemId,
                    IngredientId = ingredient.IngredientId,
                    RequiredQuantity = link.RequiredQuantity
                };

                await _menuItemIngredientRepository.Add(menuItemIngredient);
            }

            return CreatedAtAction(nameof(GetIngredientById), new { id = ingredient.IngredientId }, ingredient);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] CreateIngredientModel dto)
        {
            var ingredient = await _ingredientRepository.GetById(id);
            if (ingredient == null)
                return NotFound();

            
            ingredient.Name = dto.Name;
            ingredient.Quantity = dto.Quantity;
            ingredient.Unit = dto.Unit;
            await _ingredientRepository.Update(ingredient);

            
            var existingLinks = await _menuItemIngredientRepository.GetByIngredientId(id);
            foreach (var link in existingLinks)
            {
                await _menuItemIngredientRepository.Delete(link);
            }

          
            foreach (var link in dto.MenuItemIngredients)
            {
                var menuItemIngredient = new MenuItemIngredient
                {
                    MenuItemId = link.MenuItemId,
                    IngredientId = ingredient.IngredientId,
                    RequiredQuantity = link.RequiredQuantity
                };
                await _menuItemIngredientRepository.Add(menuItemIngredient);
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _ingredientRepository.GetById(id);
            if (ingredient == null)
                return NotFound();

         
            var links = await _menuItemIngredientRepository.GetByIngredientId(id);
            foreach (var link in links)
            {
                await _menuItemIngredientRepository.Delete(link);
            }

            await _ingredientRepository.Delete(ingredient);
            return NoContent();
        }
    }
}
