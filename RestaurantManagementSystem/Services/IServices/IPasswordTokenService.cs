using System.Runtime.CompilerServices;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IPasswordTokenService
    {
        Task<string> GeneratePasswordToken(string email);
        Task<string> GeneratePasswordLink(string email);
    }
}
