using FocusDesk.API.Data;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Repositories;

public class StudieDoelRepository : IStudieDoelRepository
{
    private readonly AppDbContext _context;

    public StudieDoelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudieDoel>> GetAll()
    {
        return await _context.StudieDoelen.ToListAsync();
    }

    public async Task<StudieDoel?> GetById(int id)
    {
        return await _context.StudieDoelen.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<StudieDoel> Create(StudieDoel doel)
    {
        _context.StudieDoelen.Add(doel);
        await _context.SaveChangesAsync();
        return doel;
    }

    public async Task<StudieDoel?> Update(StudieDoel doel)
    {
        _context.StudieDoelen.Update(doel);
        await _context.SaveChangesAsync();
        return doel;
    }

    public async Task<bool> Delete(int id)
    {
        var doel = await _context.StudieDoelen.FindAsync(id);
        if (doel == null) return false;
        _context.StudieDoelen.Remove(doel);
        await _context.SaveChangesAsync();
        return true;
    }
}