using FootballPlayersCatalog.Dal.Contexts;
using FootballPlayersCatalog.Dal.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<FootballPlayer> FootballPlayers { get; init; } = null!;
    public DbSet<Team> Teams { get; init; } = null!;
    public DbSet<Country> Countries { get; init; } = null!;
    private readonly DalSetting dalSetting;

    public ApplicationContext(DbContextOptions<ApplicationContext> options, DalSetting dalSetting) : base(options)
    {
        this.dalSetting = dalSetting;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(dalSetting.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "Россия" },
            new Country { Id = 2, Name = "США" },
            new Country { Id = 3, Name = "Италия" }
        );
    }
}