using AutoMapper;
using DFDS.DatabaseModels;

namespace DFDS.Controllers.Repositories
{
    public class BaseRepository
    {
        protected DatabaseContext ctx;
        private DatabaseContext context;
        protected readonly Mapper mapper;

        public BaseRepository()
        {
            
        }
        public BaseRepository(DatabaseContext context, Mapper mapper)
        {
            this.ctx = context;
            this.mapper = mapper;
        }

        public virtual void SaveChanges()
        {
            ctx.SaveChanges();
        }

        internal bool DoesPassportExists(Passenger p)
        {
            return p.Passports.Any(p => !p.isValid() || DoesPassportExists(p));
        }

        internal bool DoesPassportExists(Passport p)
        {
            return  ctx.Passports.FirstOrDefault(pass => p.PassportNumber == pass.PassportNumber || p.Id == pass.Id) != null;
        }
    }
}