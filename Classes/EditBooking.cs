namespace DFDS.Classes
{
    public class EditBooking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int PassengerLimit { get; set; }
        public EditBooking() {
        }
    }
    public class EditBookingPassengers
    {

        public ICollection<int> PassengersToAdd { get; set; } = new HashSet<int>();
        public ICollection<int> PassengersToRemove { get; set; } = new HashSet<int>();
        public int Id { get; set; }

        public EditBookingPassengers()
        {
            PassengersToAdd = new HashSet<int>();
            PassengersToRemove = new HashSet<int>();
        }
    }
}
