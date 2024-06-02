using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Iterface;
public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);


}
