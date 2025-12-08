using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Services.IServices;

namespace RestaurantManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _billService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bill = await _billService.GetByIdAsync(id);
            return bill == null ? NotFound() : Ok(bill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bill bill)
        {
            var newBill = await _billService.CreateAsync(bill);
            return Ok(newBill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Bill bill)
        {
            bill.Id = id;
            var success = await _billService.UpdateAsync(bill);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _billService.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }

        [HttpPost("{billId}/items")]
        public async Task<IActionResult> AddItem(int billId, int menuItemId, int quantity)
        {
            var success = await _billService.AddMenuItemAsync(billId, menuItemId, quantity);
            return success ? Ok() : NotFound();
        }
    }
}
