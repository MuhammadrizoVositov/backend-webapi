using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Persistance.Repositories.Interface;
public interface IReactionRepository
{
    ValueTask<bool> AddRaectionAsync(Guid userId, Guid itemId, bool isLike);
}
