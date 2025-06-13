using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class KlasseTests
{
    [Test]
    public void Constructor_Sets_Properties()
    {
        var lehrer = new Lehrer("Eva", "Schmidt");
        var klasse = new Klasse("3A", lehrer);

        Assert.AreEqual("3A", klasse.Name);
        Assert.AreSame(lehrer, klasse.Klassenvorstand);
        Assert.IsEmpty(klasse.Schueler);
    }
}
