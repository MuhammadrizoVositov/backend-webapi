using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;

namespace WebSite.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemTypeController(AppIdentityDbContext appIdentityDb) : ControllerBase
{
    [HttpGet("get")]
    public async ValueTask<IActionResult>GetAll()
    {
        var itemtype = await appIdentityDb.ItemTypes.ToListAsync();
        return Ok(itemtype);
    }
    [HttpPost("create")]
    public async ValueTask<IActionResult>CreateAsync(ItemType itemType)
    {
        var news = new ItemType
        {
            Name = itemType.Name,
            Description = itemType.Description,
            
        };
        await appIdentityDb.ItemTypes.AddAsync(news);
        var result = await appIdentityDb.SaveChangesAsync();
        return Ok(result);
        
    }
}
