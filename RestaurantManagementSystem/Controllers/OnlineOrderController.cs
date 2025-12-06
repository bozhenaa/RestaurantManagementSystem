using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineOrderController : ControllerBase
    {
        private readonly IOnlineOrderService _onlineOrderService;
        public OnlineOrderController(IOnlineOrderService onlineOrderService)
        {
            _onlineOrderService = onlineOrderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOnlineOrderById([FromQuery] int id)
        {
            try
            {
                var onlineOrder = await _onlineOrderService.GetOrdersByCustomerId(id);
                return Ok(onlineOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
       //[Authorize]
        public async Task<IActionResult> CreateOnlineOrder([FromBody] CreateOnlineOrderModel onlineOrder)
        {
            try
            {
                var userId= User.FindFirst("id");
                if (userId == null)
                {
                    return Unauthorized();
                }
                int userIdValue = int.Parse(userId.Value);
                await _onlineOrderService.CreateOrder(userIdValue, onlineOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("order-history")]
        [Authorize]
        public async Task<IActionResult> GetAllMyOrders()
        {
            try
            {
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                var myOrders = await _onlineOrderService.GetOrdersByCustomerId(int.Parse(userIdClaim.Value));
                return Ok(myOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, employee")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var allOrders = await _onlineOrderService.GetAllOrders();
                return Ok(allOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{orderId}/status")]
        [Authorize(Roles = "admin, emoloyee")]
        public async Task<IActionResult> UpdateStatus(int orderId, [FromQuery] OnlineOrderStatus status)
        {
            try
            {
                await _onlineOrderService.UpdateOrderStatus(orderId, status);
                return Ok();
            }
            catch (ArgumentNullException ex)
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
