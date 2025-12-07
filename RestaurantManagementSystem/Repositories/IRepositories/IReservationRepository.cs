using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Repositories.IRepositories
{
    public interface IReservationRepository
    {
        Task AddReservation(Reservation reservation);
        Task RemoveReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAll();

        Task<Reservation> GetById(int id);

        Task<IEnumerable<Reservation>> GetAllReservationsByDate(DateOnly date);
    }
}
