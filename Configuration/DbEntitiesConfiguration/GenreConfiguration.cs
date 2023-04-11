using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration.DbEntitiesConfiguration
{
    public class GenreConifguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(genre => genre.Id).IsUnique();
            builder.Property(genre => genre.Name).HasMaxLength(128);
        }
    }
}