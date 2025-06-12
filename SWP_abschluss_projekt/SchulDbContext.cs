using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

public class SchulDbContext : DbContext
{
    public SchulDbContext(DbContextOptions<SchulDbContext> options) : base(options) { }

    public DbSet<Schueler> Schueler { get; set; }
    public DbSet<Lehrer> Lehrer { get; set; }
    public DbSet<Klasse> Klassen { get; set; }
    public DbSet<Fach> Faecher { get; set; }
    public DbSet<Note> Noten { get; set; }
    public DbSet<Raum> Raeume { get; set; }
    public DbSet<StundenplanEintrag> Stundenplaene { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Beispiel: Vererbung
        modelBuilder.Entity<Person>().HasDiscriminator<string>("PersonTyp")
            .HasValue<Schueler>("Schueler")
            .HasValue<Lehrer>("Lehrer");
    }
}
