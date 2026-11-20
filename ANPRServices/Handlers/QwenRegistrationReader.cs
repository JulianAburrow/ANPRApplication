using ANPRServices.Interfaces;

namespace ANPRServices.Handlers;

public class QwenRegistrationReader(HttpClient httpClient) : IRegistrationReader
{
    public async Task<string> GetRegistrationNumberAsync(byte[] imageBytes)
    {
        var promptPath = Path.Combine(AppContext.BaseDirectory, "Prompts", "QwenImagePrompt.txt");
        var prompt = await File.ReadAllTextAsync(promptPath);
        var imageBase64 = Convert.ToBase64String(imageBytes);
        var request = new
        {
            model = "qwen2.5vl:7b",
            prompt,
            images = new[]
            {
                imageBase64
            },
            stream = false
        };

        var response = await httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", request);

        response.EnsureSuccessStatusCode();

        var ollamaResponse = await response.Content.ReadFromJsonAsync<OllamaResponse>();
        return ollamaResponse?.Response ?? "Unsuccessful";
    }
}
