namespace SWP_abschluss_projekt.Models
{
    public class Schueler : Person
    {
        public Klasse? Klasse { get; set; }
        public List<Note> Noten { get; set; } = new();

        public Schueler() { }

        public Schueler(string vorname, string nachname, Klasse klasse) : base(vorname, nachname)
        {
            Klasse = klasse;
        }
    }
}
