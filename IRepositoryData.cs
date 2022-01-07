using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace Acrs.DAO
{
    public interface IRepositoryData<T>   
    {        
            IQueryable<T> FindAll();
            IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
        
    }
}
