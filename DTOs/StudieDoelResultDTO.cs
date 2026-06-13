namespace FocusDesk.API.DTOs;

public class StudieDoelResultDTO
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public int DoelUren { get; set; }
    public int BestedeUren { get; set; }
    public int VoortgangPercentage { get; set; }
}