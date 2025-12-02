using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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


    }
}
