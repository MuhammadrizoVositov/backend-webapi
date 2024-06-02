using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Persistance.Repositories;

public class ReactionRepository(AppIdentityDbContext _dbContext) : EntityBaseRepository<MovieReaction, AppIdentityDbContext>(_dbContext), IReactionRepository
{
        


    public async ValueTask<bool> AddRaectionAsync(Guid userId, Guid itemId, bool isLike)
    {
        var exitereaction = await _dbContext.Reactions
           .FirstOrDefaultAsync(a => a.UserId == userId && a.ItemId == itemId);
        if (exitereaction != null)
        {
            exitereaction.IsLike = isLike;
        }
        else
        {
            var reaction = new MovieReaction
            {
                UserId = userId,
                ItemId = itemId,
                IsLike = isLike,
                CreatedAt = DateTime.UtcNow
            };
            _dbContext.Reactions.Add(reaction);
        }
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
