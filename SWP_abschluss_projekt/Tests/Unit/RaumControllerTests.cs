using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Controllers;
using SWP_abschluss_projekt.Models;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class RaumControllerTests
{
    private SchulDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<SchulDbContext>()
            .UseInMemoryDatabase(databaseName: "RaumControllerTests")
            .Options;
        return new SchulDbContext(options);
    }

    [Test]
    public async Task GetAll_Returns_All_Raeume()
    {
        using var context = CreateContext();
        context.Raeume.AddRange(new Raum("R1"), new Raum("R2"));
        context.SaveChanges();
        var controller = new RaumController(context);

        var result = await controller.GetAll();

        Assert.AreEqual(2, result.Value?.Count());
    }

    [Test]
    public async Task Create_Adds_Raum()
    {
        using var context = CreateContext();
        var controller = new RaumController(context);
        var raum = new Raum("R3");

        var result = await controller.Create(raum);

        Assert.AreEqual(1, context.Raeume.Count());
        Assert.AreEqual(201, (result.Result as CreatedAtActionResult)?.StatusCode);
    }
}

