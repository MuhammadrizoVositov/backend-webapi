using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Domain.Common.Entity;
public class ProfileDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAdres { get; set; }
    public string Password { get; set; }
}
