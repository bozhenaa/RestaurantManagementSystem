using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public interface IRestaurantTableService
    {
        Task<RestaurantTable> GetTableById(int id);
        Task<IEnumerable<RestaurantTable>> GetAllTables();
        Task<RestaurantTable> GetTableByNumber(int tableNumber);
        Task<IEnumerable<RestaurantTable>> GetTablesByRoom(RoomName roomName);
        Task AddTable(AddRestaurantTableDto table);
        Task UpdateTable(AddRestaurantTableDto table);
        Task DeleteTable(RestaurantTable table );
    }
}
