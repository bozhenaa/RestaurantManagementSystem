using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Services
{
    public class OnlineOrderService : IOnlineOrderService
    {
        private readonly IOnlineOrderRepository _orderRepository;
        private readonly IMenuItemService _menuItemService;
        public OnlineOrderService(IOnlineOrderRepository orderRepository, IMenuItemService menuItemService)
        {
            _orderRepository = orderRepository;
            _menuItemService = menuItemService;
        }
        public async Task CreateOrder(int userId, CreateOnlineOrderModel order)
        {
            var orderItemsList = new List<OrderItem>();
            decimal price = 0;
            foreach (var orderItem in order.Items)
            {
                price = await _menuItemService.GetPrice(orderItem.MenuItemId);
                var orderItemEntity = new OrderItem
                {
                    MenuItemId = orderItem.MenuItemId,
                    Quantity = orderItem.Quantity,
                    PriceAtTimeOfOrder = price
                };
                orderItemsList.Add(orderItemEntity);
            }
            var newOrder = new OnlineOrder
            {
                UserId = userId,
                DeliveryAddress = order.DeliveryAddress,
                OrderDate = DateTime.UtcNow,
                Status = OnlineOrderStatus.Pending,
                OrderItems = orderItemsList
            };
            await _orderRepository.AddOrder(newOrder);
        }

        public async Task<IEnumerable<OnlineOrder>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<OnlineOrder?> GetOrderById(int id)
        {
            var onlineOrder = await _orderRepository.GetOrderById(id);
            if (onlineOrder == null)
            {
                throw new ArgumentNullException();
            }
            return onlineOrder;
        }

        public async Task<IEnumerable<OnlineOrder>> GetOrdersByCustomerId(int customerId)
        {
            var onlineOrder = await GetOrdersByCustomerId(customerId);
            if (onlineOrder == null)
            {
                throw new ArgumentNullException();
            }
            return  onlineOrder;
        }

        public async Task UpdateOrder(OnlineOrder order)
        {
           await _orderRepository.UpdateOrder(order);
        }
    }
}
