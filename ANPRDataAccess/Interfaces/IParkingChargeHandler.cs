namespace ANPRDataAccess.Interfaces;

public interface IParkingChargeHandler
{
    Task<ParkingChargeModel> GetParkingChargeAsync(int minutesParked);
}
