using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Controllers;
using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class SchuelerControllerTests
{
    private SchulDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<SchulDbContext>()
            .UseInMemoryDatabase(databaseName: "SchuelerControllerTests")
            .Options;
        return new SchulDbContext(options);
    }

    [Test]
    public async Task GetById_Returns_Schueler_When_Found()
    {
        using var context = CreateContext();
        var klasse = new Klasse("1A", new Lehrer("k","v"));
        var schueler = new Schueler("Max","Muster", klasse);
        context.Klassen.Add(klasse);
        context.Schueler.Add(schueler);
        context.SaveChanges();
        var controller = new SchuelerController(context);

        var result = await controller.GetById(schueler.Id);

        Assert.AreEqual(schueler.Id, result.Value?.Id);
    }

    [Test]
    public async Task Delete_Removes_Schueler()
    {
        using var context = CreateContext();
        var klasse = new Klasse("1A", new Lehrer("k","v"));
        var schueler = new Schueler("Tim","Test", klasse);
        context.Klassen.Add(klasse);
        context.Schueler.Add(schueler);
        context.SaveChanges();
        var controller = new SchuelerController(context);

        var response = await controller.Delete(schueler.Id);

        Assert.IsInstanceOf<NoContentResult>(response);
        Assert.AreEqual(0, context.Schueler.Count());
    }
}

