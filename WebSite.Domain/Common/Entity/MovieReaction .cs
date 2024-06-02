namespace WebSite.Domain.Common.Entity;
public class MovieReaction:IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public bool IsLike { get; set; }
    public DateTime CreatedAt { get; set; }
}
