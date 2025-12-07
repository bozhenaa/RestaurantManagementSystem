using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IReservedTablesService
    {
        Task<IEnumerable<RestaurantTable>> GetAllFreeTables(DateOnly date, TimeOnly time);
        bool OverlapingReservations(TimeOnly resTime, TimeOnly desiredTime);
    }
}
