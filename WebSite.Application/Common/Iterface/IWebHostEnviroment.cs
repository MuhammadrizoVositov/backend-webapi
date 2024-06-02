using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Iterface;
public interface IWebHostEnviroment:IHostEnvironment
{
    string WeebRootPath { get; set; }

    IFileProvider WebRootFileProvider { get; set; }
}
