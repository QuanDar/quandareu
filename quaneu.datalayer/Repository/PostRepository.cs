using quaneu.datalayer.Contracts;
using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace quaneu.datalayer.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
             : base(_quanDarDbContext, _applicationDbContext)
        {
        }

        public async Task<IEnumerable<PostBlogViewModel>> GetPosts()
        {
            var viewModel = from wpt in _quanDarDbContext.Posts
                            select new PostBlogViewModel
                            {
                                Id = wpt.Id,

                                CreationDate = wpt.CreationDate,
                                UpdateDate = wpt.UpdateDate,
                                Description = wpt.Description,
                                Image = wpt.Image,
                                ImageId = wpt.ImageId,
                                Title = wpt.Title,

                                Categories = (from wpc in _quanDarDbContext.Blogs
                                              join wptc in _quanDarDbContext.BlogPost on wpc.Id equals wptc.BlogId
                                              where wptc.PostId == wpt.Id
                                              select new BlogViewModel
                                              {
                                                  Id = wpc.Id,
                                                  Category = wpc.Category
                                              }).ToList()
                            };

            return viewModel;
        }
    }
}