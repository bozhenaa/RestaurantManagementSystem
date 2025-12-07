using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;

namespace RestaurantManagementSystem.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantMSDbContext _context;
        public ReservationRepository(RestaurantMSDbContext context)
        {
            _context = context;
        }

        public async Task AddReservation(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            
            await _context.SaveChangesAsync();
        }

        public async Task RemoveReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _context.Reservations
               .Include(r=> r.ReservedTables)
               .ThenInclude(rt=>rt.RestaurantTable)
               .OrderByDescending(o => o.ReservationDate)
               .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsByDate(DateOnly date)
        {
            return await _context.Reservations
                 .Where(o => o.ReservationDate == date)
                 .Include(r => r.ReservedTables)          
                 .ThenInclude(rt => rt.RestaurantTable)
                 .OrderByDescending(o => o.ReservationTime)
                 .ToListAsync();
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations
                .Include(r=>r.ReservedTables)
                .ThenInclude(rt=>rt.RestaurantTable)
                .FirstOrDefaultAsync(o => o.ReservationId == id);
        }
    }
}
