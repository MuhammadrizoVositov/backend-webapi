using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Enum;
using WebSite.Domain.Common.Tokens;


namespace WebSite.Application.Common.Iterface;
public interface IVerificationTokenGenaratorService
{
    string GenerateToken(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}
