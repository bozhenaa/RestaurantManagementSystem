using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IReservedTablesService
    {        
        Task<IEnumerable<RestaurantTable>> GetAllFreeTables(DateOnly date, TimeOnly time);
        Task<bool> IsTableAvailable(RestaurantTable table, DateOnly desiredDate, TimeOnly desiredTime);
        bool OverlapingReservations(TimeOnly resTime, TimeOnly desiredTime);
        Task<IEnumerable<RestaurantTable>> TableSuggestions(RoomName roomName, int seats, DateOnly date, TimeOnly time);
        Task<IEnumerable<RestaurantTable>> GetFreeTablesFromList(IEnumerable<RestaurantTable> tables,
            DateOnly date, TimeOnly time);
    }
}
