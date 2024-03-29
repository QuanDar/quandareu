﻿using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quaneu.datalayer.Contracts
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
    }
}