using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Repositories
{
    public interface IPasswordTokenRepository
    {
        Task<PasswordToken> GetPasswordToken (string tokenValue);
        Task AddPasswordToken(PasswordToken passwordToken);
        Task DeletePasswordToken(PasswordToken passwordToken);

    }
}
