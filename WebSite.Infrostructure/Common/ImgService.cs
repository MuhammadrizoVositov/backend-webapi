using Microsoft.AspNetCore.Http;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Infrostructure.Common;
public class ImageService(
    IImageRepository imageRepository
    ) : IImageService
{
    public async ValueTask<bool> DeleteImageAsync(int id)
    {
        var img=await imageRepository.GetImageByIdAsync(id);
        if(img == null)
        {
            return false;
        }
        if(File.Exists(img.FilePath))
        {
            File.Delete(img.FilePath);
        }
        return await imageRepository.DeleteImageAsync(id);
    }

    public async ValueTask<IEnumerable<Image>> GetAllImagesAsync()
    {
        return await imageRepository.GetAllImagesAsync();
    }

    public async ValueTask<Image> GetImageByIdAsync(int id)
    {
        return await imageRepository.GetImageByIdAsync(id);
    }

    public async ValueTask<Image> UploadImageAsync(IFormFile file)
    {
        if(file == null || file==null)
        {
            throw new ArgumentException("Invalid file");
        }
        var fileName = Path.GetFileName(file.FileName);
        var filePath=Path.Combine("Users/","Uplauds",fileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var image = new Image
        {
            FileName = fileName,
            FilePath = filePath,
            UploadedAt = DateTime.UtcNow,
        };
        return await imageRepository.AddImageAsync(image);

    }
}
