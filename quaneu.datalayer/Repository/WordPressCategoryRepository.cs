using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Repository
{
    public class WordPressCategoryRepository : RepositoryBase<WordPressCategory>, IWordPressCategoryRepository
    {
        public WordPressCategoryRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
             : base(_quanDarDbContext, _applicationDbContext)
        {
        }
    }
}
