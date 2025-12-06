using RestaurantManagementSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient?> GetById(int id);
        Task<IEnumerable<Ingredient>> GetAll();
        Task Add(Ingredient ingredient);
        Task Update(Ingredient ingredient);
        Task Delete(Ingredient ingredient);
    }
}
