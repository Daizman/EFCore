using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration.DbEntitiesConfiguration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasIndex(genre => genre.Id).IsUnique();
        builder.Property(genre => genre.Name).HasMaxLength(128);
        builder.HasData(
            new Genre(1, "Ужасы"),
            new Genre(2, "Комедия"),
            new Genre(3, "Детектив"),
            new Genre(4, "Триллер"),
            new Genre(5, "Спорт"),
            new Genre(6, "Драма"),
            new Genre(7, "Романтика"),
            new Genre(8, "Фэнтези"),
            new Genre(9, "Приключения")
        );
    }
}