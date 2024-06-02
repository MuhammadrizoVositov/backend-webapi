namespace WebSite.Domain.Common.Entity;
public class Book : Entity
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? FilePath { get; set; }
    public DateTime UploadDate { get; set; }
}
