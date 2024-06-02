using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Application.Common.Iterface;
using WebSite.Domain.Common.Entity;
using WebSite.Persistance.Repositories.Interface;


namespace WebSite.Infrostructure.Common;
public class CommentService(ICommentRepository commentRepository) : ICommentService
{
    public async ValueTask<Comment> AddComment(Comment comment, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await commentRepository.AddComment(comment, asNoTracking, cancellationToken);
    }

    public async ValueTask<bool> DaleteComment(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await commentRepository.DeleteComment(id,asNoTracking,cancellationToken);
    }

    public async ValueTask<Comment?> GetCommentById(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await commentRepository.GetCommentById(id,asNoTracking,cancellationToken);
    }

    public async ValueTask<List<Comment>> GetComments()
    {
        return (List<Comment>)await commentRepository.GetAllComments();
    }

    public async ValueTask<Comment> UpDate(Comment comment, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return await commentRepository.UpdateComment(comment, asNoTracking,cancellationToken);
    }
}
