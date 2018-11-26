using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace quaneu.datalayer.Contracts
{
     public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<IEnumerable<CommentViewModel>> GetCommentsCommentViewModel(int postId);

    }
}
