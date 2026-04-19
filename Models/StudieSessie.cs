namespace FocusDesk.API.Models;

public class Studiesessie
{
    public int Id { get; set; }

    public DateTime Starttijd { get; set; }

    public DateTime? Eindtijd { get; set; }

    public int Duur { get; set; }

    public int GebruikerId { get; set; }

    public Gebruiker Gebruiker { get; set; } = null!;

    public int? TagId { get; set; }

    public Tag? Tag { get; set; }

    public List<Sessienotitie> Notities { get; set; } = new();
}