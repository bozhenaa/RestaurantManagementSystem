using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IReservedTablesRepository
    {
        Task<List<int>> GetTablesForReservation(int reservationId);
        Task<IEnumerable<ReservedTables>> GetAllTablesReservation();
        Task<IEnumerable<ReservedTables>> GetReservedTablesByDate(DateOnly date);
    }
}
