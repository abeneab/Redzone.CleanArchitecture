using Redzone.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Redzone.Application.Persistence
{
    public interface IAsyncRepository<T> where T: BaseAuditModel
    {
       
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> CountAsync();
        Task<IQueryable<T>> GetQueryAsync();
        Task AttachAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> criteria);
        Task<T> FindOneAsync(Expression<Func<T, bool>> criteria);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetQueryAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleAsync(Expression<Func<T, bool>> criteria);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      string includeString = null,
                                      bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool disableTracking = true);
       

    }
}
