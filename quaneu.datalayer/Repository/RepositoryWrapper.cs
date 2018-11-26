using quaneu.datalayer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryDbContext _quandarContext;
        private ApplicationDbContext _applicationDbContext;

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _applicationDbContext; }
        }


        public RepositoryDbContext QuanDarDbContext
        {
            get { return _quandarContext; }
        }

        private IImageRepository _image;
        private IWordPressTemplateRepository _wordpressTemplate;
        private IWordPressCategoryRepository _wordPressCategory;
        private IWorkRepository _work;
        private IBlogRepository _blog;
        private IPostRepository _post;
        private ICommentRepository _comment;

        public RepositoryWrapper(RepositoryDbContext quandarContext)
        {
            _quandarContext = quandarContext;
        }

        public IImageRepository Images
        {
            get
            {
                if (_image == null)
                {
                    _image = new ImageRepository(_quandarContext, _applicationDbContext);
                }

                return _image;
            }
        }

        public IWordPressTemplateRepository WordPressTemplates
        {
            get
            {
                if (_wordpressTemplate == null)
                {
                    _wordpressTemplate = new WordPressTemplateRepository(_quandarContext, _applicationDbContext);
                }

                return _wordpressTemplate;
            }
        }

        public IWordPressCategoryRepository WordPressCategories
        {
            get
            {
                if (_wordPressCategory == null)
                {
                    _wordPressCategory = new WordPressCategoryRepository(_quandarContext, _applicationDbContext);
                }

                return _wordPressCategory;
            }
        }
        public IBlogRepository Blogs
        {
            get
            {
                if (_blog == null)
                {
                    _blog = new BlogRepository(_quandarContext, _applicationDbContext);
                }

                return _blog;
            }
        }
        public IPostRepository Posts
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_quandarContext, _applicationDbContext);
                }

                return _post;
            }
        }
        public IWorkRepository Works
        {
            get
            {
                if (_work == null)
                {
                    _work = new WorkRepository(_quandarContext, _applicationDbContext);
                }

                return _work;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_comment == null)
                {
                    _comment = new CommentRepository(_quandarContext, _applicationDbContext);
                }

                return _comment;
            }
        }
    }
}

