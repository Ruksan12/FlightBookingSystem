using FlightBookingSystem.Models;

namespace FlightBookingSystem.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByPassengerId(int passengerId);
        Task<IEnumerable<Booking>> GetBookingsByFlightId(int flightId);
    }
}

