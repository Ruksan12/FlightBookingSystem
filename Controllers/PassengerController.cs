using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IService<Passenger> _passengerService;

        public PassengerController(IService<Passenger> passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _passengerService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var passenger = await _passengerService.GetByIdAsync(id);
            if (passenger == null) return NotFound();
            return Ok(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Passenger passenger)
        {
            await _passengerService.AddAsync(passenger);
            return Ok("Passenger added successfully!");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Passenger passenger)
        {
            await _passengerService.UpdateAsync(passenger);
            return Ok("Passenger updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _passengerService.DeleteAsync(id);
            return Ok("Passenger deleted successfully!");
        }
    }
}
