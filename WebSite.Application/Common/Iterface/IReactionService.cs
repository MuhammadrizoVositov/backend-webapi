using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Iterface;
public interface IReactionService
{
    ValueTask<bool> LikeItemAsync(Guid userId, Guid itemId);
    ValueTask<bool> DislikeItemAsync(Guid userId, Guid itemId);
}
