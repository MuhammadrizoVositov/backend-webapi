using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSite.Domain.Common.Entity;


namespace WebSite.Persistance.EntityConfiguration;
public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasIndex(u => u.EmailAdress).IsUnique();
        builder.HasIndex(u=>u.UserName).IsUnique();
    }
}
