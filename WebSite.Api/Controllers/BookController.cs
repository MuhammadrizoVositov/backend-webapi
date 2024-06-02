using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;

namespace WebSite.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet("getAll")]
    public async ValueTask<IActionResult>GetAllAsync()
    {
        var getAll= await bookService.GetAllBooksAsync();
        return Ok(getAll);
    }
    [HttpGet("getBiId")]
    public async ValueTask<IActionResult>GetByIdAsync(Guid id)
    {
        var getbyid=await bookService.GetBookByIdAsync(id);
        return Ok(getbyid);
    }
    [HttpPatch("update")]
    public async ValueTask<IActionResult>UpdateAsync(Book book)
    {
        var update=await bookService.UpdateBookAsync(book);
        return Ok(update);
    }
    [HttpPost("uploadBooks")]
    public async ValueTask<IActionResult>UpLoadBooks(BookUploadModel bookUpload)
    {
        var addbook= await bookService.UploadBookAsync(bookUpload);
        return Ok(addbook);
    }
    [HttpDelete("deleteBooks")]
    public async ValueTask<IActionResult>DeleteBooks(Guid id)
    {
        var delete = await bookService.DeleteBookAsync(id);
        return Ok(delete);
    }

}
