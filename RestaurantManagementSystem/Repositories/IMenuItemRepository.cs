using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Repositories
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task AddMenuItem(MenuItem menuItem);
        Task RemoveMenuItem(MenuItem menuItem);
        Task UpdateMenuItem (MenuItem menuItem); 
    }
}
