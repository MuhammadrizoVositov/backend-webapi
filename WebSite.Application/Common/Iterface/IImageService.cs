using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface IImageService
{
    ValueTask<Image> UploadImageAsync(IFormFile file);
    ValueTask<Image> GetImageByIdAsync(int id);
    ValueTask<IEnumerable<Image>> GetAllImagesAsync();
    ValueTask<bool> DeleteImageAsync(int id);
}
