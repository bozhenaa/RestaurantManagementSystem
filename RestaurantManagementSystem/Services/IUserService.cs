using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsername (string username);
        Task<User> GetUserByEmail (string email);

        Task CreateUser(User user);
        Task DeleteUser(User user);
        Task UpdateUser(User user);
    }
}
