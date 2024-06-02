using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Domain.Common.Tokens;


namespace WebSite.Infrostructure.Common;
public class TokenGenerateService(IOptions<JwtSettings> jwtSettings) : ITokenGenerateService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public List<Claim> GetClaims(AppUser user)
    {
        return new List<Claim>()
       {
            new("UserId", user.Id.ToString()),
           new (ClaimTypes.Email,user.EmailAdress),
       };
    }

    public JwtSecurityToken GetJwtSecurityToken(AppUser user)
    {
        var claims = GetClaims(user);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        return new JwtSecurityToken
            (
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentails
            );
    }

    public string GetToken(AppUser user)
    {
        var jwtToken = GetJwtSecurityToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
}
