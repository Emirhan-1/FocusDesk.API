using FocusDesk.API.Models;

namespace FocusDesk.API.Repositories;

public interface ITagRepository
{
    Task<List<Tag>> GetAll();
    Task<Tag?> GetById(int id);
    Task<Tag> Create(Tag tag);
    Task<Tag?> Update(Tag tag);
    Task<bool> Delete(int id);
}