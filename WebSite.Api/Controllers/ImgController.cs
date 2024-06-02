using Microsoft.AspNetCore.Mvc;
using Nest;
using WebSite.Application.Common.Iterface;

namespace WebSite.Api.Controllers;
[Route("api/image")]
[ApiController]
public class ImageController(IImageService imageService, IWebHostEnvironment environment) : ControllerBase
{
    //[HttpPost("upload")]
    //public async ValueTask<IActionResult> UploadImage(IFormFile formFile)
    //{
    //    try
    //    {
    //        var img = await imageService.UploadImageAsync(formFile);
    //        return Ok(img);

    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    [HttpPut("UploadImage")]
    public async Task<IActionResult> UploadImage(IFormFile formFile)
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

                return Ok(imagepath);
            }
        }
        catch
        {
            return NotFound("yuklanmadi");
        }
        
        
    }

    [NonAction]
    private string GetFilepath()
    {
        return environment.WebRootPath + "\\Users\\Uplauds\\";
    }

    [HttpGet("id")]
    public async ValueTask<IActionResult> GetImage(int id)
    {
        var image = await imageService.GetImageByIdAsync(id);
        if (image == null)
        {
            return NotFound();
        }
        var filebite = await System.IO.File.ReadAllBytesAsync(image.FilePath);
        return File(filebite, "img", image.FileName);
    }

    [HttpGet("Getalls")]
    public async ValueTask<IActionResult> GetAllImage()
    {
        var img = await imageService.GetAllImagesAsync();
        return Ok(img);
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteImages(int id)
    {
        var delete = await imageService.DeleteImageAsync(id);
        if (!delete)
        {
            return NotFound();
        }
        return NoContent();
    }
}
