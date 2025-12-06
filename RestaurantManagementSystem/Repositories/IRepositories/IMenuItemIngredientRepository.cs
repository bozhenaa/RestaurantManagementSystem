using RestaurantManagementSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IMenuItemIngredientRepository
    {
        Task Add(MenuItemIngredient menuItemIngredient);
        Task Delete(MenuItemIngredient menuItemIngredient);
        Task<IEnumerable<MenuItemIngredient>> GetByIngredientId(int ingredientId);
        Task<IEnumerable<MenuItemIngredient>> GetByMenuItemId(int menuItemId);
    }
}
