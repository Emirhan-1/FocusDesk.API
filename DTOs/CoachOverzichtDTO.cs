namespace FocusDesk.API.DTOs;

public class CoachStudentOverzichtDTO
{
    public int GebruikerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public int TotaleStudietijd { get; set; }
    public int AantalSessies { get; set; }
    public List<CoachStudieDoelDTO> Studiedoelen { get; set; } = new();
}

public class CoachStudieDoelDTO
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public int DoelUren { get; set; }
    public int BestedeUren { get; set; }
    public int VoortgangPercentage { get; set; }
}