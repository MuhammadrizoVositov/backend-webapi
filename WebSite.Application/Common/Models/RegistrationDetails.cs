using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Models;
public class RegistrationDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName {  get; set; }
    public string EmailAddress { get; set; } = default!;
    public string Password { get; set; } = default!;
}
