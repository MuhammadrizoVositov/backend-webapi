using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;

namespace WebSite.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("get")]
    public async ValueTask<IActionResult>GetAsync()
    {
        return Ok( await userService.GetAsync(true,default));
    }
    [HttpPost("post")]
    public async ValueTask<IActionResult>Create(AppUser user)
    {
        var users= await userService.CreateAsync(user,true);
        return Ok(users);
    }
    [HttpGet("post")]
    public async ValueTask<IActionResult>GetById(Guid id)
    {
        var ids= await userService.GetByIdAsync(id,true);
        return Ok(ids);
    }
    [HttpPost("Update")]
    public async ValueTask<IActionResult>Update(AppUser user)
    {
        var update=await userService.UpdateAsync(user,true);
        return Ok(update);
    }
    [HttpGet("Getall")]
    public async ValueTask<IActionResult>GetAll(IEnumerable<Guid> ids)
    {
        var update=await userService.DeleteByIdsAsync(ids,true,default);
        return Ok(update);
    }
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteById(IEnumerable<Guid> ids)
    {
        var delete=await userService.DeleteByIdsAsync(ids,false,default);
        return Ok(delete);
    }

}
