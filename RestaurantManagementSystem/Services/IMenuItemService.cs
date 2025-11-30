using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public interface IMenuItemService
    {
        Task AddMenuItem(AddMenuItemDto menuItem);
        Task DeleteMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task AddPromoPrice(MenuItem menuItem, decimal newPrice);
        Task RemovePromoPrice(MenuItem menuItem);

    }
}
