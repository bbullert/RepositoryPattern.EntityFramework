using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public virtual void AddRange(params TEntity[] entities)
        {
            Entities.AddRange(entities);
        }

        public virtual IEnumerable<TResult> AddRange<TResult>(Expression<Func<TEntity, TResult>> selector, IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            var query = new List<TEntity>(entities).AsQueryable();
            return query.Select(selector).ToList();
        }

        public virtual IEnumerable<TResult> AddRange<TResult>(Expression<Func<TEntity, TResult>> selector, params TEntity[] entities)
        {
            return AddRange(selector, entities);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return Entities.AddRangeAsync(entities);
        }

        public virtual Task AddRangeAsync(params TEntity[] entities)
        {
            return Entities.AddRangeAsync(entities);
        }

        public virtual async Task<IEnumerable<TResult>> AddRangeAsync<TResult>(Expression<Func<TEntity, TResult>> selector, IEnumerable<TEntity> entities)
        {
            var range = new List<TEntity>();
            foreach (var entity in entities)
            {
                await Entities.AddAsync(entity);
                range.Add(entity);
            }
            var query = range.AsQueryable();
            return query.Select(selector).ToList();
        }

        public virtual Task<IEnumerable<TResult>> AddRangeAsync<TResult>(Expression<Func<TEntity, TResult>> selector, params TEntity[] entities)
        {
            return AddRangeAsync(selector, entities);
        }
    }
}
