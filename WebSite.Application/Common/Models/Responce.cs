using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Models;
public class Responce
{
    public int ResponseCode { get; set; }
    public string Result { get; set; }
    public string Message { get; set; }
}
