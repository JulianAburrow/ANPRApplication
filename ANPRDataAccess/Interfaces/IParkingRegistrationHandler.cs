namespace ANPRDataAccess.Interfaces;

public interface IParkingRegistrationHandler
{
    public Task CreateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel);

    public Task<ParkingRegistrationModel> GetParkingRegistrationAsync(string registrationNumber);

    public Task UpdateParkingRegistrationAsync(ParkingRegistrationModel parkingRegistrationModel);
}
