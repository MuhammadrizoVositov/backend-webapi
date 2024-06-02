using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;

namespace WebSite.Application.Common.Iterface;
public interface IProfileService
{
    ValueTask<IEnumerable<Profile>> GetProfileAsync();
    ValueTask<bool> ChangeFirstName(Guid id );
    ValueTask<bool> ChangeLastName(Guid id);
    ValueTask<bool> ChangePassord(Guid id);
}
