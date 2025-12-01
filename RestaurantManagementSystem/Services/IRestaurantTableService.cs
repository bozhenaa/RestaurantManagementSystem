using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Services
{
    public interface IRestaurantTableService
    {
        Task<RestaurantTable> GetTableById(int id);
        Task<IEnumerable<RestaurantTable>> GetAllTables();
        Task<RestaurantTable> GetTableByNumber(int tableNumber);
        Task<IEnumerable<RestaurantTable>> GetTablesByRoom(RoomName roomName);
        Task AddTable(AddRestaurantTableModel table);
        Task UpdateTable(AddRestaurantTableModel table);
        Task DeleteTable(RestaurantTable table );
    }
}
