using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Models;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface IUserService
{
    ValueTask<IList<AppUser>> GetAsync(bool asNoTrcaking,CancellationToken cancellationToken);
    ValueTask<AppUser?> GetByEmail(string userName, CancellationToken cancellationToken = default);

    ValueTask<AppUser> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default);

    ValueTask<IList<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    ValueTask<AppUser?> GetByUserName(string userName, CancellationToken cancellationToken = default);

    ValueTask<AppUser> CreateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<AppUser> UpdateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<bool> UpdateRangeAsync(IEnumerable<AppUser> user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<bool> DeleteByIdsAsync(IEnumerable<Guid> ids, bool saveChanges = true, CancellationToken cancellationToken = default);
}
