namespace ANPRServices.Interfaces;

public interface IRegistrationReader
{
    Task<string> GetRegistrationNumberAsync(byte[] imageBytes);
}
