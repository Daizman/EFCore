using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration.DbEntitiesConfiguration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasIndex(publihser => publihser.Id).IsUnique();
        builder.Property(publisher => publisher.Name).HasMaxLength(1024);

        builder
            .HasData(
                new Publisher(Guid.NewGuid(), "Pinguin"),
                new Publisher(Guid.NewGuid(), "Harper Collins"),
                new Publisher(Guid.NewGuid(), "Macmillan")
            );
    }
}