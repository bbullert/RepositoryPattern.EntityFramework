using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Extensions
{
    public static partial class IQueryableExtensions
    {
        public static IQueryable<TResult> Select<TEntity, TResult>(
            this IQueryable<TEntity> query,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Expression<Func<TEntity, TResult>> selector = default,
            int? skip = default,
            int? take = default,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
            where TEntity : class
        {
            if (predicate != null) query = query.Where(predicate);

            if (include != null) query = include(query);

            if (orderBy != null) query = orderBy(query);

            if (include != null) query = include(query);

            if (selector == null) selector = entity => (TResult)(object)entity;

            if (skip != null) query = query.Skip(skip.Value);

            if (take != null) query = query.Take(take.Value);

            if (disableTracking) query = query.AsNoTracking();

            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

            return query.Select(selector);
        }
    }
}
