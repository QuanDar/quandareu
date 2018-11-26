using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace quaneu.datalayer.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected RepositoryDbContext _quanDarDbContext;
        protected ApplicationDbContext _applicationDbContext;


        protected RepositoryBase(RepositoryDbContext quanDarDbContext, ApplicationDbContext applicationDbContext)
        {
            _quanDarDbContext = quanDarDbContext;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await this._quanDarDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await this._quanDarDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await this._quanDarDbContext.Set<T>().FindAsync(id);
        }

        public T Find(int id)
        {
            return this._quanDarDbContext.Set<T>().Find(id);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await this._quanDarDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public void Add(T entity)
        {
            this._quanDarDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._quanDarDbContext.Set<T>().Update(entity);
        }


        public void Delete(T entity)
        {
            this._quanDarDbContext.Set<T>().Remove(entity);
        }

        public async Task Save()
        {
            await this._quanDarDbContext.SaveChangesAsync();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return this._quanDarDbContext.Set<T>().Any(expression);
        }

        
    }
}
