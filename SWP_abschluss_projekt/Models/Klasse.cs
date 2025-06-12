namespace SWP_abschluss_projekt.Models
{
    public class Klasse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Lehrer? Klassenvorstand { get; set; }
        public List<Schueler> Schueler { get; set; } = new();

        public Klasse() { }

        public Klasse(string name, Lehrer klassenvorstand)
        {
            Name = name;
            Klassenvorstand = klassenvorstand;
        }
    }
}
