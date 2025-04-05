using FlightBookingSystem.Data;
using FlightBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPassengerId(int passengerId)
        {
            return await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .Where(b => b.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByFlightId(int flightId)
        {
            return await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Passenger)
                .Where(b => b.FlightId == flightId)
                .ToListAsync();
        }
    }
}
