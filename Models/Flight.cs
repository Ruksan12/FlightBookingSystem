using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required]
        public string Airline { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public int AvailableSeats { get; set; }
    }
}

