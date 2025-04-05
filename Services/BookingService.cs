using FlightBookingSystem.Models;
using FlightBookingSystem.Repositories;

namespace FlightBookingSystem.Services
{
    public class BookingService : Service<Booking>, IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPassengerId(int passengerId)
        {
            return await _bookingRepository.GetBookingsByPassengerId(passengerId);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByFlightId(int flightId)
        {
            return await _bookingRepository.GetBookingsByFlightId(flightId);
        }
        public async Task<Booking> GetDetailedBookingByIdAsync(int bookingId)
        {
            return await _bookingRepository.GetDetailedBookingByIdAsync(bookingId);
        }

    }
}
