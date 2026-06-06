namespace FocusDesk.API.DTOs
{
    public class MaakStudieSessieDTO
    {
        public DateTime Starttijd { get; set; }
        public DateTime? Eindtijd { get; set; }
        public int Duur { get; set; }
        public int GebruikerId { get; set; }
        public int? TagId { get; set; }
        public int? StudieDoelId { get; set; }
    }
}