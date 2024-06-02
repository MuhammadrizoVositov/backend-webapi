using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSite.Domain.Common.Entity;

namespace WebSite.Persistance.EntityConfiguration;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(a => a.Content).IsRequired();

        builder.HasOne(c => c.Sender)
            .WithMany()
            .HasForeignKey(c => c.SenderId);

        //builder.HasOne(c => c.Item)
        //    .WithMany(c => c.Comments)
        //    .HasForeignKey(c=>c.ItemId);
    }
}
