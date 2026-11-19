namespace ANPRDataAccess.Data;

public class ANPRApplicationContext(DbContextOptions<ANPRApplicationContext> options) : DbContext(options)
{
    public DbSet<ParkingChargeModel> ParkingCharges { get; set; }
    public DbSet<ParkingRegistrationModel> ParkingRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ParkingChargeConfiguration());
        modelBuilder.ApplyConfiguration(new ParkingRegistrationConfiguration());
    }
}
