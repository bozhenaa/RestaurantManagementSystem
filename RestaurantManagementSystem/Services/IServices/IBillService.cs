using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetAllBill();
        Task<Bill?> GetBillById(int id);
        Task<Bill> CreateBill(Bill bill);
        Task<bool> UpdateBill(Bill bill);
        Task<bool> DeleteBill(int id);
        Task<bool> AddMenuItem(int billId, int menuItemId, int quantity);
        Task<decimal> GetTotalPayments(DateTime start, DateTime end);
    }
}
