using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using FocusDesk.API.Repositories;

namespace FocusDesk.API.Services;

public class TagService
{
    private readonly ITagRepository _repository;

    public TagService(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Tag>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Tag?> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Tag> Create(MaakTagDTO dto)
    {
        var tag = new Tag
        {
            Naam = dto.Naam,
            Kleur = dto.Kleur
        };
        return await _repository.Create(tag);
    }

    public async Task<Tag?> Update(int id, MaakTagDTO dto)
    {
        var tag = await _repository.GetById(id);
        if (tag == null) return null;

        tag.Naam = dto.Naam;
        tag.Kleur = dto.Kleur;

        return await _repository.Update(tag);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}