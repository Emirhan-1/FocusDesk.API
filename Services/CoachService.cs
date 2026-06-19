using FocusDesk.API.Data;
using FocusDesk.API.DTOs;
using FocusDesk.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FocusDesk.API.Services;

public class CoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly AppDbContext _context;

    public CoachService(ICoachRepository coachRepository, AppDbContext context)
    {
        _coachRepository = coachRepository;
        _context = context;
    }

    public async Task<List<CoachStudentOverzichtDTO>> GetAlleStudenten()
    {
        var studenten = await _coachRepository.GetAlleStudenten();
        var result = new List<CoachStudentOverzichtDTO>();

        foreach (var student in studenten)
        {
            var doelen = await _context.StudieDoelen
                .Where(d => d.GebruikerId == student.Id)
                .ToListAsync();

            result.Add(new CoachStudentOverzichtDTO
            {
                GebruikerId = student.Id,
                Email = student.Email,
                TotaleStudietijd = student.Studiesessies.Sum(s => s.Duur),
                AantalSessies = student.Studiesessies.Count,
                Studiedoelen = doelen.Select(d => new CoachStudieDoelDTO
                {
                    Id = d.Id,
                    Titel = d.Titel,
                    DoelUren = d.DoelUren,
                    BestedeUren = d.BestedeUren,
                    VoortgangPercentage = d.DoelUren == 0 ? 0 : Math.Min(100, (int)Math.Round((double)d.BestedeUren / d.DoelUren * 100))
                }).ToList()
            });
        }

        return result;
    }
}