using System.Runtime.CompilerServices;

namespace RestaurantManagementSystem.Services
{
    public interface IPasswordTokenServices
    {
        Task<string> GeneratePasswordToken(string email);
        Task<string> GeneratePasswordLink(string email);
    }
}
