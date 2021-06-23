using Microsoft.EntityFrameworkCore;
using Redzone.Application.Persistence;
using Redzone.Domain.Seeds;
using Redzone.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Redzone.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseAuditModel
    {
        protected readonly OrderContext _context;
        public RepositoryBase(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AttachAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Attach(entity);
        }

        public async Task<int> CountAsync()
        {
            return await (await GetQueryAsync()).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Expression<Func<T, bool>> criteria)
        {
            IEnumerable<T> data = await FindAsync(criteria);
            foreach(T record in data) 
            {
                await DeleteAsync(record);
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> criteria)
        {
            return await GetQueryAsync(criteria);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> criteria)
        {
            return await (await GetQueryAsync(criteria)).FirstOrDefaultAsync();
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await (await GetQueryAsync()).FirstAsync(predicate);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query =  _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return (await GetQueryAsync()).Where(predicate);
        }

        public async Task<IQueryable<T>> GetQueryAsync()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> criteria)
        {
            return (await GetQueryAsync()).Single(criteria);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
