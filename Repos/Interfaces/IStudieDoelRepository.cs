using FocusDesk.API.Models;

namespace FocusDesk.API.Repositories;

public interface IStudieDoelRepository
{
    Task<List<StudieDoel>> GetAll();
    Task<StudieDoel?> GetById(int id);
    Task<StudieDoel> Create(StudieDoel doel);
    Task<StudieDoel?> Update(StudieDoel doel);
    Task<bool> Delete(int id);
}