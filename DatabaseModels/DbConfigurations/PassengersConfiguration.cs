using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFDS.DatabaseModels.DbConfigurations
{
    public class PassengersConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> b)
        {
            b.HasMany(p => p.Bookings);
        }
    }
}
