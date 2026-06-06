namespace FocusDesk.API.Models;

public class StudieDoel
{
    public int Id { get; set; }

    public string Titel { get; set; } = string.Empty;

    public int DoelUren { get; set; }

    public int GebruikerId { get; set; }

    public Gebruiker? Gebruiker { get; set; }

    public int BestedeUren { get; set; } = 0;

}