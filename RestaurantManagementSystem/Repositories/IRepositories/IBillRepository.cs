using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAll();
        Task<Bill?> GetById(int id);
        Task<Bill> Create(Bill bill);
        Task<bool> Update(Bill bill);
        Task<bool> Delete(int id);

        Task<bool> AddBillItem(BillItem item);
        Task<Bill?> GetBillWithItems(int id);
    }
}
