using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration.DbEntitiesConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasIndex(author => author.Id).IsUnique();
        builder.Property(author => author.Fio).HasMaxLength(2048);

        builder
            .HasData(
                new Author(Guid.NewGuid(), "Пушкин А.С.", new DateOnly(1799, 6, 6)),
                new Author(Guid.NewGuid(), "Достоевский Ф.М.", new DateOnly(1821, 10, 30)),
                new Author(Guid.NewGuid(), "Толстой Л.Н.", new DateOnly(1828, 8, 28)),
                new Author(Guid.NewGuid(), "Чехов А.П.", new DateOnly(1860, 1, 17))
            );
    }
}