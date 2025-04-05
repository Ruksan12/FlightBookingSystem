using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> MakePayment([FromBody] Payment payment)
        {
            await _paymentService.AddAsync(payment);
            return Ok("Payment successful!");
        }

        [HttpGet("booking/{bookingId}")]
        public async Task<IActionResult> GetByBooking(int bookingId)
        {
            var payment = await _paymentService.GetByBookingIdAsync(bookingId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }
    }
}
