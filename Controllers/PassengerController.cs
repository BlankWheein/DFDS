using DFDS.Controllers.Repositories;
using DFDS.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DFDS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : Controller
    {
        private readonly PassengerRepository repo;

        public PassengerController(PassengerRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Used to get 1 or all passengers
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int pid = 0)
        {
            var passenger = repo.GetPassengers(pid);
            return Ok(passenger);
        }
        /// <summary>
        /// Used to update a passengers name
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPost]
        public IActionResult Post([FromBody] Passenger p)
        {
            var passenger = repo.GetPassengerById(p);
            if (passenger == null)
                return NotFound("Passenger not found");
            passenger.Name = p.Name;
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to delete a passenger
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete]
        public IActionResult Delete(int pid = 0)
        {
            var passenger = repo.GetPassengerByIdIncludePassports(pid) ?? throw new BadHttpRequestException("");
            repo.RemovePassenger(passenger);
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to create a new passenger
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPut]
        public IActionResult Put([FromBody] Passenger p)
        {
            if (p.Passports?.Any() != true)
                throw new BadHttpRequestException("");
            if (repo.DoesPassportExists(p))
                throw new BadHttpRequestException("");
            p.Bookings.Clear();
            repo.AddPassenger(p);
            repo.SaveChanges();
            return Ok();
        }
    }
}
