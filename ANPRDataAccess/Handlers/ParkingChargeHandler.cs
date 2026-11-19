namespace ANPRDataAccess.Handlers;

public class ParkingChargeHandler(IDbContextFactory<ANPRApplicationContext> dbContextFactory) : IParkingChargeHandler
{
    public async Task<ParkingChargeModel> GetParkingChargeAsync(int minutesParked)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();
        return await context.ParkingCharges
            .SingleAsync(pc =>
                    pc.MinutesFrom <= minutesParked &&
                    pc.MinutesTo >= minutesParked);
    }
}
