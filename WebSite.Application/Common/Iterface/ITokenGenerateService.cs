using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface ITokenGenerateService
{
    string GetToken(AppUser user);

    JwtSecurityToken GetJwtSecurityToken(AppUser user);

    List<Claim> GetClaims(AppUser user);
}
