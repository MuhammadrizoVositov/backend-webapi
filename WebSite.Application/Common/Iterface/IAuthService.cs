using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Models;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails,CancellationToken cancellationToken=default);

    ValueTask<string> LoginAsync(LoginDetails loginDetails,CancellationToken cancellationToken=default);
}
