using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;

namespace RestaurantManagementSystem.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsername (string username);
        Task<User> GetUserByEmail (string email);

        Task CreateUser(User user);
        Task DeleteUser(int userId);
        Task UpdateUser(UpdateUserInfoModel user);
    }
}
