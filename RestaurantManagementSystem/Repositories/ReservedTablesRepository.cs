using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace RestaurantManagementSystem.Repositories
{
    public class ReservedTablesRepository : IReservedTablesRepository
    {
        private readonly RestaurantMSDbContext _context;
        public ReservedTablesRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservedTables>> GetAllTablesReservation()
        {
            return await _context.ReservedTables.ToListAsync();
        }

        public async Task<List<int>> GetTablesForReservation(int reservationId)
        {
            return await _context.ReservedTables
                 .Where(rt => rt.ReservationId == reservationId)
                 .Select(rt => rt.RestaurantTableId)
                 .ToListAsync();
        }

        public async Task<IEnumerable<ReservedTables>> GetReservedTablesByDate(DateOnly date)
        {
            return await _context.ReservedTables
                .Include(rt=>rt.Reservation)
                .Where(rt => rt.Reservation.ReservationDate == date)
                .ToListAsync();
        }
    }
}

