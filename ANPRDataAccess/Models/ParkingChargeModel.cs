namespace ANPRDataAccess.Models;

public class ParkingChargeModel
{
    public int ParkingChargeId { get; set; }

    public int MinutesFrom { get; set; }

    public int MinutesTo { get; set; }

    public decimal Charge { get; set; }
}
