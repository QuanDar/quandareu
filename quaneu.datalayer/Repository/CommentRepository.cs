using System.Collections.Generic;
using System.Linq;
using System;
using quaneu.datalayer.Entities.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Models.Blog;
using quaneu.datalayer.Contracts;

namespace quaneu.datalayer.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
            : base(_quanDarDbContext, _applicationDbContext)
        {
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsCommentViewModel(int postId)
        {
            var viewModel = from comment in _quanDarDbContext.Comments.Where(pid => pid.PostId == postId)
                   select new CommentViewModel
                   {
                       CommentId = comment.CommentId,
                       PostId = comment.PostId,
                       AddDate = comment.AddDate,
                       CommentText = comment.CommentText,
                       UpVotes = comment.UpVotes,
                       DownVotes = comment.DownVotes,
                       ParentCommentId = comment.ParentCommentId
                   };
            return viewModel;
        }
    }
}