using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebSite.Application.Common.Models;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;


namespace WebSite.Api.Controllers;
[Route("api/items")]
[ApiController]
public class ItemsController(AppIdentityDbContext identityDb, IWebHostEnvironment _env) : ControllerBase
{


    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await identityDb.Items.Include(x => x.Comments).ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem( ItemDto itemdto )
    {

        var imagePAth = await UploadImageAndGetImageUrl(itemdto.Image);

        var item = new Item
        {
            Name = itemdto.Name,
            Description = itemdto.Description,
            CreateAt = DateTimeOffset.UtcNow,
            ImageUrl = imagePAth,
            UserId= itemdto.UserId,
            ItemTypeId = itemdto.ItemTypeId,
            
        };

        await  identityDb.Items.AddAsync(item);

        var result = await identityDb.SaveChangesAsync();
        return Ok(result > 0);
    }

    private async Task<string> UploadImageAndGetImageUrl(IFormFile formFile)
    {

        try
        {
            string Filepath = GetFilepath();

            if (!System.IO.Directory.Exists(Filepath))
            {
                System.IO.Directory.CreateDirectory(Filepath);
            }

            string imagepath = Filepath + "\\" + formFile.FileName;
            if (System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
            using (FileStream stream = System.IO.File.Create(imagepath))
            {
                await formFile.CopyToAsync(stream);

                return imagepath;
            }
        }
        catch
        {
            return "hato";
        }


    }

    private string GetFilepath()
    {
        return _env.WebRootPath + "\\Users\\Uplauds\\";
    }
}


public class SetImage
{
    public IFormFile MyImage { get; set; }
}
