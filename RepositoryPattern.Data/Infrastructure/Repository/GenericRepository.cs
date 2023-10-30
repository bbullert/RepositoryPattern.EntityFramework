using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure
{
    public abstract partial class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public GenericRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Entities = context.Set<TEntity>();
        }
    }
}
