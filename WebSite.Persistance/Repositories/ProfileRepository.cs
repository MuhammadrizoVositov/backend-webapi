using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;

namespace WebSite.Persistance.Repositories;
public class ProfileRepository : EntityBaseRepository<Profile, AppIdentityDbContext>, IPofileRepository
{
    private readonly AppIdentityDbContext _context;
    public ProfileRepository(AppIdentityDbContext context) : base(context)
    {
        _context = context;
    }

    public async ValueTask<Profile> CreateProfile(ProfileDto profile)
    {
        var createAcoount = new Profile()
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            EmailAdres = profile.EmailAdres,
            Password = profile.Password,
        };
        await _context.Profile.AddAsync(createAcoount);
        await _context.SaveChangesAsync();
        return createAcoount;
    }

    public async ValueTask<bool> DeleteProfile(Guid id)
    {
        var acoount =  _context.Profile.FirstOrDefault(l=> l.Id == id);
        if (acoount != null)
        {
            _context.Profile.Remove(acoount);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async ValueTask<IEnumerable<Profile>> GetProfile()
    {
        var accounts = await _context.Profile.ToListAsync();

        return accounts;
    }

    public async ValueTask<Profile> UpdateProfile(Guid id, ProfileDto profile)
    {
        var profil =  _context.Profile.FirstOrDefault(c=>c.Id == id);
        if(profile != null)
        {
            profil.FirstName = profile.FirstName;
            profil.LastName = profile.LastName;
            profile.EmailAdres = profile.EmailAdres;
            profile.Password = profile.Password;
        }
        return profil;
    }
}
