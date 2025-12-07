using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace RestaurantManagementSystem.Services
{
    public class ReservedTablesService :IReservedTablesService
    {
        private readonly IReservedTablesRepository _reservedTablesRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        public ReservedTablesService(IReservedTablesRepository reservedTablesRepository, IRestaurantTableRepository restaurantTableRepository)
        {
            _reservedTablesRepository = reservedTablesRepository;
            _restaurantTableRepository = restaurantTableRepository;
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
    }
}
