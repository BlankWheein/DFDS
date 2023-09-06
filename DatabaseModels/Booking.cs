using System.ComponentModel.DataAnnotations;

namespace DFDS.DatabaseModels
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime BookingDate { get; set; }
        public int PassengerLimit { get; set; }
        public ICollection<PassengerDto>? Passengers { get; set; }
    }

    

    

    public class Booking
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime BookingDate { get; set; }
        public ICollection<Passenger>? Passengers { get; set; }
        public int PassengerLimit { get; set; }

        public Booking()
        {
            Passengers = new HashSet<Passenger>();
        }
    }
}
