namespace WebSite.Infrostructure.Common;

using WebSite.Application.Common.Iterface;
using WebSite.Persistance.Repositories.Interface;

public class RaectionService(IReactionRepository reactionRepository) : IReactionService
{
    public async ValueTask<bool> DislikeItemAsync(Guid userId, Guid itemId)
    {
        return await reactionRepository.AddRaectionAsync(userId, itemId,false);
    }

    public async ValueTask<bool> LikeItemAsync(Guid userId, Guid itemId)
    {
        return await reactionRepository.AddRaectionAsync(userId,itemId,true);
    }
}
