using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Persistance.Repositories;
public class ImageRepsotory : IImageRepository
{
    private readonly AppIdentityDbContext _dbContext;
    public ImageRepsotory(AppIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask<Image> AddImageAsync(Image image)
    {
        _dbContext.Images.Add(image);
        await _dbContext.SaveChangesAsync();
        return image;
    }

    public async ValueTask<bool> DeleteImageAsync(int id)
    {
        var image = await _dbContext.Images.FindAsync(id);
        if (image==null)
        {
            return false;
        }
        _dbContext.Images.Remove(image);
        return true;

       
    }

    public async ValueTask<IEnumerable<Image>> GetAllImagesAsync()
    {
        return await _dbContext.Images.ToListAsync();
    }

    public async ValueTask<Image> GetImageByIdAsync(int id)
    {
        return await _dbContext.Images.FindAsync(id);
    }
}
