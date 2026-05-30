using FocusDesk.API.DTOs;
using FocusDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        var success = await _authService.Register(dto);

        if (!success)
        {
            return BadRequest("Email bestaat al.");
        }

        return Ok("Gebruiker geregistreerd.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var token = await _authService.Login(dto);

        if (token == null)
        {
            return Unauthorized("Ongeldige gegevens.");
        }

        return Ok(new
        {
            token
        });
    }
}