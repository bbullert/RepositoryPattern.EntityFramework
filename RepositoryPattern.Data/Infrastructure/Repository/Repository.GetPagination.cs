using Microsoft.EntityFrameworkCore.Query;
using RepositoryPattern.Data.Extensions;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity>
    {
        public virtual IPagination<TResult> GetPagination<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            var query = Entities.Select(predicate, orderBy, include, selector, null, null, disableTracking, ignoreQueryFilters);
            return query.ToPagination(index ?? 1, size ?? 30);
        }

        public virtual IPagination<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            var query = Entities.Select(predicate, orderBy, include, selector => selector, null, null, disableTracking, ignoreQueryFilters);
            return query.ToPagination(index ?? 1, size ?? 30);
        }

        public virtual Task<IPagination<TResult>> GetPaginationAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            var query = Entities.Select(predicate, orderBy, include, selector, null, null, disableTracking, ignoreQueryFilters);
            return query.ToPaginationAsync(index ?? 1, size ?? 30);
        }

        public virtual Task<IPagination<TEntity>> GetPaginationAsync(
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            int? index = default,
            int? size = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            var query = Entities.Select(predicate, orderBy, include, selector => selector, null, null, disableTracking, ignoreQueryFilters);
            return query.ToPaginationAsync(index ?? 1, size ?? 30);
        }
    }
}
