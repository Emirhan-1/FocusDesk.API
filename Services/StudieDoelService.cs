using FocusDesk.API.Data;
using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;
namespace FocusDesk.API.Services;

public class StudieDoelService
{
    private readonly AppDbContext _context;

    public StudieDoelService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudieDoel>> GetAll()
    {
        return await _context.StudieDoelen
            .ToListAsync();
    }

    public async Task<StudieDoel?> GetById(int id)
    {
        return await _context.StudieDoelen
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<StudieDoel> Create(MaakStudieDoelDTO dto)
    {
        var doel = new StudieDoel
        {
            Titel = dto.Titel,
            DoelUren = dto.DoelUren,
            GebruikerId = dto.GebruikerId
        };

        _context.StudieDoelen.Add(doel);

        await _context.SaveChangesAsync();

        return doel;
    }

    public async Task<bool> Delete(int id)
    {
        var doel = await _context.StudieDoelen
            .FindAsync(id);

        if (doel == null)
        {
            return false;
        }

        _context.StudieDoelen.Remove(doel);

        await _context.SaveChangesAsync();

        return true;
    }
}