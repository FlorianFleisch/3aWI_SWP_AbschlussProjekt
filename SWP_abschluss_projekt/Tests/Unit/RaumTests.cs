using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class RaumTests
{
    [Test]
    public void Constructor_Sets_Bezeichnung()
    {
        var raum = new Raum("R101");

        Assert.AreEqual("R101", raum.Bezeichnung);
    }
}
