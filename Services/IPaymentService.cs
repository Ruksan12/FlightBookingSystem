using FlightBookingSystem.Models;
using FlightBookingSystem.Services;

public interface IPaymentService : IService<Payment>
{
    Task<Payment> GetByBookingIdAsync(int bookingId);
}
