using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IReservationService
    {
        Task AddReservation(Reservation reservation);
        Task RemoveReservation (Reservation reservation);
        Task<Reservation> GetReservation (int reservationId);
        Task<IEnumerable<Reservation>> GetAll ();
        Task<IEnumerable<Reservation>> GetAllReservationsByDate (DateOnly date);

    }
}
