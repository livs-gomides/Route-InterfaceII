using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAPI_SQL_Connect.Data;

namespace RouteAPI_SQL_Connect.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RouteDbContext _context;

    public AuthController(RouteDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest("Dados de registo inválidos.");
        }

        try
        {
            var emailExists = await _context.Persons.AnyAsync(p => p.Email == request.Email);
            if (emailExists)
            {
                return BadRequest("E-mail já cadastrado.");
            }

            var person = new Person
            {
                PersonID = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return Ok("Usuário cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            var detail = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, $"Erro na base de dados: {detail}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(p => p.Email == request.Email);
        if (person == null)
        {
            return Unauthorized("Credenciais inválidas.");
        }

        var isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, person.PasswordHash);
        if (!isValidPassword)
        {
            return Unauthorized("Credenciais inválidas.");
        }

        return Ok(new { Message = "Login realizado com sucesso", PersonId = person.PersonID });
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(p => p.Email == request.Email);
        if (person == null)
        {
            return NotFound("E-mail não encontrado.");
        }

        var tempPassword = Guid.NewGuid().ToString().Substring(0, 6);

        person.PasswordHash = BCrypt.Net.BCrypt.HashPassword(tempPassword);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Senha redefinida", NewPassword = tempPassword });
    }
}