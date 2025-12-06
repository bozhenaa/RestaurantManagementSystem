using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> GetMenuItemById(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItems();
        Task AddMenuItem(MenuItem menuItem);
        Task RemoveMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);

        
        Task<MenuItem?> GetMenuItemWithIngredients(int id);
    }
}
