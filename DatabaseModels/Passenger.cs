using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFDS.DatabaseModels
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Passport> Passports { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Booking> Bookings { get; set; }
        public Passenger()
        {
            Passports = new HashSet<Passport>();
            Bookings = new HashSet<Booking>();
        }

        public void Clear()
        {
            Name = "Deleted";
            foreach (var passport in Passports)
                passport.Clear();
        }
    }
}
