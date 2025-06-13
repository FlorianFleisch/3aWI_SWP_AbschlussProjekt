using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class FachTests
{
    [Test]
    public void Constructor_Sets_Properties()
    {
        var lehrer = new Lehrer("Anna", "Bauer");
        var fach = new Fach("Math", lehrer);

        Assert.AreEqual("Math", fach.Bezeichnung);
        Assert.AreSame(lehrer, fach.Lehrer);
        Assert.IsEmpty(fach.Noten);
    }
}
