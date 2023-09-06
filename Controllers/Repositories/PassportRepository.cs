using AutoMapper;
using DFDS.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace DFDS.Controllers.Repositories
{
    public class PassportRepository : BaseRepository
    {
        public PassportRepository(DatabaseContext context, Mapper mapper) : base(context, mapper)
        {
        }

        internal Passenger? GetPassengerById(int id)
        {
            return ctx.Passengers.FirstOrDefault(pa => pa.Id == id);
        }

        internal IEnumerable<Passport>? GetPassengers(int pid)
        {
            return ctx.Passports.Where(p => pid == 0 || p.Id == pid).Include(p => p.Passenger);
        }

        internal Passport? GetPassportById(int id)
        {
            return ctx.Passports.FirstOrDefault(pass => id == pass.Id);
        }

        public void AddPassport(Passport p)
        {
            ctx.Passports.Add(p);
        }
        public void RemovePassport(Passport p)
        {
            ctx.Passports.Remove(p);
        }
    }
}
