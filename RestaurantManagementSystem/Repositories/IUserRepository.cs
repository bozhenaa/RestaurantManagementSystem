using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsernameOrEmail(string usernameOrEmail);

        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);

    }
}
