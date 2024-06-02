using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;

namespace WebSite.Infrostructure.Common;
public class ProfileService(IPofileRepository profileRepository,AppIdentityDbContext appIdentityDb) : IProfileService
{
    public async ValueTask<bool> ChangeFirstName(Guid id)
    {
        var changeName= await appIdentityDb.Profile.FindAsync(id);
        if(changeName == null)
        {
            throw new Exception("Profile not found");
        }
      
        await appIdentityDb.SaveChangesAsync();

        return true;
    }

    public async ValueTask<bool> ChangeLastName(Guid id)
    {
        var chnage= await appIdentityDb.Profile.FindAsync(id);
        if(chnage==null)
        {
            throw new Exception("Profile not found lastname");

        }
        
        await appIdentityDb.SaveChangesAsync();
        return true;
    }

    public async ValueTask<bool> ChangePassord(Guid id)
    {
        var passwords= await appIdentityDb.Profile.FindAsync(id);
        if(passwords!=null)
        {
            throw new Exception("Profile not found password");

        }

        await appIdentityDb.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Profile>> GetProfileAsync()
    {
        return await appIdentityDb.Profile.ToListAsync();
    }
}
