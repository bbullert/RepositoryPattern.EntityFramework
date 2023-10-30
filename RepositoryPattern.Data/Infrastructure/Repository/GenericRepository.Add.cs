using System.Linq.Expressions;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual TResult Add<TResult>(Expression<Func<TEntity, TResult>> selector, TEntity entity)
        {
            Entities.Add(entity);
            var query = new List<TEntity>() { entity }.AsQueryable();
            return query.Select(selector).First();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public virtual async Task<TResult> AddAsync<TResult>(Expression<Func<TEntity, TResult>> selector, TEntity entity)
        {
            await Entities.AddAsync(entity);
            var query = new List<TEntity>() { entity }.AsQueryable();
            return query.Select(selector).First();
        }
    }
}
