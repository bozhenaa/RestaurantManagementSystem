using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantMSDbContext _context;

        public MenuRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task<Menu?> GetMenuById(int id)
        {
            return await _context.Menus
                .Include(m => m.MenuItems)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _context.Menus
                .Include(m => m.MenuItems)
                .ToListAsync();
        }

        public async Task AddMenu(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }

        public Task UpdateMenu(Menu menu)
        {
            _context.Menus.Update(menu);
            return Task.CompletedTask;
        }

        public Task DeleteMenu(Menu menu)
        {
            _context.Menus.Remove(menu);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
