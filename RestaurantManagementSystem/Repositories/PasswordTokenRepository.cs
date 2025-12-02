using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class PasswordTokenRepository : IPasswordTokenRepository
    {
        private readonly RestaurantMSDbContext _context;
        public PasswordTokenRepository (RestaurantMSDbContext context)
        {
            _context = context;
        }
        public async Task AddPasswordToken(PasswordToken token)
        {
            _context.PasswordTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordToken> GetPasswordToken(string tokenValue)
        {
            return _context.PasswordTokens.FirstOrDefault(t => t.TokenValue == tokenValue);
        }

        public async Task DeletePasswordToken(PasswordToken token)
        {
            _context.PasswordTokens.Remove(token);
            await _context.SaveChangesAsync();
        }
    }
}
