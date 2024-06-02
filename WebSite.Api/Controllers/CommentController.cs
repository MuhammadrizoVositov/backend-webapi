using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Common.Iterface;
using WebSite.Application.Common.Models;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;

namespace WebSite.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CommentController(ICommentService commentService,AppIdentityDbContext appIdentity) : ControllerBase
{
    [HttpPost("addComment/api")]
    public async ValueTask<IActionResult>AddAsync([FromBody]CommetDto commentdto)
    {
        var addDto = new Comment
        {
            SenderId = commentdto.SenderId,
            Content = commentdto.Content,
            CreatedDate = commentdto.CreatedDate,
            ItemId = commentdto.ItemId,

        };
        await commentService.AddComment(addDto);
        var result = await appIdentity.SaveChangesAsync();
        return Ok(result);
            
    }
    [HttpGet("GetbyId")]
    public async ValueTask<IActionResult>GetCommentById([FromBody]Comment comment)
    {
        var getid= await commentService.GetCommentById(comment.Id,true);
        
        return Ok(getid);
    }
    [HttpDelete("delete")]
    public async ValueTask<IActionResult>DeleteComment(Guid Id)
    {
            var delete=await commentService.DaleteComment(Id,true);
        return Ok(delete);
    }
    [HttpGet("getcomment")]
    public async ValueTask<IActionResult> GetComment()
    {
        var getAll=await commentService.GetComments();
        return Ok(getAll);
    }
    [HttpPut("post")]
    public async ValueTask<IActionResult>UpDate([FromBody]Comment comment)
    {
        var update = await commentService.UpDate(comment,true);
        return Ok(update);
            
    }

}
