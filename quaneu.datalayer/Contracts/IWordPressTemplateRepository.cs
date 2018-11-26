

using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quaneu.datalayer.Contracts
{
    public interface IWordPressTemplateRepository : IRepositoryBase<WordPressTemplate>
    {
        Task<IEnumerable<WordPressTemplateCategoryViewModel>> GetWordPressTemplates();
        Task<WordPressTemplate> GetWordPressTemplateById(int id);
        Task<IEnumerable<WordPressTemplate>> GetWordPressTemplates(int amount);
    }
}
