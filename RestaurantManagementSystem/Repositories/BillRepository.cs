using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly RestaurantMSDbContext _context;

        public BillRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetAll()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill?> GetBillById(int id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task<Bill?> GetBillWithItems(int id)
        {
            return await _context.Bills
                .Include(b => b.BillItems)
                .ThenInclude(i => i.MenuItem)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<bool> UpdateBill(Bill bill)
        {
            _context.Bills.Update(bill);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
                return false;

            _context.Bills.Remove(bill);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddBillItem(BillItem item)
        {
            _context.BillItems.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
