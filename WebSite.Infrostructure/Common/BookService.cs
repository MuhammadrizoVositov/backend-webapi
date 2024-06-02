using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.Repositories.Interface;

namespace WebSite.Infrostructure.Common;
public class BookService(IBookRepository bookRepository,IFileService fileService) : IBookService
{
    public async ValueTask<bool> DeleteBookAsync(Guid id)
    {
        await bookRepository.DeleteBookAsync(id);
        return true;
    }

    public async ValueTask<IEnumerable<Book>> GetAllBooksAsync()
    {
        var getall=await bookRepository.GetAllBooksAsync();
        return getall;
    }

    public async ValueTask<Book> GetBookByIdAsync(Guid id)
    {
        var byid=await bookRepository.GetBookByIdAsync(id);
        return byid;
    }

    public async ValueTask<bool> UpdateBookAsync(Book book)
    {
        await bookRepository.UpdateBookAsync(book);
        return true;
         
    }

    public async ValueTask<Book> UploadBookAsync(BookUploadModel model)
    {
        var bookuplaod = new Book
        {
            Author = model.Author,
            Title = model.Title,
            Description = model.Description,
            FilePath = await fileService.UploadFileAsync(model.File)
        };
        await bookRepository.AddBookAsync(bookuplaod);
        return bookuplaod;
      
    }
}
