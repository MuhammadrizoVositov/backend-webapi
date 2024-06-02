using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Domain.Common.Entity;


namespace WebSite.Persistance.Repositories.Interface;
public interface ICommentRepository
{
    ValueTask<IList<Comment>> GetAllComments(bool asNoTracking=true, CancellationToken cancellationToken = default);
    ValueTask<Comment> GetCommentById(Guid id,bool asNoTracking , CancellationToken cancellationToken = default);
    ValueTask<Comment> AddComment(Comment comment, bool saveChanges,CancellationToken cancellationToken=default );
    ValueTask<Comment> UpdateComment(Comment comment, bool saveChanges,CancellationToken cancellationToken=default);
    ValueTask<bool> DeleteComment(Guid Id , bool saveChanges, CancellationToken cancellationToken = default);
}
