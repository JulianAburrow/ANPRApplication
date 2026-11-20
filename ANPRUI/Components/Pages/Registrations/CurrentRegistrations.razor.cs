namespace ANPRUserInterface.Components.Pages.Registrations;

public partial class CurrentRegistrations
{
    [Inject] protected IParkingRegistrationHandler ParkingRegistrationHandler { get; set; } = null!;

    private List<CurrentParkingRegistrationModel>? CurrentRegistrationsList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CurrentRegistrationsList = await ParkingRegistrationHandler.GetCurrentParkingRegistrationsAsync();
    }
}
