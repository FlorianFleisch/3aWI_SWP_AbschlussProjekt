namespace SWP_abschluss_projekt.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int Wert { get; set; }

        public Schueler? Schueler { get; set; }
        public Fach? Fach { get; set; }

        public Note() { }

        public Note(Schueler schueler, Fach fach, int wert)
        {
            Schueler = schueler;
            Fach = fach;
            Wert = wert;
        }
    }
}
