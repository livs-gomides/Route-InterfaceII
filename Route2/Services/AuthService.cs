using System.Net.Http.Json;
using System.Text.Json;

namespace Route2.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://routeips.runasp.net";

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(bool IsSuccess, string Message)> RegisterAsync(string name, string email, string password)
    {
        try
        {
            var data = new { nome = name, email = email, senha = password };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/auth/register", data);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, "Usuário cadastrado com sucesso.");
            }

            string errorMessage = string.IsNullOrWhiteSpace(content) ? "Erro ao realizar o cadastro." : content.Trim('"');
            return (false, errorMessage);
        }
        catch (Exception ex)
        {
            return (false, $"Erro de ligação: {ex.Message}");
        }
    }

    public async Task<(bool IsSuccess, string Message)> LoginAsync(string email, string password)
    {
        try
        {
            var data = new { email = email, password = password };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/auth/login", data);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, "Login realizado com sucesso.");
            }

            string errorMessage = string.IsNullOrWhiteSpace(content) ? "Credenciais inválidas." : content.Trim('"');
            return (false, errorMessage);
        }
        catch (Exception ex)
        {
            return (false, $"Erro de ligação: {ex.Message}");
        }
    }

    public async Task<string> ForgotPasswordAsync(string email)
    {
        try
        {
            var data = new { email = email };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/auth/forgot-password", data);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                using var document = JsonDocument.Parse(responseString);

                return document.RootElement.GetProperty("newPassword").GetString();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}