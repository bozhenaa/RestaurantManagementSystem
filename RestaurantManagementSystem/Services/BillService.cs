using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories;
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

        public Task<IEnumerable<Bill>> GetAllBill() => _billRepo.GetAll();
        public Task<Bill?> GetBillById(int id) => _billRepo.GetBillWithItems(id);

        public async Task<Bill> CreateBill(Bill bill)
        {
            bill.DateTime = DateTime.UtcNow;
            return await _billRepo.CreateBill(bill);
        }

        public Task<bool> UpdateBill(Bill bill) => _billRepo.UpdateBill(bill);
        public Task<bool> DeleteBill(int id) => _billRepo.DeleteBill(id);

        public async Task<bool> AddMenuItem(int billId, int menuItemId, int quantity)
        {
            var bill = await _billRepo.GetBillById(billId);
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
            await _billRepo.UpdateBill(bill);

            return await _billRepo.AddBillItem(item);
        }
        public Task<decimal> GetTotalPayments(DateTime start, DateTime end)
        {
            return _billRepo.GetTotalPayments(start, end);
        }
    }
}
