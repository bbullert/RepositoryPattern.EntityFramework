namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void RemoveRange(params TEntity[] entities)
        {
            RemoveRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }
    }
}
