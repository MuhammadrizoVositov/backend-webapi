using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface IBookService
{
    ValueTask<Book> UploadBookAsync(BookUploadModel model);
    ValueTask <bool>UpdateBookAsync(Book book);
    ValueTask<Book> GetBookByIdAsync(Guid id);
    ValueTask<IEnumerable<Book>> GetAllBooksAsync();
    ValueTask<bool> DeleteBookAsync(Guid id);
}
