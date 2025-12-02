using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task<Menu> CreateMenu(string name);
        Task AddDishToMenu(int menuId, int dishId);
        Task RemoveDishFromMenu(int menuId, int dishId);
        Task DeleteMenu(int menuId);
    }
}
