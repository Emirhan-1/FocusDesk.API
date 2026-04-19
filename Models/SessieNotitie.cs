namespace FocusDesk.API.Models;

public class Sessienotitie
{
    public int Id { get; set; }

    public string Inhoud { get; set; } = string.Empty;

    public DateTime AangemaaktOp { get; set; }

    public string Type { get; set; } = "student"; // student of coach

    public int StudiesessieId { get; set; }

    public Studiesessie Studiesessie { get; set; } = null!;
}