namespace WebSite.Domain.Common.Entity;
public class Item : Entity
{
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public required Guid UserId { get; set; }
    public AppUser User { get; set; }
    public required DateTimeOffset CreateAt { get; set; }
    public  DateTimeOffset UpdateAt { get; set; }
    public string? Description { get; set; }
    public Guid ItemTypeId { get; set; }
    public virtual ItemType? ItemType { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
