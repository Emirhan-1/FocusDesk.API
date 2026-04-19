using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FocusDesk.API.Models;

namespace FocusDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudiesessieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudiesessieController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET alle sessies
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessies = await _context.Studiesessies
                .Include(s => s.Notities)
                .Include(s => s.Tag)
                .ToListAsync();

            return Ok(sessies);
        }

        // 🔹 GET sessie op ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sessie = await _context.Studiesessies
                .Include(s => s.Notities)
                .Include(s => s.Tag)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sessie == null)
                return NotFound();

            return Ok(sessie);
        }

        // 🔹 POST nieuwe sessie (201 Created)
        [HttpPost]
        public async Task<IActionResult> Create(Studiesessie sessie)
        {
            _context.Studiesessies.Add(sessie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sessie.Id }, sessie);
        }

        // 🔹 DELETE sessie
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sessie = await _context.Studiesessies.FindAsync(id);

            if (sessie == null)
                return NotFound();

            _context.Studiesessies.Remove(sessie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}