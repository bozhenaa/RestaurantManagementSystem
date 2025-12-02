using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IRestaurantTableRepository
    {
        Task<RestaurantTable> GetTableById(int id);
        Task<IEnumerable<RestaurantTable>> GetAllTables();
        Task<RestaurantTable> GetTableByNumber(int tableNumber);
        Task<IEnumerable<RestaurantTable>> GetTablesByRoom(RoomName roomName);
        Task AddTable(RestaurantTable table);
        Task UpdateTable(RestaurantTable table);
        Task DeleteTable(RestaurantTable table );
    }
}
