using Microsoft.AspNetCore.Mvc;
using PaymentApi.Models;
using PaymentApi.Services;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST /api/payments
        [HttpPost]
        public async Task<IActionResult> RegisterPayment([FromBody] Payment payment)
        {
            try
            {
                var saved = await _paymentService.RegisterPaymentAsync(payment);
                return CreatedAtAction(nameof(RegisterPayment), new { id = saved.PaymentId }, saved);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET /api/payments?customerId=...----
        [HttpGet]
        public async Task<IActionResult> GetPayments([FromQuery] Guid customerId)
        {
            var payments = await _paymentService.GetPaymentsByCustomerAsync(customerId);
            return Ok(payments);
        }
    }
}
