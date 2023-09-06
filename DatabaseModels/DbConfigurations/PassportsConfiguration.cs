using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFDS.DatabaseModels.DbConfigurations
{
    public class PassportsConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> b)
        {
            b.HasOne(p => p.Passenger).WithMany(p => p.Passports);
        }
    }
}
