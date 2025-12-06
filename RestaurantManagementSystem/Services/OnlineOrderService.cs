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
        private readonly IIngredientRepository _ingredientRepository;

        public OnlineOrderService(
            IOnlineOrderRepository orderRepository,
            IMenuItemService menuItemService,
            IIngredientRepository ingredientRepository)
        {
            _orderRepository = orderRepository;
            _menuItemService = menuItemService;
            _ingredientRepository = ingredientRepository;
        }

        public async Task CreateOrder(int userId, CreateOnlineOrderModel order)
        {
            
            await DeductIngredientsForOrder(order);

            var orderItemsList = new List<OrderItem>();
            decimal totalAmount = 0;

            foreach (var item in order.Items)
            {
                var price = await _menuItemService.GetPrice(item.MenuItemId);
                totalAmount += price * item.Quantity;

                orderItemsList.Add(new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity,
                    PriceAtTimeOfOrder = price
                };
                orderItemsList.Add(orderItemEntity);
                
            }

            var newOrder = new OnlineOrder
            {
                UserId = userId,
                CustomerName = order.CustomerName,
                CustomerPhone = order.PhoneNumber,
                DeliveryAddress = order.DeliveryAddress,
                OrderDate = DateTime.UtcNow,
                Status = OnlineOrderStatus.Pending,
                OrderItems = orderItemsList,
                TotalAmount = totalAmount
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
            return await _orderRepository.GetOrdersByCustomerId(customerId);
        }

        public async Task UpdateOrder(OnlineOrder order)
        {
            await _orderRepository.UpdateOrder(order);
        }

        public async Task UpdateOrderStatus(int orderId, OnlineOrderStatus status)
        {
            var onlineOrder = await GetOrderById(orderId);
            if (onlineOrder == null)
            {
                throw new KeyNotFoundException();
            }
            onlineOrder.Status = status;
            await UpdateOrder(onlineOrder);
        }

        public async Task DeductIngredientsForOrder(CreateOnlineOrderModel order)
        {
            foreach (var item in order.Items)
            {
                var menuItem = await _menuItemService.GetMenuItemWithIngredients(item.MenuItemId);

                if (menuItem == null)
                    throw new Exception("MenuItem not found");

                foreach (var ingredientLink in menuItem.MenuItemIngredients)
                {
                    var ingredient = ingredientLink.Ingredient;

                    decimal required = ingredientLink.RequiredQuantity * item.Quantity;

                    if (ingredient.Quantity < required)
                    {
                        throw new Exception(
                            $"{ingredient.Name} is out of stock. Needed {required}, available {ingredient.Quantity}");
                    }

                    ingredient.Quantity -= required;

                    await _ingredientRepository.Update(ingredient);
                }
            }
        }

        public async Task<OnlineOrderStatus> GetOrderStatusByOrderId(int id)
        {
            var onlineOrder = await GetOrderById(id);
            if (onlineOrder == null)
            {
                throw new KeyNotFoundException();
            }
            return onlineOrder.Status;
        }

        public async Task CancelOrder(int orderId)
        {
            var currentState = await GetOrderStatusByOrderId(orderId);
            if(currentState == OnlineOrderStatus.Pending)
            {
                var order = await GetOrderById(orderId);
                order.Status = OnlineOrderStatus.Cancelled;
                await _orderRepository.UpdateOrder(order);
            }
            else
            {
                throw new InvalidOperationException("Only pending orders can be cancelled.");
            }
        }

        public async Task OutForDelivery(int orderId)
        {
            var order = await GetOrderById(orderId);
            order.Status = OnlineOrderStatus.OutForDelivery;
            await _orderRepository.UpdateOrder(order);
        }
    }
}
