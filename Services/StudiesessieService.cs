using FocusDesk.API.Data;
using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Services;

public class StudiesessieService
{
    private readonly AppDbContext _context;

    public StudiesessieService(AppDbContext context)
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

    public async Task<Studiesessie> Create(MaakStudieSessieDTO dto)
    {
        var sessie = new Studiesessie
        {
            Starttijd = dto.Starttijd,
            Eindtijd = dto.Eindtijd,
            Duur = dto.Duur,
            GebruikerId = dto.GebruikerId,
            TagId = dto.TagId
        };

        _context.Studiesessies.Add(sessie);

        await _context.SaveChangesAsync();

        return sessie;
    }

    public async Task<bool> Delete(int id)
    {
        var sessie = await _context.Studiesessies.FindAsync(id);

        if (sessie == null)
        {
            return false;
        }

        _context.Studiesessies.Remove(sessie);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Studiesessie?> Update(
        int id,
        BewerkStudiesessieDTO dto)
    {
        var sessie = await _context.Studiesessies
            .FindAsync(id);

        if (sessie == null)
        {
            return null;
        }

        sessie.Starttijd = dto.Starttijd;
        sessie.Eindtijd = dto.Eindtijd;
        sessie.Duur = dto.Duur;
        sessie.TagId = dto.TagId;

        await _context.SaveChangesAsync();

        return sessie;
    }

    public async Task<int> GetTotaleStudietijd()
    {
        return await _context.Studiesessies
            .SumAsync(s => s.Duur);
    }
}