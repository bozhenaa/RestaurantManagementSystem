using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservedTablesService _reservedTablesService;
        public ReservationController(IReservationService reservationService, IReservedTablesService reservedTables)
        {
            _reservationService = reservationService;
            _reservedTablesService = reservedTables;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations(DateOnly date)
        {
            try
            {
                var allTables = await _reservationService.GetAllReservationsByDate(date);
                return Ok(allTables);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById([FromQuery] int reservationId)
        {
            try
            {
                var tableById = await _reservationService.GetReservationById(reservationId);
                return Ok(tableById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> GetTableSuggestions (RequestReservationModel request)
        {
            try
            {
                var tableSuggestion = await _reservedTablesService.GetTableSuggestions(request.RoomName, request.Seats,
                    request.Date, request.Time);
                return Ok(tableSuggestion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation (MakeReservationModel model)
        {
            try
            {
                await _reservationService.AddReservation(model);
                return Ok($"Your have new reservation on {model.ReservationDate}, {model.ReservationTime} " +
                    $"for {model.ReservationName}");
            }
            catch(InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
