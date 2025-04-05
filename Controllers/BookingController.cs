using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IEmailService _emailService;


        public BookingController(IBookingService bookingService, IEmailService emailService)
        {
            _bookingService = bookingService;
            _emailService = emailService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _bookingService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost("book")]
        public async Task<IActionResult> BookFlight([FromBody] Booking booking)
        {
            await _bookingService.AddAsync(booking);
            var fullBooking = await _bookingService.GetByIdAsync(booking.BookingId);

            if (fullBooking?.Passenger?.Email != null)
            {
                var subject = "Flight Booking Confirmation";
                var body = $@"
            <h2>Booking Confirmed</h2>
            <p>Hi {fullBooking.Passenger.Name},</p>
            <p>Your flight booking from <b>{fullBooking.Flight.Source}</b> to <b>{fullBooking.Flight.Destination}</b> on <b>{fullBooking.Flight.DepartureTime}</b> is confirmed.</p>
            <p><b>Booking ID:</b> {fullBooking.BookingId}<br/>
            <b>Amount:</b> ₹{fullBooking.Price}<br/>
            <b>Status:</b> {fullBooking.Status}</p>
            <p>Thank you for choosing us!</p>";

                await _emailService.SendEmailAsync(fullBooking.Passenger.Email, subject, body);
            }

            return Ok("Flight booked and confirmation email sent!");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Booking booking)
        {
            await _bookingService.UpdateAsync(booking);
            return Ok("Booking updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync(id);
            return Ok("Booking deleted successfully!");
        }

        [HttpGet("passenger/{passengerId}")]
        public async Task<IActionResult> GetByPassengerId(int passengerId)
        {
            var bookings = await _bookingService.GetBookingsByPassengerId(passengerId);
            return Ok(bookings);
        }

        [HttpGet("flight/{flightId}")]
        public async Task<IActionResult> GetByFlightId(int flightId)
        {
            var bookings = await _bookingService.GetBookingsByFlightId(flightId);
            return Ok(bookings);
        }
    }
}
