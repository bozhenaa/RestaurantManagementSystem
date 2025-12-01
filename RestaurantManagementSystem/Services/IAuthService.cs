using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;

namespace RestaurantManagementSystem.Services
{
    public interface IAuthService
    {
        Task RegisterUser(RegisterUserModel registerUserDto);
        Task<string> LogInUser(LogInModel signInUserDto);
        Task<string> GetUserToken(User user);
    }
}
