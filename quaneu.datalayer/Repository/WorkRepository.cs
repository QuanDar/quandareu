using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models.Work;

namespace quaneu.datalayer.Repository
{
    internal class WorkRepository : RepositoryBase<Work>, IWorkRepository
    {
        public WorkRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
           : base(_quanDarDbContext, _applicationDbContext)
        {
        }

        public async Task<IEnumerable<Work>> GetWorksWithImage()
        {
            return _quanDarDbContext.Works.Include(i => i.Image);
        }
    }
}