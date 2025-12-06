using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantMSDbContext _context;

        public MenuItemRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task AddMenuItem(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
        }

        public Task UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            return Task.CompletedTask;
        }

        public Task RemoveMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            return Task.CompletedTask;
        }

    
        public async Task<MenuItem?> GetMenuItemWithIngredients(int id)
        {
            return await _context.MenuItems
                .Include(mi => mi.MenuItemIngredients)     
                    .ThenInclude(link => link.Ingredient)  
                .FirstOrDefaultAsync(mi => mi.Id == id);
        }
    }
}
