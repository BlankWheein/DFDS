using AutoMapper;
using DFDS.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DFDS.Controllers.Repositories
{
    public class BookingRepository : BaseRepository
    {
        public BookingRepository(DatabaseContext context, Mapper mapper) : base(context, mapper) {}
        public IEnumerable<BookingDto>? GetBookings(int bid)
        {
            return ctx.Bookings
                .Include(p => p.Passengers).ThenInclude(p => p.Passports)
                .Where(p => bid == 0 || p.Id == bid)
                .ProjectToList<BookingDto>(mapper.ConfigurationProvider);
        }

        internal void AddBooking(Booking b)
        {
            ctx.Bookings.Add(b);
        }

        internal Booking? GetBookingById(int id)
        {
            return ctx.Bookings.FirstOrDefault(b => b.Id == id);
        }

        internal Booking? GetBookingByIdIncludePassenger(int id)
        {
            return ctx.Bookings.Include(p => p.Passengers).FirstOrDefault(b => b.Id == id);
        }

        internal List<Passenger>? GetPassengerById(ICollection<int> passengers)
        {
            return ctx.Passengers.Where(p => passengers.Contains(p.Id)).ToList();
        }

        internal void RemoveBooking(Booking bid)
        {
            ctx.Bookings.Remove(bid);
        }
    }
}
