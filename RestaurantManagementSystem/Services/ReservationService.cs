using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        public ReservationService(IReservationRepository reservationRepository, IRestaurantTableRepository restaurantTableRepository)
        {
            _reservationRepository = reservationRepository;
            _restaurantTableRepository = restaurantTableRepository;
        }

        public async Task AddReservation(Reservation reservation)
        {
            await _reservationRepository.AddReservation(reservation); 
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _reservationRepository.GetAll();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsByDate(DateOnly date)
        {
            return await _reservationRepository.GetAllReservationsByDate(date);
        }

        public async Task<Reservation> GetReservation(int reservationId)
        {
            return await _reservationRepository.GetById(reservationId);
        }

        public async Task RemoveReservation(Reservation reservation)
        {
            await _reservationRepository.RemoveReservation(reservation);
        }
    }
}
