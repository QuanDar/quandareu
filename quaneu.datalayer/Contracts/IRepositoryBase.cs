using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace quaneu.datalayer.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(int id);
        T Find(int id);
        Task<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
        bool Any(Expression<Func<T, bool>> expression);


    }

}
