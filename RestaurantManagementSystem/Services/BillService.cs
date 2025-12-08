using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepo;
        private readonly IMenuItemRepository _menuRepo;

        public BillService(IBillRepository billRepo, IMenuItemRepository menuRepo)
        {
            _billRepo = billRepo;
            _menuRepo = menuRepo;
        }

        public Task<IEnumerable<Bill>> GetAllAsync() => _billRepo.GetAll();
        public Task<Bill?> GetByIdAsync(int id) => _billRepo.GetBillWithItems(id);

        public async Task<Bill> CreateAsync(Bill bill)
        {
            bill.DateTime = DateTime.UtcNow;
            return await _billRepo.Create(bill);
        }

        public Task<bool> UpdateAsync(Bill bill) => _billRepo.Update(bill);
        public Task<bool> DeleteAsync(int id) => _billRepo.Delete(id);

        public async Task<bool> AddMenuItemAsync(int billId, int menuItemId, int quantity)
        {
            var bill = await _billRepo.GetById(billId);
            if (bill == null)
                return false;

            var menuItem = await _menuRepo.GetById(menuItemId);
            if (menuItem == null)
                return false;

            var price = menuItem.PromoPrice ?? menuItem.Price;

            var item = new BillItem
            {
                BillId = billId,
                MenuItemId = menuItemId,
                Quantity = quantity,
                UnitPrice = price
            };

            bill.Amount += price * quantity;
            await _billRepo.Update(bill);

            return await _billRepo.AddBillItem(item);
        }
    }
}
