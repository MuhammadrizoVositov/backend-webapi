using Microsoft.EntityFrameworkCore;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.DataContext;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Persistance.Repositories;
public class CommentRepository : EntityBaseRepository<Comment,AppIdentityDbContext>, ICommentRepository
{
    private readonly AppIdentityDbContext _context;

    public CommentRepository(AppIdentityDbContext context) : base(context)
    {
        this._context = context;
    }
    public ValueTask<Comment> AddComment(Comment comment, bool saveChanges, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(comment,saveChanges, cancellationToken);
    }

    public async ValueTask<bool> DeleteComment(Guid id, bool saveChanges, CancellationToken cancellationToken = default)
    {
        var result = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (result != null)
        {
            _context.Comments.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public  async ValueTask<IList<Comment>> GetAllComments(bool asNoTracking = false,CancellationToken cancellationToken=default)
    {
        return await base.Get(null,asNoTracking).ToListAsync(cancellationToken);
    }

    public async ValueTask<Comment?> GetCommentById(Guid id,bool asNoTracking=true ,CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, asNoTracking,cancellationToken);
    }

    public async ValueTask<Comment> UpdateComment(Comment comment, bool saveChanges, CancellationToken cancellationToken = default)
    {
       var baseComment = await _context.Comments
            
            .FirstOrDefaultAsync(a => a.Id == comment.Id)
            ?? throw new Exception($"comment with id {comment.Id} not found");

        baseComment.CreatedDate = comment.CreatedDate;
        baseComment.Content= comment.Content;
        
        return await base.UpdateAsync(comment, saveChanges,cancellationToken);
    }
}
