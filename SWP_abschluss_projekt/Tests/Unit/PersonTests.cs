using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class PersonTests
{
    [Test]
    public void Constructor_Sets_Names()
    {
        var person = new Person("Max", "Mustermann");
        Assert.AreEqual("Max", person.Vorname);
        Assert.AreEqual("Mustermann", person.Nachname);
    }
}
