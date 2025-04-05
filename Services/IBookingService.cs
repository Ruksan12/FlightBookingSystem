using FlightBookingSystem.Models;

namespace FlightBookingSystem.Services
{
    public interface IBookingService : IService<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByPassengerId(int passengerId);
        Task<IEnumerable<Booking>> GetBookingsByFlightId(int flightId);
        Task<Booking> GetDetailedBookingByIdAsync(int bookingId);


    }
}
