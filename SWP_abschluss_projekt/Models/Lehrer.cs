namespace SWP_abschluss_projekt.Models
{
    public class Lehrer : Person
    {
        public List<Fach> Faecher { get; set; } = new();
        public List<Klasse> KlassenAlsKV { get; set; } = new();

        public Lehrer() { }

        public Lehrer(string vorname, string nachname) : base(vorname, nachname) { }
    }
}
