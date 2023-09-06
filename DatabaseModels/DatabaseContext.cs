using DFDS.DatabaseModels;
using Microsoft.EntityFrameworkCore;
namespace DFDS
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = "server=localhost;database=DFDS;uid=remote;Password=Abby5583;Command Timeout=60";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql(cs, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
