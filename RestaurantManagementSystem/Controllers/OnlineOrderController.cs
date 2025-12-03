using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
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

        [HttpPost("create-online-order")]
        [Authorize]
        public async Task<IActionResult> CreateOnlineOrder([FromBody] CreateOnlineOrderModel onlineOrder)
        {
            try
            {
                var userId = User.FindFirst("id");
                if (userId == null)
                {
                    return Unauthorized();
                }
                int userIdValue = int.Parse(userId.ToString());
                await _onlineOrderService.CreateOrder(userIdValue, onlineOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
