namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
