using System.Collections.Generic;

namespace FocusDesk.API.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Naam { get; set; } = string.Empty;

        public string Kleur { get; set; } = string.Empty;

        public ICollection<Studiesessie> Studiesessies { get; set; } = new List<Studiesessie>();
    }
}