using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        [Required]
        public int PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Status { get; set; } = "Confirmed";
    }
}
