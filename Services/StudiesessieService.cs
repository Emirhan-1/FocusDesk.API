using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using FocusDesk.API.Repositories;

namespace FocusDesk.API.Services;

public class StudiesessieService
{
    private readonly IStudiesessieRepository _repository;
    private readonly IStudieDoelRepository _studieDoelRepository;

    public StudiesessieService(
        IStudiesessieRepository repository,
        IStudieDoelRepository studieDoelRepository)
    {
        _repository = repository;
        _studieDoelRepository = studieDoelRepository;
    }

    public async Task<List<Studiesessie>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Studiesessie?> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Studiesessie> Create(MaakStudieSessieDTO dto)
    {
        var sessie = new Studiesessie
        {
            Starttijd = dto.Starttijd,
            Eindtijd = dto.Eindtijd,
            Duur = dto.Duur,
            GebruikerId = dto.GebruikerId,
            TagId = dto.TagId,
            StudieDoelId = dto.StudieDoelId
        };

        var result = await _repository.Create(sessie);

        // Automatisch BestedeUren ophogen als sessie gekoppeld is aan een doel
        if (dto.StudieDoelId.HasValue)
        {
            var doel = await _studieDoelRepository.GetById(dto.StudieDoelId.Value);
            if (doel != null)
            {
                doel.BestedeUren += dto.Duur / 60; // minuten naar uren
                await _studieDoelRepository.Update(doel);
            }
        }

        return result;
    }

    public async Task<Studiesessie?> Update(int id, BewerkStudiesessieDTO dto)
    {
        var sessie = await _repository.GetById(id);
        if (sessie == null) return null;

        sessie.Starttijd = dto.Starttijd;
        sessie.Eindtijd = dto.Eindtijd;
        sessie.Duur = dto.Duur;
        sessie.TagId = dto.TagId;
        sessie.StudieDoelId = dto.StudieDoelId;

        return await _repository.Update(sessie);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<int> GetTotaleStudietijd()
    {
        return await _repository.GetTotaleStudietijd();
    }
}