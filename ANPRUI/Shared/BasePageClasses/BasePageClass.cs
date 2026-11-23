namespace ANPRUserInterface.Shared.BasePageClasses;

public abstract class BasePageClass : ComponentBase
{
    [Inject] protected IParkingRegistrationHandler ParkingRegistrationHandler { get; set; } = null!;
}
