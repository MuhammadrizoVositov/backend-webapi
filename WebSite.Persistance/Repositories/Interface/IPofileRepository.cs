using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;

namespace WebSite.Persistance.Repositories.Interface;
public interface IPofileRepository
{
    public ValueTask<Profile>CreateProfile(ProfileDto profile);
    public ValueTask<Profile> UpdateProfile(Guid id,ProfileDto profile);
    public ValueTask<bool> DeleteProfile(Guid id);
    public ValueTask<IEnumerable<Profile>> GetProfile();

}
