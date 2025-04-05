using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IService<Flight> _flightService;

        public FlightController(IService<Flight> flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string source, [FromQuery] string destination, [FromQuery] DateTime? date)
        {
            var allFlights = await _flightService.GetAllAsync();

            var filtered = allFlights.Where(f =>
                (string.IsNullOrEmpty(source) || f.Source.ToLower() == source.ToLower()) &&
                (string.IsNullOrEmpty(destination) || f.Destination.ToLower() == destination.ToLower()) &&
                (!date.HasValue || f.DepartureTime.Date == date.Value.Date)
            );

            return Ok(filtered);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }
    }
}
