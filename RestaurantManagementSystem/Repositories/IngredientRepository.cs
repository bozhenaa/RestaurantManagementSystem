using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RestaurantMSDbContext _context;

        public IngredientRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient?> GetById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.IngredientId == id);
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task Add(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
