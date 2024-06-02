using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using WebSite.Application.Common.Iterface;
using WebSite.Application.Common.Models;
using WebSite.Domain.Common.Entity;


namespace WebSite.Infrostructure.Common;
public class AuthService(IUserService userService,
    ITokenGenerateService tokenGenerateService) : IAuthService
{


    public async ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default)
    {
        var founduser = await userService.GetByEmail(loginDetails.EmailAddress);
        if (founduser is null)
        {
            throw new ArgumentException("Passwor or username isn not correct");
        }
        if (founduser.IsActive)
        {
            throw new InvalidOperationException("Your account vas blocked");
        }
        founduser.LastOnlineDate = DateTimeOffset.UtcNow;
        await userService.UpdateAsync(founduser,true);
        return tokenGenerateService.GetToken(founduser);
    }

 

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails,CancellationToken cancellationToken = default)
    {
      
        if (string.IsNullOrWhiteSpace(registrationDetails.EmailAddress) || !IsValidEmail(registrationDetails.EmailAddress))
        {
            throw new ArgumentException("Invalid email address provided.");
        }
      
        var user = new AppUser
        {
          FirstName = registrationDetails.FirstName,
          LastName = registrationDetails.LastName,
          UserName = registrationDetails.UserName,
          EmailAdress= registrationDetails.EmailAddress,
          PasswordHash= registrationDetails.Password,
        };
        await userService.CreateAsync(user);
        return true;
       
    } 

    private bool IsValidEmail(string emailAddress)
    {
        return true;
    }
}
