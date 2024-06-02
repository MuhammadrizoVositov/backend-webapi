using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSite.Domain.Common.Entity;


namespace WebSite.Persistance.EntityConfiguration;
public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(u => u.Name).IsRequired();
    }
}
