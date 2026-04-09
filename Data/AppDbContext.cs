using Microsoft.EntityFrameworkCore;
using FocusDesk.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gebruiker> Gebruikers { get; set; }

    public DbSet<Studiesessie> Studiesessies { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Studiedoel> Studiedoelen { get; set; }

    public DbSet<Sessienotitie> Sessienotities { get; set; }
}