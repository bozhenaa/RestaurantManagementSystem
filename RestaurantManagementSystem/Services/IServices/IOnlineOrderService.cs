using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IOnlineOrderService
    {
        Task CreateOrder(int userId, CreateOnlineOrderModel order);
        Task<OnlineOrder?> GetOrderById(int id);
        Task<IEnumerable<OnlineOrder>> GetAllOrders();
        Task<IEnumerable<OnlineOrder>> GetOrdersByCustomerId(int customerId);
        Task UpdateOrder(OnlineOrder order);

        Task UpdateOrderStatus(int orderId, OnlineOrderStatus status);
    }
}
