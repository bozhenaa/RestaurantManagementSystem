using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services.IServices
{
    public interface IReservationService
    {
        Task AddReservation(MakeReservationModel reservation);
        Task RemoveReservation (Reservation reservation);
        Task<Reservation> GetReservationById (int reservationId);
        Task<IEnumerable<Reservation>> GetAll ();
        Task<IEnumerable<Reservation>> GetAllReservationsByDate (DateOnly date);

    }
}
