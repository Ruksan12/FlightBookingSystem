using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // e.g., CreditCard, UPI, etc.

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
