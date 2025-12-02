using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu?> GetMenuById(int id);
        Task AddMenu(Menu menu);
        Task UpdateMenu(Menu menu);
        Task DeleteMenu(Menu menu);
        Task SaveChangesAsync();
    }
}
