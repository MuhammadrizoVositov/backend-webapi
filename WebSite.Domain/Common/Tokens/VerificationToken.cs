using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Enum;

namespace WebSite.Domain.Common.Tokens;
public class VerificationToken
{
    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }
}
