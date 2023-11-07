using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryPattern.Data.Extensions;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual int Count(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector => selector, null, null, disableTracking, ignoreQueryFilters)
                .Count();
        }

        public virtual Task<int> CountAsync(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector => selector, null, null, disableTracking, ignoreQueryFilters)
                .CountAsync();
        }
    }
}
