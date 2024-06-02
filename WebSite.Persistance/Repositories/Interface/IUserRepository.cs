using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;

namespace WebSite.Persistance.Repositories.Interface;
public interface IUserRepository
{
    IQueryable<AppUser> GetAll();
    ValueTask<AppUser?> GetByEmail(string userName, CancellationToken cancellationToken = default);
    ValueTask<IList<AppUser>> GetAsync(bool asNoTracking=true,CancellationToken cancellationToken=default);
    ValueTask<AppUser?> GetByIdAsync(Guid id,bool asNoTracking=true ,CancellationToken cancellationToken = default);
    ValueTask<AppUser?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    ValueTask<AppUser> CreateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<AppUser> UpdateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<bool> UpdateRangeAsync(IEnumerable<AppUser> user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<AppUser> DeleteAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<bool> DeleteRangeAsync(IEnumerable<AppUser> users, bool saveChanges = true, CancellationToken cancellationToken = default);
}
