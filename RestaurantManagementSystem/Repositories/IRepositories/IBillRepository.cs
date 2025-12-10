using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAll();
        Task<Bill?> GetBillById(int id);
        Task<Bill> CreateBill(Bill bill);
        Task<bool> UpdateBill(Bill bill);
        Task<bool> DeleteBill(int id);

        Task<bool> AddBillItem(BillItem item);
        Task<Bill?> GetBillWithItems(int id);
        Task<decimal> GetTotalPayments(DateTime start, DateTime end);
    }
}
