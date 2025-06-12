namespace SWP_abschluss_projekt.Models
{
    public class StundenplanEintrag
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Navigation Properties
        public Klasse? Klasse { get; set; }
        public Fach? Fach { get; set; }
        public Raum? Raum { get; set; }

        // ⚠️ EF braucht diesen parameterlosen Konstruktor
        public StundenplanEintrag() { }

        // Optionaler Konstruktor für deine eigene Logik
        public StundenplanEintrag(Klasse klasse, Fach fach, Raum raum, DateTime start, DateTime end)
        {
            Klasse = klasse;
            Fach = fach;
            Raum = raum;
            Start = start;
            End = end;
        }
    }
}
