using Microsoft.AspNetCore.Http.Features;

namespace WebSite.Domain.Common.Entity;
public class Comment : Entity
{
    public Guid SenderId { get; set; }

    public AppUser Sender { get; set; }

    public Guid ItemId { get; set; }

    public string Content { get; set; } 
    public DateTime CreatedDate { get; set; }
   
}
