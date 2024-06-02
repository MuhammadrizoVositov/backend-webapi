using Microsoft.EntityFrameworkCore;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;



namespace WebSite.Persistance.Repositories;
public class BookRepository
    : EntityBaseRepository<Book, AppIdentityDbContext>, IBookRepository
{
    private readonly AppIdentityDbContext _identityDbContext;
    public BookRepository(AppIdentityDbContext identityDbContext):base(identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }
    public async ValueTask<Book> AddBookAsync(Book book)
    {
        _identityDbContext.Books.Add(book);
        await _identityDbContext.SaveChangesAsync();
        return book;
    }

   
    public async ValueTask<bool> DeleteBookAsync(Guid id)
    {
        var delete = await _identityDbContext.Books.FindAsync(id);
        if (delete == null)
        {
            return false;
        }
        _identityDbContext.Books.Remove(delete);
        await _identityDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _identityDbContext.Books.ToListAsync();
    }


    public async ValueTask<Book> GetBookByIdAsync(Guid id)
    {
        return await _identityDbContext.Books.FindAsync(id);
    }

    public async ValueTask<bool>UpdateBookAsync(Book book)
    {
        var update =  _identityDbContext.Books.Update(book);
        await _identityDbContext.SaveChangesAsync();
        return true;
    }

}

    
