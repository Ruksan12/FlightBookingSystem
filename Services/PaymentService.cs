using FlightBookingSystem.Data;
using FlightBookingSystem.Models;
using FlightBookingSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Services
{
    public class PaymentService : Service<Payment>, IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(IRepository<Payment> repository, ApplicationDbContext context) : base(repository)
        {
            _context = context;
        }

        public async Task<Payment> GetByBookingIdAsync(int bookingId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.BookingId == bookingId);
        }
    }
}
