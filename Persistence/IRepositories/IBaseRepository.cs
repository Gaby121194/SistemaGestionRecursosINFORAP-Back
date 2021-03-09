using INFORAP.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace INFORAP.API.Persistence.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> ListBy();
        Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate);
        Task<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(object id);
        Task<T> Insert(T entity);
        Task<T> Update(object id, T entity);
        Task<T> Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task RemoveRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task Remove(object id);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}
