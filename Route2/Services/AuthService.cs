using System.Text;
using System.Text.Json;

namespace Route2.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = DeviceInfo.Platform == DevicePlatform.Android
        ? "https://10.0.2.2:7191/api/Auth"
        : "https://localhost:7191/api/Auth";

    public AuthService()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler);
    }

    public async Task<bool> RegisterAsync(string name, string email, string password)
    {
        var data = new { Name = name, Email = email, Password = password };
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_baseUrl}/register", content);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> LoginAsync(string email, string password)
    {
        var data = new { Email = email, Password = password };
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_baseUrl}/login", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<string> ForgotPasswordAsync(string email)
    {
        var data = new { Email = email };
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_baseUrl}/forgot-password", content);

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(responseString);
            return document.RootElement.GetProperty("newPassword").GetString();
        }

        return null;
    }
}