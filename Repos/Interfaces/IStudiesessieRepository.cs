using FocusDesk.API.Models;

namespace FocusDesk.API.Repositories;

public interface IStudiesessieRepository
{
    Task<List<Studiesessie>> GetAll();
    Task<Studiesessie?> GetById(int id);
    Task<Studiesessie> Create(Studiesessie sessie);
    Task<Studiesessie?> Update(Studiesessie sessie);
    Task<bool> Delete(int id);
    Task<int> GetTotaleStudietijd();
}