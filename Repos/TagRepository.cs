using FocusDesk.API.Data;
using FocusDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Repositories;

public class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tag>> GetAll()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag?> GetById(int id)
    {
        return await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tag> Create(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag?> Update(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task<bool> Delete(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null) return false;
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
        return true;
    }
}