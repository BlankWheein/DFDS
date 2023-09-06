using AutoMapper;
using DFDS.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DFDS.Controllers.Repositories
{
    public class PassengerRepository : BaseRepository
    {
        public PassengerRepository(DatabaseContext context, Mapper mapper) : base(context, mapper) {}

        public PassengerRepository() : base()
        {
            
        }
        public virtual IEnumerable<Passenger?> GetPassengers(int pid)
        {
            return ctx.Passengers.Where(p => pid == 0 || p.Id == pid).Include(p => p.Passports);
        }

        public virtual Passenger? GetPassengerById(Passenger p)
        {
            return GetPassengerById(p.Id);
        }
        public virtual Passenger? GetPassengerById(int p)
        {
            return ctx.Passengers.FirstOrDefault(pas => pas.Id == p);
        }

        internal void RemovePassenger(Passenger passenger)
        {
            passenger.Clear();
            
        }

        internal void AddPassenger(Passenger p)
        {
            ctx.Passengers.Add(p);
        }

        internal Passenger? GetPassengerByIdIncludePassports(int pid)
        {
            return ctx.Passengers.Include(p => p.Passports).FirstOrDefault(pas => pas.Id == pid);
        }
    }
}
