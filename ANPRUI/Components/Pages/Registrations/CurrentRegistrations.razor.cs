namespace ANPRUserInterface.Components.Pages.Registrations;

public partial class CurrentRegistrations
{
    private List<CurrentParkingRegistrationModel>? CurrentRegistrationsList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CurrentRegistrationsList = await ParkingRegistrationHandler.GetCurrentParkingRegistrationsAsync();
    }
}
