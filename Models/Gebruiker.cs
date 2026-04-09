namespace FocusDesk.API.Models;
public class Gebruiker
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string WachtwoordHash { get; set; }

    public List<Studiesessie> Studiesessies { get; set; }
}