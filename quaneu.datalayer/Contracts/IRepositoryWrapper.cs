using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Contracts
{
    public interface IRepositoryWrapper
    {
        IImageRepository Images { get; }
        IWordPressTemplateRepository WordPressTemplates { get; }

        IWordPressCategoryRepository WordPressCategories { get; }
        IWorkRepository Works { get; }
        IBlogRepository Blogs { get; }
        IPostRepository Posts { get; }

        ICommentRepository Comments { get; }

    }
}
