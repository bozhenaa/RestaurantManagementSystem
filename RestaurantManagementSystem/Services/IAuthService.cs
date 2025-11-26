using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public interface IAuthService
    {
        Task RegisterUser(RegisterUserDto registerUserDto);
        Task<string> LogInUser(LogInDto signInUserDto);
        Task<string> GetUserToken(User user);
    }
}
