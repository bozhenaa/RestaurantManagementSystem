using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Repositories
{
    public class MenuItemIngredientRepository : IMenuItemIngredientRepository
    {
        private readonly RestaurantMSDbContext _context;

        public MenuItemIngredientRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task Add(MenuItemIngredient menuItemIngredient)
        {
            await _context.MenuItemIngredients.AddAsync(menuItemIngredient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MenuItemIngredient menuItemIngredient)
        {
            _context.MenuItemIngredients.Remove(menuItemIngredient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItemIngredient>> GetByIngredientId(int ingredientId)
        {
            return await _context.MenuItemIngredients
                .Include(mii => mii.MenuItem)
                .Where(mii => mii.IngredientId == ingredientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItemIngredient>> GetByMenuItemId(int menuItemId)
        {
            return await _context.MenuItemIngredients
                .Include(mii => mii.Ingredient)
                .Where(mii => mii.MenuItemId == menuItemId)
                .ToListAsync();
        }
    }
}
