using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly IReservedTablesService _reservedTablesService;
        public ReservationService(IReservationRepository reservationRepository,
            IRestaurantTableRepository restaurantTableRepository, IReservedTablesService reservedTablesService)
        {
            _reservationRepository = reservationRepository;
            _restaurantTableRepository = restaurantTableRepository;
            _reservedTablesService = reservedTablesService;
        }

        public async Task AddReservation(MakeReservationModel reservation)
        {
            var suggestedTables = await _reservedTablesService.GetTableSuggestions(
                reservation.ReservationRoom,
                reservation.GuestNumber,
                reservation.ReservationDate,
                reservation.ReservationTime);

            if (suggestedTables == null)
            {
                throw new InvalidOperationException();
            }
            var newReservation = new Reservation
            {
                ReservationName = reservation.ReservationName,
                ReservationDate = reservation.ReservationDate,
                ReservationType = reservation.ReservationType,
                ReservationTime = reservation.ReservationTime,
                GuestNumber = reservation.GuestNumber,

                ReservedTables = suggestedTables.Select(table => new ReservedTables
                {
                    RestaurantTableId = table.Id
                }).ToList()

            };
            await _reservationRepository.AddReservation(newReservation);
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _reservationRepository.GetAll();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsByDate(DateOnly date)
        {
            return await _reservationRepository.GetAllReservationsByDate(date);
        }

        public async Task<Reservation> GetReservationById(int reservationId)
        {
            return await _reservationRepository.GetById(reservationId);
        }

        public async Task RemoveReservation(Reservation reservation)
        {
            await _reservationRepository.RemoveReservation(reservation);
        }
    }
}
