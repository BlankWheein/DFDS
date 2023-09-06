using AutoMapper;
using DFDS.Classes;
using DFDS.Controllers.Repositories;
using DFDS.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly BookingRepository repo;

        public BookingsController(Mapper mapper, BookingRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Used to get 1 or all bookings
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int bid = 0)
        {
            List<BookingDto> x = repo.GetBookings(bid)?.ToList() ?? new();
            return Ok(x);
        }
        
        /// <summary>
        /// Used to update a bookings passengers, passenger limit and date
        /// </summary>
        /// <param name="eb"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EditBooking eb)
        {
            if (eb.PassengerLimit < eb.Passengers.Count)
                throw new Exception("too many passengers");
            var booking = repo.GetBookingByIdIncludePassenger(eb.Id) ?? throw new Exception("not found");
            booking.BookingDate = eb.BookingDate;
            booking.PassengerLimit = eb.PassengerLimit;
            booking.Passengers = repo.GetPassengerById(eb.Passengers)?.ToList() ?? new();
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to delete a booking
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete]
        public IActionResult Delete(int bid = 0)
        {
            var booking = repo.GetBookingById(bid) ?? throw new Exception("not found");
            repo.RemoveBooking(booking);
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to create a new booking
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Booking b)
        {
            if (b.BookingDate == DateTime.MinValue)
                throw new BadHttpRequestException("");
            b.Passengers.Clear();
            repo.AddBooking(b);
            repo.SaveChanges();
            return Ok();

        }
    }
}
