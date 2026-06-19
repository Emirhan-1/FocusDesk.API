using FocusDesk.API.Data;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Repositories;

public class CoachRepository : ICoachRepository
{
    private readonly AppDbContext _context;

    public CoachRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Gebruiker>> GetAlleStudenten()
    {
        return await _context.Gebruikers
            .Where(g => g.Rol == "Student")
            .Include(g => g.Studiesessies)
            .ToListAsync();
    }

    public async Task<Gebruiker?> GetStudentMetDetails(int id)
    {
        return await _context.Gebruikers
            .Where(g => g.Rol == "Student" && g.Id == id)
            .Include(g => g.Studiesessies)
            .FirstOrDefaultAsync();
    }
}