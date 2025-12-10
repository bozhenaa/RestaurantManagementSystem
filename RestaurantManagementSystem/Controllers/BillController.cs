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
            return Ok(await _billService.GetAllBill());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bill = await _billService.GetBillById(id);
            return bill == null ? NotFound() : Ok(bill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bill bill)
        {
            var newBill = await _billService.CreateBill(bill);
            return Ok(newBill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Bill bill)
        {
            bill.Id = id;
            var success = await _billService.UpdateBill(bill);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _billService.DeleteBill(id);
            return success ? Ok() : NotFound();
        }

        [HttpPost("{billId}/items")]
        public async Task<IActionResult> AddItem(int billId, int menuItemId, int quantity)
        {
            var success = await _billService.AddMenuItem(billId, menuItemId, quantity);
            return success ? Ok() : NotFound();
        }

        [HttpGet("total-payments")]
        public async Task<IActionResult> GetTotalPayments(DateTime start, DateTime end)
        {
            var total = await _billService.GetTotalPayments(start, end);
            return Ok(total);
        }
    }
}
