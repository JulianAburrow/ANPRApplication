namespace ANPRDataAccess.Models;

public class PreviousParkingRegistrationModel
{
    public DateTime DateParked { get; set; }

    public DateTime DateDeparted { get; set; }

    public decimal ParkingCharge { get; set; }

    public string LengthOfStay
    {
        get
        {
            TimeSpan duration = DateDeparted - DateParked;

            return $"{(int)duration.TotalHours} hrs {duration.Minutes} mins";
        }
    }

    public int LengthOfStayMinutes
    {
        get
        {
            return (int)(DateDeparted - DateParked).TotalMinutes;
        }
    }
}
