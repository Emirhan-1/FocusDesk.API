namespace FocusDesk.API.Models
{
    public class Sessienotitie
    {
        public int Id { get; set; }

        public string Inhoud { get; set; }

        public DateTime AangemaaktOp { get; set; }

        public int StudiesessieId { get; set; }

        public Studiesessie Studiesessie { get; set; }
    }
}