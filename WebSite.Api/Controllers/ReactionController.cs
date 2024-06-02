using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;

namespace WebSite.Api.Controllers;
[Route("api/reaction")]
[ApiController]
public class ReactionController(IReactionService reactionService) : ControllerBase
{
    [HttpPost("like/{itemId}")]
    public async ValueTask<IActionResult> LikeItem(Guid itemId)
    {
        var userClaims = User.FindFirst("UserId");
       
        if (userClaims is null|| !Guid.TryParse(userClaims.Value,out Guid userId)||userId==Guid.Empty)
        {
            return BadRequest("Not fount ID");
        }

        var result = await reactionService.LikeItemAsync(userId, itemId);

        if (result)
        {
            return Ok("This element like");
        }

        return StatusCode(500, "Is not like yhis element");
    }

    [HttpPost("dislike/{itemId}")]
    public async ValueTask<IActionResult> Dislike(Guid itemId)
    {
        var claimuser=User.FindFirst("UserId");
   
        if (claimuser.Value is null || !Guid.TryParse(claimuser.Value, out Guid userId))
        {
            return BadRequest("Not found user ID");
        }
        var result = await reactionService.DislikeItemAsync(userId, itemId);
        if (result)
        {
            return Ok("This element Dislike ");
        }

        return Ok();
    }
    
  
}

//class ReactionModel
//{
//    public Guid ItemId { get; set; }
//    public int LikeCount { get; set; }
//    public int DisLikeCount { get; set; }
//    public ICollection< AppUser> LikedUsers { get; set; }
//    public ICollection< AppUser> DisLikedUsers { get; set; }
//
//}    