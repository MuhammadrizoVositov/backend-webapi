using Microsoft.AspNetCore.Identity;

namespace WebSite.Domain.Common.Entity;
public class AppUser :Entity
{
    public string FirstName { get; set; } = default!;
    public string UserName {  get; set; }
    public string LastName { get; set; } = default!;
    public string? ImagePath {  get; set; }
    public string PasswordHash { get; set; } = default!;
    public required string EmailAdress { get; set; }
    public DateTimeOffset RegistretionDate { get; set; }
    public DateTimeOffset LastOnlineDate { get; set; }
    public bool IsActive { get; set; }
}
