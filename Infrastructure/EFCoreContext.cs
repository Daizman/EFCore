using EFCore.Configuration.DbEntitiesConfiguration;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure;

public class EFCoreContext : DbContext
{
    public EFCoreContext(DbContextOptions<EFCoreContext> options)
        : base(options)
    {
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
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new JournalConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}