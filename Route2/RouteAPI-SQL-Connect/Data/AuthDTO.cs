using System.Text.Json.Serialization;

namespace RouteAPI_SQL_Connect.Data;

public class AuthDTO 
{
}

public class RegisterDto
{
    [JsonPropertyName("nome")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("senha")]
    public string Password { get; set; }
}

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ForgotPasswordDto
{
    public string Email { get; set; } = string.Empty;

}