using System;
using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class StundenplanEintragTests
{
    [Test]
    public void Constructor_Sets_Properties()
    {
        var klasse = new Klasse("1A", new Lehrer("A","B"));
        var fach = new Fach("Mathe", new Lehrer("C","D"));
        var raum = new Raum("R1");
        var start = new DateTime(2024,1,1,8,0,0);
        var end = new DateTime(2024,1,1,9,0,0);

        var eintrag = new StundenplanEintrag(klasse, fach, raum, start, end);

        Assert.AreSame(klasse, eintrag.Klasse);
        Assert.AreSame(fach, eintrag.Fach);
        Assert.AreSame(raum, eintrag.Raum);
        Assert.AreEqual(start, eintrag.Start);
        Assert.AreEqual(end, eintrag.End);
    }
}
