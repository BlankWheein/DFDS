using DFDS.Controllers.Repositories;
using DFDS.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;

namespace DFDS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassportController : Controller
    {
        private readonly PassportRepository repo;

        public PassportController( PassportRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Used to get 1 or all passports
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int pid = 0)
        {
            return Ok(repo.GetPassengers(pid));
        }
        /// <summary>
        /// Used to update a passport
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Passport p)
        {
            if (!p.isValid())
                throw new BadHttpRequestException("");
            var pass = repo.GetPassportById(p.Id) ?? throw new BadHttpRequestException("");
            pass.PassportNumber = p.PassportNumber;
            pass.Cpr = p.Cpr;
            pass.ExpirationDate = p.ExpirationDate;
            pass.IssueDate = p.IssueDate;
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to delete a passport
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete]
        public async Task<IActionResult> Delete(int pid = 0)
        {
            var pass = repo.GetPassportById(pid) ?? throw new BadHttpRequestException("");
            repo.RemovePassport(pass);
            repo.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Used to create a new passport
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Passport p)
        {
            if (p.Passenger == null)
                throw new BadHttpRequestException("");
            if (repo.DoesPassportExists(p))
                throw new BadHttpRequestException("");
            if (!p.isValid())
                throw new BadHttpRequestException("");
            var passenger = repo.GetPassengerById(p.Passenger.Id) ?? throw new BadHttpRequestException("");
            p.Passenger = passenger;
            repo.AddPassport(p);
            repo.SaveChanges();
            return Ok();
        }

        
    }
}
