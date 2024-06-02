namespace WebSite.Domain.Common.Entity;
public class ItemType:Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
