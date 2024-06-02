namespace WebSite.Domain.Common.Entity;
public class Image
{
    public Guid Id { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public DateTime UploadedAt { get; set; }
}
