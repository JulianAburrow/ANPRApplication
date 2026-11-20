namespace ANPRUserInterface.Components.Pages.Registrations;

public partial class Payment
{
    [Inject] protected IParkingRegistrationHandler ParkingRegistrationHandler { get; set; } = null!;

    [Inject] protected IParkingChargeHandler ParkingChargeHandler { get; set; } = null!;

    private string RegistrationNumber { get; set; } = string.Empty;

    private string ParkingDuration { get; set; } = string.Empty;

    private bool SearchPerformed { get; set; }

    private bool PaymentSuccessful = false;

    private ParkingRegistrationModel? ParkingRegistration { get; set; }

    private async Task RetrieveParkingDetails()
    {
        SearchPerformed = true;

        ParkingRegistration =
            await ParkingRegistrationHandler
                .GetParkingRegistrationAsync(RegistrationNumber);

        if (ParkingRegistration == null)
        {
            return;
        }

        ParkingRegistration.DateDeparted = DateTime.Now;

        int minutesParked =
            (int)Math.Ceiling(
                (ParkingRegistration.DateDeparted.Value -
                 ParkingRegistration.DateParked)
                .TotalMinutes);

        int hours = minutesParked / 60;
        int minutes = minutesParked % 60;

        ParkingDuration = $"{hours} hrs {minutes} minutes";


        ParkingChargeModel parkingCharge =
            await ParkingChargeHandler
                .GetParkingChargeAsync(minutesParked);

        ParkingRegistration.ParkingCharge =
            parkingCharge.Charge;
    }

    private async Task MakePayment()
    {
        if (ParkingRegistration is null)
        {
            return;
        }

        ParkingRegistration.RegistrationNumber = null;
        ParkingRegistration.RegistrationPhoto = null;

        await ParkingRegistrationHandler.UpdateParkingRegistrationAsync(ParkingRegistration);

        PaymentSuccessful = true;
    }
}
