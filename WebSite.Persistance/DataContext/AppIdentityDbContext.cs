using Microsoft.EntityFrameworkCore;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.EntityConfiguration;


namespace WebSite.Persistance.DataContext;
public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> dbContext) :DbContext(dbContext)
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<MovieReaction> Reactions => Set<MovieReaction>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Profile> Profile => Set<Profile>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDbContext).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);
    }
   

}
