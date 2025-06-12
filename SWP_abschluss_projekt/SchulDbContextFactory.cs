using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class SchulDbContextFactory : IDesignTimeDbContextFactory<SchulDbContext>
{
    public SchulDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SchulDbContext>();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));

        return new SchulDbContext(optionsBuilder.Options);
    }
}
