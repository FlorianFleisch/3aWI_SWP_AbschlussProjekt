using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class NoteTests
{
    [Test]
    public void Constructor_Sets_Properties()
    {
        var schueler = new Schueler("Max", "Muster", new Klasse("1A", new Lehrer("L","B")));
        var fach = new Fach("Deutsch", new Lehrer("T","S"));
        var note = new Note(schueler, fach, 1);

        Assert.AreSame(schueler, note.Schueler);
        Assert.AreSame(fach, note.Fach);
        Assert.AreEqual(1, note.Wert);
    }
}
