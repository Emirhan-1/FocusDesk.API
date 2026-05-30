namespace FocusDesk.API.DTOs;

public class MaakStudieDoelDTO
{
    public string Titel { get; set; } = string.Empty;

    public int DoelUren { get; set; }

    public int GebruikerId { get; set; }
}