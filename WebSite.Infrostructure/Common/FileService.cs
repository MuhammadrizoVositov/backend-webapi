using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Iterface;

namespace WebSite.Infrostructure.Common;
public class FileService(IConfiguration configuration) : IFileService
{

    public async Task<string> UploadFileAsync(IFormFile file, string pathPrefix = "")
    {
       var uploadFile = configuration["UploadFolder"]?? Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads");
       // Directory.CreateDirectory(UploadFolder);

        var filename=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
        var filePath=Path.Combine(uploadFile,filename,pathPrefix);
        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;

    }
    public async Task DeleteFileAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath)); 
        }
    }


}
