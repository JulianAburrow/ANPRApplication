

namespace ANPRUserInterface.Components.Pages;

public partial class Home
{
    [Inject] protected IParkingRegistrationHandler ParkingRegistrationHandler { get; set; } = null!;

    [Inject] protected IRegistrationReader RegistrationReader { get; set; } = null!;

    private ParkingRegistrationDisplayModel ParkingRegsitrationDisplayModel { get; set; } = new();

    private string RegistrationNumberOrError { get; set; } = string.Empty;

    private bool IsThinking = false;

    private async Task UploadImage(IBrowserFile file)
    {
        if (file == null)
        {
            return;
        }

        RegistrationNumberOrError = string.Empty;

        IsThinking = true;

        await using var memoryStream = new MemoryStream();

        await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024) // 10 MB
                  .CopyToAsync(memoryStream);

        byte[] imageBytes = memoryStream.ToArray();

        IsThinking = false;

        RegistrationNumberOrError = await RegistrationReader.GetRegistrationNumberAsync(imageBytes);

        if (RegistrationNumberOrError != "Unsuccessful")
        {
            var parkingRegistrationModel = new ParkingRegistrationModel
            {
                RegistrationNumber = RegistrationNumberOrError.ToUpperInvariant(),
                RegistrationPhoto = imageBytes,
                DateParked = DateTime.Now,
                DateDeparted = null,
                ParkingCharge = null,
            };

            await ParkingRegistrationHandler.CreateParkingRegistrationAsync(parkingRegistrationModel);
        }
    }
}
