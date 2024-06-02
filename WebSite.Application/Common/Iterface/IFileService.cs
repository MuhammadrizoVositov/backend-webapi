using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Common.Iterface;
public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file, string pathPrefix="");
    Task DeleteFileAsync(string filePath);
}
