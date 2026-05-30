using Microsoft.EntityFrameworkCore;
using FocusDesk.API.Models;

namespace FocusDesk.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gebruiker> Gebruikers { get; set; }

    public DbSet<Studiesessie> Studiesessies { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<StudieDoel> StudieDoelen { get; set; }

    public DbSet<Sessienotitie> SessieNotities { get; set; }
}