namespace ANPRUserInterface.Models;

public class ParkingRegistrationDisplayModel
{
    public int ParkingRegistrationId { get; set; }

    public string? RegistrationNumber { get; set; }

    public byte[]? RegistrationPhoto { get; set; }

    public DateTime DateParked { get; set; }

    public DateTime DateDeparted { get; set; }

    public decimal? ParkingCharge { get; set; }
}
