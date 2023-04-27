using EFCore.Configuration.DbEntitiesConfiguration;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure;

public class EFCoreContext : DbContext
{
    private readonly string _connectionString;
    
    public EFCoreContext(DbContextOptions<EFCoreContext> options, IConfiguration configuration) : base(options)
    {
        var connectionString = configuration.GetConnectionString("SqliteDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string not found");
        }

        _connectionString = connectionString;
        Database.Migrate();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConifguration());
        modelBuilder.ApplyConfiguration(new JournalConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}