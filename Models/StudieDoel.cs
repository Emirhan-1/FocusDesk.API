namespace FocusDesk.API.Models
{
    public class Studiedoel
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int Doelwaarde { get; set; }

        public int GebruikerId { get; set; }

        public Gebruiker Gebruiker { get; set; }
    }
}