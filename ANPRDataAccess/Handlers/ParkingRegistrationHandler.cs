namespace ANPRDataAccess.Handlers;

public class ParkingRegistrationHandler(IDbContextFactory<ANPRApplicationContext> dbContextFactory) : IParkingRegistrationHandler
{
    public async Task CreateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        await context.ParkingRegistrations.AddAsync(parkingRegistrationModel);
        await context.SaveChangesAsync();
    }

    public async Task<List<CurrentParkingRegistrationModel>> GetCurrentParkingRegistrationsAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        return await context.ParkingRegistrations
            .Where(pr => pr.DateDeparted == null)
            .Select(pr => new CurrentParkingRegistrationModel
            {
                RegistrationNumber = pr.RegistrationNumber,
                DateParked = pr.DateParked
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ParkingRegistrationModel?> GetParkingRegistrationAsync(string registrationNumber)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        registrationNumber = registrationNumber
            .Replace(" ", "")
            .ToUpperInvariant();

        return await context.ParkingRegistrations
            .AsNoTracking()
            .SingleOrDefaultAsync(pr =>
                pr.RegistrationNumber!.Replace(" ", "") == registrationNumber);
    }

    public async Task<List<PreviousParkingRegistrationModel>> GetPreviousParkingRegistrationsAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        return await context.ParkingRegistrations
            .Where(pr => pr.DateDeparted != null)
            .Select(pr => new PreviousParkingRegistrationModel
            {
                DateParked = pr.DateParked,
                DateDeparted = pr.DateDeparted!.Value,
                ParkingCharge = (decimal)(pr.ParkingCharge ?? 0)
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        context.ParkingRegistrations.Update(parkingRegistrationModel);
        await context.SaveChangesAsync();
    }
}
