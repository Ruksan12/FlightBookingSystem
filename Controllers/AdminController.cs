using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IService<Flight> _flightService;

        public AdminController(IService<Flight> flightService)
        {
            _flightService = flightService;
        }

        [HttpPost("add-flight")]
        public async Task<IActionResult> AddFlight([FromBody] Flight flight)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _flightService.AddAsync(flight);
            return Ok("Flight added successfully!");
        }

        [HttpPut("update-flight")]
        public async Task<IActionResult> UpdateFlight([FromBody] Flight flight)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _flightService.UpdateAsync(flight);
            return Ok("Flight updated successfully!");
        }

        [HttpDelete("delete-flight/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok("Flight deleted successfully!");
        }
    }
}
