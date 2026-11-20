namespace ANPRUserInterface.Components.Pages.Registrations;

public partial class PreviousRegistrations
{
    [Inject] protected IParkingRegistrationHandler ParkingRegistrationHandler { get; set; } = null!;

    private List<PreviousParkingRegistrationModel>? PreviousRegistrationsList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PreviousRegistrationsList = await ParkingRegistrationHandler.GetPreviousParkingRegistrationsAsync();
    }


}