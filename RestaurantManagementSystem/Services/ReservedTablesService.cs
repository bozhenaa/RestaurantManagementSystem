using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;
using System.ComponentModel;

namespace RestaurantManagementSystem.Services
{
    public class ReservedTablesService : IReservedTablesService
    {
        private readonly IReservedTablesRepository _reservedTablesRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly IReservationRepository _reservationRepository;
        public ReservedTablesService(IReservedTablesRepository reservedTablesRepository, 
            IRestaurantTableRepository restaurantTableRepository, IReservationRepository reservationRepository)
        {
            _reservedTablesRepository = reservedTablesRepository;
            _restaurantTableRepository = restaurantTableRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<RestaurantTable>> GetAllFreeTables(DateOnly date, TimeOnly time)
        {
            var allTables = await _restaurantTableRepository.GetAllTables();
            var busyTablesToday = await _reservedTablesRepository.GetReservedTablesByDate(date);

            var busyTables = busyTablesToday
                .Where(rt => OverlapingReservations(rt.Reservation.ReservationTime, time))
                .Select(rt => rt.RestaurantTableId)
                .Distinct()
                .ToList();

            var freeTables = allTables
                .Where(table => !busyTables.Contains(table.Id))
                .ToList();

            return freeTables;
        }

        public async Task<bool> IsTableAvailable(RestaurantTable table, DateOnly desiredDate, TimeOnly desiredTime)
        {
            bool available = false;
            var allReservations = await _reservationRepository.GetAllReservationsByDate(desiredDate);
            var notAvailable = allReservations.Where(r=> OverlapingReservations(r.ReservationTime, desiredTime)).ToList();
            bool isBusy = notAvailable.Any(t => t.ReservedTables.Any(t=>t.RestaurantTableId == table.Id));    
            return !isBusy;
        }
        public bool OverlapingReservations(TimeOnly resTime, TimeOnly desiredTime)
        {
            TimeOnly startTime = desiredTime.AddHours(-3);
            TimeOnly endTime = desiredTime.AddHours(3);
            if (startTime < endTime)
            {
                return resTime >= startTime && resTime <= endTime;
            }
            else
            {
                return resTime >= startTime || resTime <= endTime;
            }
        }

        public async Task<IEnumerable<RestaurantTable>> TableSuggestions(RoomName roomName, int seats, DateOnly date, TimeOnly time)
        {
            var freeTables = await GetAllFreeTables(date, time);

            var roomFreeTables = freeTables.Where(t=>t.RoomName == roomName).ToList();

            var match = roomFreeTables
            .Where(t => t.Seats >= seats)
            .OrderBy(t => t.Seats)
            .FirstOrDefault();
            if (match != null)
            {
                return new List<RestaurantTable> { match };
            }
            var selectedTables = new List<RestaurantTable>();
            int currentSeats = 0;
            var sortedTables = freeTables.OrderByDescending(t => t.Seats);

            foreach (var table in sortedTables)
            {
                selectedTables.Add(table);
                currentSeats += table.Seats;
                if (currentSeats >= seats)
                {
                    return selectedTables;

                }
            }
            return Enumerable.Empty<RestaurantTable>();
        }

        public async Task<IEnumerable<RestaurantTable>> GetFreeTablesFromList(IEnumerable<RestaurantTable> tables,
            DateOnly date, TimeOnly time)
        {
            var busyTables = await _reservedTablesRepository.GetReservedTablesByDate(date);
            var busyTablesHours = busyTables
                .Where(rt=> OverlapingReservations(rt.Reservation.ReservationTime, time))
                .Select(rt => rt.RestaurantTableId)
                .Distinct()
                .ToList();

            var freeTables = tables
                .Where(t => !busyTablesHours.Contains(t.Id)).ToList();
            return freeTables;
         }
    }
}
