using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;

namespace WebSite.Persistance.Repositories;
public class UserRepository(AppIdentityDbContext identityDb) : EntityBaseRepository<AppUser, AppIdentityDbContext>(identityDb), IUserRepository
{
    public async ValueTask<bool> DeleteRangeAsync(IEnumerable<AppUser> users, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.RemoveRange(users);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public IQueryable<AppUser> GetAll()
    {
        return DbContext.Users.AsQueryable();
    }

    public ValueTask<IList<AppUser>> GetAsync(bool asNoTracking=true,CancellationToken cancellationToken=default) =>
        base.GetAsync(asNoTracking,cancellationToken);


    public ValueTask<AppUser?> GetByIdAsync(Guid id,bool asNoTracking=true, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(id,asNoTracking ,cancellationToken);


    public async ValueTask<AppUser?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        var s = await DbContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
        return s;
    }

    public async ValueTask<bool> UpdateRangeAsync(IEnumerable<AppUser> user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Users.UpdateRange(user);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async ValueTask<AppUser> CreateAsync(AppUser user, bool saveChanges, CancellationToken cancellationToken)
    {
         
         var result = await base.CreateAsync(user, saveChanges, cancellationToken);
         //await DbContext.SaveChangesAsync(cancellationToken);

        return result;

    }

    public ValueTask<AppUser> DeleteAsync(AppUser user, bool saveChanges, CancellationToken cancellationToken)=> base.DeleteAsync(user, saveChanges, cancellationToken);


    public ValueTask<AppUser>UpdateAsync(AppUser user, bool saveChanges, CancellationToken cancellationToken)=> 
        base.UpdateAsync(user, saveChanges, cancellationToken);

    public async ValueTask<AppUser?> GetByEmail(string userName, CancellationToken cancellationToken = default)
    {
        var s = await DbContext.Users.FirstOrDefaultAsync(u => u.EmailAdress.Equals(userName));
        return s;
    }
}
