using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IMenuItemService
    {
        Task AddMenuItem(AddMenuItemModel menuItem);
        Task DeleteMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task AddPromoPrice(MenuItem menuItem, decimal newPrice);
        Task RemovePromoPrice(MenuItem menuItem);

    }
}
