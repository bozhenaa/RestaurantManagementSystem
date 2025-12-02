using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;

        public RestaurantTableController(IRestaurantTableService restaurantTableService)
        {
            _restaurantTableService = restaurantTableService;
        }

        [HttpGet("all-tables")]
        [Authorize(Roles = "admin, employee")]
        public async Task<IActionResult> GetAllTables()
        {
            try
            {
                var allTablesList = await _restaurantTableService.GetAllTables();
                return Ok(allTablesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("table-by-id/{id}")]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> GetTableById(int id)
        {
            try
            {
                var table = await _restaurantTableService.GetTableById(id);
                return Ok(table);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("table-by-number")]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> GetTableByNumber([FromQuery] int tableNumber)
        {
            try
            {
                var table = await _restaurantTableService.GetTableByNumber(tableNumber);
                return Ok(table);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tables-by-room/{roomName}")]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> GetTablesByRoom(RoomName roomName)
        {
            try
            {
                var tablesInRoom = await _restaurantTableService.GetTablesByRoom(roomName);
                return Ok(tablesInRoom);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-table/{id}")]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            try
            {
                var tableToDelete = await _restaurantTableService.GetTableById(id);
                await _restaurantTableService.DeleteTable(tableToDelete);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-table")]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> AddTable([FromBody] AddRestaurantTableModel table)
        {
            try
            {
                await _restaurantTableService.AddTable(table);
                return Created();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("update-table")]
        [Authorize(Roles ="admin, employee")]
        public async Task<IActionResult> UpdateTable([FromBody] AddRestaurantTableModel table)
        {
            try
            {
                await _restaurantTableService.UpdateTable(table);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
