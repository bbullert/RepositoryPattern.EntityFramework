using Microsoft.EntityFrameworkCore.Query;
using RepositoryPattern.Data.Extensions;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual IPagination<TResult> GetPagination<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector, null, null, disableTracking, ignoreQueryFilters)
                .ToPagination(index ?? 1, size ?? 30);
        }

        public virtual IPagination<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector => selector, null, null, disableTracking, ignoreQueryFilters)
                .ToPagination(index ?? 1, size ?? 30);
        }

        public virtual Task<IPagination<TResult>> GetPaginationAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector, null, null, disableTracking, ignoreQueryFilters)
                .ToPaginationAsync(index ?? 1, size ?? 30);
        }

        public virtual Task<IPagination<TEntity>> GetPaginationAsync(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            return Entities.Select(predicate, include, orderBy, selector => selector, null, null, disableTracking, ignoreQueryFilters)
                .ToPaginationAsync(index ?? 1, size ?? 30);
        }
    }
}
