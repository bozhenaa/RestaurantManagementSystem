using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsernameOrEmail(string usernameOrEmail);
        Task<User> GetUserById(int userId);

        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);

    }
}
