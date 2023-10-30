using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryPattern.Data.Extensions;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity>
    {
        public virtual IEnumerable<TEntity> GetList(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            int? skip = default,
            int? take = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector => selector, skip, take, disableTracking, ignoreQueryFilters).ToList();
        }

        public virtual IEnumerable<TResult> GetList<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? skip = default,
            int? take = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector, skip, take, disableTracking, ignoreQueryFilters).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            int? skip = default,
            int? take = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return await Entities.Select(predicate, orderBy, include, selector => selector, skip, take, disableTracking, ignoreQueryFilters).ToListAsync();
        }

        public virtual async Task<IEnumerable<TResult>> GetListAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? skip = default,
            int? take = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return await Entities.Select(predicate, orderBy, include, selector, skip, take, disableTracking, ignoreQueryFilters).ToListAsync();
        }
    }
}
