using FocusDesk.API.Models;

namespace FocusDesk.API.Repositories;

public interface ICoachRepository
{
    Task<List<Gebruiker>> GetAlleStudenten();
    Task<Gebruiker?> GetStudentMetDetails(int id);
}