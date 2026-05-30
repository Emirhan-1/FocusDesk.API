using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FocusDesk.API.Data;

namespace FocusDesk.API.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<bool> Register(RegisterDTO dto)
    {
        var bestaatAl = await _context.Gebruikers
            .AnyAsync(g => g.Email == dto.Email);

        if (bestaatAl)
        {
            return false;
        }

        var gebruiker = new Gebruiker
        {
            Email = dto.Email,
            WachtwoordHash = BCrypt.Net.BCrypt.HashPassword(dto.Wachtwoord),
            Rol = "Student"
        };

        _context.Gebruikers.Add(gebruiker);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<string?> Login(LoginDTO dto)
    {
        var gebruiker = await _context.Gebruikers
            .FirstOrDefaultAsync(g => g.Email == dto.Email);

        if (gebruiker == null)
        {
            return null;
        }

        bool wachtwoordCorrect = BCrypt.Net.BCrypt.Verify(
            dto.Wachtwoord,
            gebruiker.WachtwoordHash
        );

        if (!wachtwoordCorrect)
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, gebruiker.Email),
            new Claim(ClaimTypes.Role, gebruiker.Rol)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}