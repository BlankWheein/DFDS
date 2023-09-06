namespace DFDS.Classes
{
    public class EditBooking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int PassengerLimit { get; set; }
        public ICollection<int> Passengers { get; set; }
        public EditBooking()
        {
        }
    }
}
