using FootballPlayersCatalog.Dal.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<FootballPlayer> FootballPlayers { get; init; } = null!;
    public DbSet<Team> Teams { get; init; } = null!;
    public DbSet<Country> Countries { get; init; } = null!;
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres7;Username=postgres;Password=i");
    }
}