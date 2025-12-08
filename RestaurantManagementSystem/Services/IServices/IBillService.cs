using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetAllAsync();
        Task<Bill?> GetByIdAsync(int id);
        Task<Bill> CreateAsync(Bill bill);
        Task<bool> UpdateAsync(Bill bill);
        Task<bool> DeleteAsync(int id);
        Task<bool> AddMenuItemAsync(int billId, int menuItemId, int quantity);
    }
}
