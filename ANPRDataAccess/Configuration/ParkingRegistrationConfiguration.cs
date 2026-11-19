namespace ANPRDataAccess.Configuration;

public class ParkingRegistrationConfiguration : IEntityTypeConfiguration<ParkingRegistrationModel>
{
    public void Configure(EntityTypeBuilder<ParkingRegistrationModel> builder)
    {
        builder.ToTable("ParkingRegistration");
        builder.HasKey(x => x.ParkingRegistrationId);
    }
}
