using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryPattern.Data.Extensions;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity>
    {
        public virtual TEntity? Get(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector => selector, null, null, disableTracking, ignoreQueryFilters).FirstOrDefault();
        }

        public virtual TResult? Get<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector, null, null, disableTracking, ignoreQueryFilters).FirstOrDefault();
        }

        public virtual Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector => selector, null, null, disableTracking, ignoreQueryFilters).FirstOrDefaultAsync();
        }

        public virtual Task<TResult?> GetAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, orderBy, include, selector, null, null, disableTracking, ignoreQueryFilters).FirstOrDefaultAsync();
        }
    }
}
