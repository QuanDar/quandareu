using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Repository
{
    class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
            : base(_quanDarDbContext, _applicationDbContext)
        {
        }
    }
}
