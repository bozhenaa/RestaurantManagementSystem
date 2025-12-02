using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using System.Runtime.InteropServices;

namespace RestaurantManagementSystem.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantMSDbContext _context;
        public MenuItemRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }
        public async Task AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }
        public async Task<MenuItem> GetMenuItemById(int id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(mi => mi.Id == id);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }
        public async Task RemoveMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
