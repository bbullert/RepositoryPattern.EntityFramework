using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Entities = context.Set<TEntity>();
        }
    }
}
