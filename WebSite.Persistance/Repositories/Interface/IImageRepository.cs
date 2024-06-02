using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Persistance.Repositories.Interface;
public interface IImageRepository
{
    ValueTask<Image> AddImageAsync(Image image);
    ValueTask<Image> GetImageByIdAsync(int id);
    ValueTask<IEnumerable<Image>> GetAllImagesAsync();
    ValueTask<bool> DeleteImageAsync(int id);
}
