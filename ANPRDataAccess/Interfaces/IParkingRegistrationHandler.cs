namespace ANPRDataAccess.Interfaces;

public interface IParkingRegistrationHandler
{
    public Task CreateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel);

    public Task<ParkingRegistrationModel?> GetParkingRegistrationAsync(string registrationNumber);

    public Task<List<CurrentParkingRegistrationModel>> GetCurrentParkingRegistrationsAsync();

    public Task<List<PreviousParkingRegistrationModel>> GetPreviousParkingRegistrationsAsync();

    public Task UpdateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel);
}
