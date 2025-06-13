using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class SchuelerTests
{
    [Test]
    public void Constructor_Sets_Properties()
    {
        var klasse = new Klasse("1B", new Lehrer("L","B"));
        var schueler = new Schueler("Tim", "Test", klasse);

        Assert.AreEqual("Tim", schueler.Vorname);
        Assert.AreEqual("Test", schueler.Nachname);
        Assert.AreSame(klasse, schueler.Klasse);
        Assert.IsEmpty(schueler.Noten);
    }
}
