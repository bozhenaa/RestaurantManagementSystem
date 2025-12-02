using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class OnlineOrderRepository : IOnlineOrderRepository
    {
        private readonly RestaurantMSDbContext _context;
        public OnlineOrderRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }
        public async  Task AddOrder(OnlineOrder order)
        {
            _context.OnlineOrders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OnlineOrder>> GetAllOrders()
        {
            return await _context.OnlineOrders
                .Include(o=>o.OrderItems)
                .ThenInclude(o=> o.MenuItem)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<OnlineOrder>> GetOrdersByCustomerId(int userId)
        {
            return await _context.OnlineOrders
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.MenuItem)
                 .Where(o => o.UserId == userId)
                 .OrderByDescending(o => o.OrderDate)
                 .ToListAsync();
        }

        public async Task UpdateOrder(OnlineOrder order)
        {
            _context.OnlineOrders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
