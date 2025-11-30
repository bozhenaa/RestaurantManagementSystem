using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Repositories
{
    public class RestaurantTableRepository : IRestaurantTableRepository
    {
        private readonly RestaurantMSDbContext _context;
        public RestaurantTableRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RestaurantTable>> GetAllTables()
        {
            return await _context.RestaurantTables.ToListAsync();
        }

        public async Task<RestaurantTable> GetTableById(int id)
        {
            return await _context.RestaurantTables.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<RestaurantTable> GetTableByNumber(int tableNumber)
        {
            return await _context.RestaurantTables.FirstOrDefaultAsync(t => t.TableNumber == tableNumber);
        }
        
        public async Task<IEnumerable<RestaurantTable>> GetTablesByRoom(RoomName roomName)
        {
            return await _context.RestaurantTables.Where(t => t.RoomName == roomName).ToListAsync();
        }

        public async Task AddTable(RestaurantTable table)
        {
            _context.RestaurantTables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTable(RestaurantTable table)
        {
            _context.RestaurantTables.Remove(table);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTable(RestaurantTable table)
        {
            _context.RestaurantTables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
