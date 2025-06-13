using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class LehrerTests
{
    [Test]
    public void Constructor_Sets_Base_Properties()
    {
        var lehrer = new Lehrer("Tom", "Trauner");

        Assert.AreEqual("Tom", lehrer.Vorname);
        Assert.AreEqual("Trauner", lehrer.Nachname);
        Assert.IsEmpty(lehrer.Faecher);
        Assert.IsEmpty(lehrer.KlassenAlsKV);
    }
}
