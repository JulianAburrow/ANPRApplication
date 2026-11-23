namespace ANPRUserInterface.Components.Pages.Registrations;

public partial class PreviousRegistrations
{
    private List<PreviousParkingRegistrationModel>? PreviousRegistrationsList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PreviousRegistrationsList = await ParkingRegistrationHandler.GetPreviousParkingRegistrationsAsync();
    }


}