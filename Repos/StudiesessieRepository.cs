using FocusDesk.API.Data;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Repositories;

public class StudiesessieRepository : IStudiesessieRepository
{
    private readonly AppDbContext _context;

    public StudiesessieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Studiesessie>> GetAll()
    {
        return await _context.Studiesessies
            .Include(s => s.Notities)
            .Include(s => s.Tag)
            .ToListAsync();
    }

    public async Task<Studiesessie?> GetById(int id)
    {
        return await _context.Studiesessies
            .Include(s => s.Notities)
            .Include(s => s.Tag)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Studiesessie> Create(Studiesessie sessie)
    {
        _context.Studiesessies.Add(sessie);
        await _context.SaveChangesAsync();
        return sessie;
    }

    public async Task<Studiesessie?> Update(Studiesessie sessie)
    {
        _context.Studiesessies.Update(sessie);
        await _context.SaveChangesAsync();
        return sessie;
    }

    public async Task<bool> Delete(int id)
    {
        var sessie = await _context.Studiesessies.FindAsync(id);
        if (sessie == null) return false;
        _context.Studiesessies.Remove(sessie);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> GetTotaleStudietijd()
    {
        return await _context.Studiesessies.SumAsync(s => s.Duur);
    }
}