using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories
{
    public interface IPasswordTokenRepository
    {
        Task<PasswordToken> GetPasswordToken (string tokenValue);
        Task AddPasswordToken(PasswordToken passwordToken);
        Task DeletePasswordToken(PasswordToken passwordToken);

    }
}
