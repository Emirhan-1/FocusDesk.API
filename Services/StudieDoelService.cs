using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using FocusDesk.API.Repositories;

namespace FocusDesk.API.Services;

public class StudieDoelService
{
    private readonly IStudieDoelRepository _repository;

    public StudieDoelService(IStudieDoelRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StudieDoel>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<StudieDoel?> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<StudieDoel> Create(MaakStudieDoelDTO dto)
    {
        var doel = new StudieDoel
        {
            Titel = dto.Titel,
            DoelUren = dto.DoelUren,
            GebruikerId = dto.GebruikerId,
            BestedeUren = 0
        };
        return await _repository.Create(doel);
    }

    public async Task<StudieDoel?> Update(int id, BewerkStudieDoelDTO dto)
    {
        var doel = await _repository.GetById(id);
        if (doel == null) return null;

        doel.Titel = dto.Titel;
        doel.DoelUren = dto.DoelUren;

        return await _repository.Update(doel);
    }

    public async Task<StudieDoel?> VoegUrenToe(int id, int uren)
    {
        var doel = await _repository.GetById(id);
        if (doel == null) return null;

        doel.BestedeUren += uren;
        return await _repository.Update(doel);
    }

    public int BerekenPercentage(StudieDoel doel)
    {
        if (doel.DoelUren == 0) return 0;
        var percentage = (int)Math.Round((double)doel.BestedeUren / doel.DoelUren * 100);
        return Math.Min(percentage, 100);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}