namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void UpdateRange(params TEntity[] entities)
        {
            UpdateRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
        }
    }
}
