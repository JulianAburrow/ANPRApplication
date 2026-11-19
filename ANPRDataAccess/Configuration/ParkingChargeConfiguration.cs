using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANPRDataAccess.Configuration;

public class ParkingChargeConfiguration : IEntityTypeConfiguration<ParkingChargeModel>
{
    public void Configure(EntityTypeBuilder<ParkingChargeModel> builder)
    {
        builder.ToTable("ParkingCharge");
        builder.HasKey(x => x.ParkingChargeId);
    }
}
