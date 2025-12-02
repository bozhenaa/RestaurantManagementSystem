using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IOnlineOrderRepository
    {
        Task AddOrder(OnlineOrder order);
        Task<OnlineOrder?> GetOrderById(int id);
        Task<IEnumerable<OnlineOrder>> GetAllOrders();
        Task<IEnumerable<OnlineOrder>> GetOrdersByCustomerId(int customerId);
        Task UpdateOrder(OnlineOrder order);
    }
}
