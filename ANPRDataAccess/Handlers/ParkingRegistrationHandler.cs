namespace ANPRDataAccess.Handlers;

public class ParkingRegistrationHandler(IDbContextFactory<ANPRApplicationContext> dbContextFactory) : IParkingRegistrationHandler
{
    public async Task CreateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        await context.ParkingRegistrations.AddAsync(parkingRegistrationModel);
        await context.SaveChangesAsync();
    }

    public async Task<ParkingRegistrationModel> GetParkingRegistrationAsync(string registrationNumber)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        return await context.ParkingRegistrations
            .SingleAsync(pr => pr.RegistrationNumber == registrationNumber);
    }

    public async Task UpdateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        context.ParkingRegistrations.Update(parkingRegistrationModel);
        await context.SaveChangesAsync();
    }
}
