using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RouteAPI_SQL_Connect.Data;

public class AuthDTO 
{
}

public class RegisterDto
{
    [JsonPropertyName("nome")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.com(\.br)?$", ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("senha")]
    public string Password { get; set; } = string.Empty;
}

public class LoginDto
{
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.com(\.br)?$", ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ForgotPasswordDto
{
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.com(\.br)?$", ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;
}