using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using WebSite.Application.Common.Iterface;

namespace WebSite.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProfileController(IProfileService profileService) : ControllerBase
{
    [HttpGet("getAll")]
    public async ValueTask<IActionResult>GetProfile()
    {
        
        var getall=await profileService.GetProfileAsync();
        return Ok(getall);
    }
    [HttpPatch("changeName")]
    public async ValueTask<IActionResult>ChangeFirtName(Guid id)
    {
        var firstnames = await profileService.ChangeFirstName(id);
        if(firstnames==null)
        {
            return NotFound();
        }
        return Ok(firstnames);
    }
    [HttpPatch("changeLastname")]
    public async ValueTask<IActionResult>ChangeLastName(Guid id)
    {
        var lastnames=await profileService.ChangeLastName(id);
        if(lastnames==null)
        {
            return NotFound();
        }
        return Ok(lastnames);
    }
    [HttpPatch("password")]
    public async ValueTask<IActionResult>Password(Guid id)
    {
        var password = await profileService.ChangePassord(id);
        if(password==null)
        {
            return NotFound();
        }
            return Ok(password);
    }
}
