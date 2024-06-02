using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.Exeptions;
using WebSite.Persistance.Repositories.Interface;
namespace WebSite.Infrostructure.Common;
public class UserService(IUserRepository userRepository) : IUserService
{
    public async ValueTask<AppUser> CreateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
       return await userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<bool> DeleteByIdsAsync(IEnumerable<Guid> ids, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var users = await GetByIdsAsync(ids);

        await userRepository.DeleteRangeAsync(users);

        return true;
    }

    public ValueTask<IList<AppUser>> GetAsync(bool asNoTracking=true,CancellationToken cancellationToken=default)
    {
        return userRepository.GetAsync(asNoTracking,cancellationToken);
    }

    public ValueTask<AppUser?> GetByEmail(string userName, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByEmail(userName,cancellationToken);
    }

    public async ValueTask<AppUser> GetByIdAsync(Guid id,bool asNoTracking=true ,CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(id,asNoTracking ,cancellationToken);

        if (user is null)
        {
            throw new ArgumentNullException("Username or password is wrong");
        }

        return user;
    }

    public async ValueTask<IList<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var users = userRepository.GetAll().Where(u => ids.Contains(u.Id));

        if (!users.Any())
            throw new ArgumentException("There is no argument");

        return await users.ToListAsync();
    }

    public async ValueTask<AppUser?> GetByUserName(string userName, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByUserNameAsync(userName, cancellationToken);

        return user;
    }

    public async ValueTask<AppUser> UpdateAsync(AppUser user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(user.Id,saveChanges ,cancellationToken);

        return await userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<bool> UpdateRangeAsync(IEnumerable<AppUser> user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await userRepository.UpdateRangeAsync(user);

        return true;
    }
}
