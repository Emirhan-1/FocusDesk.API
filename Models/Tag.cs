namespace FocusDesk.API.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Kleur { get; set; }

        public List<Studiesessie> Studiesessies { get; set; }
    }
}