using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TResult Add<TResult>(Expression<Func<TEntity, TResult>> selector, TEntity entity);
        Task AddAsync(TEntity entity);
        Task<TResult> AddAsync<TResult>(Expression<Func<TEntity, TResult>> selector, TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void AddRange(params TEntity[] entities);
        IEnumerable<TResult> AddRange<TResult>(Expression<Func<TEntity, TResult>> selector, IEnumerable<TEntity> entities);
        IEnumerable<TResult> AddRange<TResult>(Expression<Func<TEntity, TResult>> selector, params TEntity[] entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task AddRangeAsync(params TEntity[] entities);
        Task<IEnumerable<TResult>> AddRangeAsync<TResult>(Expression<Func<TEntity, TResult>> selector, IEnumerable<TEntity> entities);
        Task<IEnumerable<TResult>> AddRangeAsync<TResult>(Expression<Func<TEntity, TResult>> selector, params TEntity[] entities);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        TResult? Get<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<TResult?> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        IEnumerable<TResult> GetList<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, int? skip = null, int? take = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, int? skip = null, int? take = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        IPagination<TEntity> GetPagination(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? index = null, int? size = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        IPagination<TResult> GetPagination<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, int? index = null, int? size = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<IPagination<TEntity>> GetPaginationAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? index = null, int? size = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        Task<IPagination<TResult>> GetPaginationAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TResult>> selector = null, int? index = null, int? size = null, bool disableTracking = true, bool ignoreQueryFilters = false);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRange(params TEntity[] entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void UpdateRange(params TEntity[] entities);
    }
}