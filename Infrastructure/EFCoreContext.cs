using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure
{
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

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void InitDb(ModelBuilder modelBuilder)
        {

        }
    }
}