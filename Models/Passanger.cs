using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
