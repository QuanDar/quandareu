using System.Collections.Generic;
using System.Linq;
using System;
using quaneu.datalayer.Models;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Entities.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace quaneu.datalayer.Repository
{
    public class WordPressTemplateRepository : RepositoryBase<WordPressTemplate>, IWordPressTemplateRepository
    {
        public WordPressTemplateRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
             : base(_quanDarDbContext, _applicationDbContext)
        {
        }

        public async Task<IEnumerable<WordPressTemplate>> GetWordPressTemplates(int amount)
        {
            return _quanDarDbContext.WordPressTemplates.OrderByDescending(wpt => wpt.Id).Take(amount).Include(i => i.Image);
        }

        public async Task<WordPressTemplate> GetWordPressTemplateById(int id)
        {
            return _quanDarDbContext.WordPressTemplates.Include(i => i.Image).Single(w => w.Id == id);
        }

        public async Task<IEnumerable<WordPressTemplateCategoryViewModel>> GetWordPressTemplates()
        {
            var viewModel = from wpt in _quanDarDbContext.WordPressTemplates
                            select new WordPressTemplateCategoryViewModel
                            {
                                Id = wpt.Id,

                                CreationDate = wpt.CreationDate,
                                UpdatedDate = wpt.UpdatedDate,
                                Description = wpt.Description,
                                Image = wpt.Image,
                                ImageId = wpt.ImageId,
                                Title = wpt.Title,

                                Categories =  (from wpc in _quanDarDbContext.WordPressCategories
                                              join wptc in _quanDarDbContext.WordPressTemplateCategories on wpc.Id equals wptc.WordPressCategoryId
                                              where wptc.WordPressTemplateId == wpt.Id
                                              select new WordPressCategory
                                              {
                                                  Id = wpc.Id,
                                                  Category = wpc.Category
                                              }).ToList()
                            };


            return viewModel;
        }
    }
}
