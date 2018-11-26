using quaneu.datalayer.Models.Work;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quaneu.datalayer.Contracts
{
    public interface IWorkRepository : IRepositoryBase<Work>
    {
        Task<IEnumerable<Work>> GetWorksWithImage();
    }
}