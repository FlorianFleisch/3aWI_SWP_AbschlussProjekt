namespace SWP_abschluss_projekt.Models
{
    public class Fach
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; } = string.Empty;

        public Lehrer? Lehrer { get; set; }
        public List<Note> Noten { get; set; } = new();

        public Fach() { }

        public Fach(string bezeichnung, Lehrer lehrer)
        {
            Bezeichnung = bezeichnung;
            Lehrer = lehrer;
        }
    }
}

