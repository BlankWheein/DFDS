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

    public class PassengerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<PassportDto> Passports { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class PassportDto
    {
        public int Id { get; set; }
        public int PassportNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public string Cpr { get; set; } = "";
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
