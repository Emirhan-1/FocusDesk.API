namespace FocusDesk.API.Models;

public class Gebruiker
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string WachtwoordHash { get; set; } = string.Empty;

    public string Rol { get; set; } = "Student"; // Student of Coach

    public List<Studiesessie> Studiesessies { get; set; } = new();
}