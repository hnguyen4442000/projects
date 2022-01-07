using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Acrs.DAO
{
  
        public abstract class RepositoryData<T> : IRepositoryData<T> where T : class
        {
            private readonly AcrsDBContext RepositoryContext;

            public RepositoryData(AcrsDBContext repositoryContext)
            {
                this.RepositoryContext = repositoryContext;
            }
           
            public IQueryable<T> FindX(string sql)
            {
               return this.RepositoryContext.Set<T>().FromSqlRaw(sql);
             }

            public IQueryable<T> FindAll()
            {
                   
                return this.RepositoryContext.Set<T>().AsNoTracking();
            }

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
            }

            public void Create(T entity)
            {
                this.RepositoryContext.Set<T>().Add(entity);
                RepositoryContext.SaveChanges();
                
            }

            public void Update(T entity)
            {
                this.RepositoryContext.Set<T>().Update(entity);
            }

            public void Delete(T entity)
            {
                this.RepositoryContext.Set<T>().Remove(entity);
            }
        }
    
}
