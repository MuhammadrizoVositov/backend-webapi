using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Application.Common.Iterface;
public interface ICommentService
{
    ValueTask<List<Comment>> GetComments();
    ValueTask<Comment?> GetCommentById(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default);
    ValueTask<Comment> AddComment(Comment comment,bool asNoTracking=true,CancellationToken cancellationToken=default);
    ValueTask<Comment>UpDate(Comment comment,bool asNoTracking=true,CancellationToken cancellationToken=default);
    ValueTask<bool> DaleteComment(Guid Id, bool asNoTracking = true, CancellationToken cancellationToken = default);
}
