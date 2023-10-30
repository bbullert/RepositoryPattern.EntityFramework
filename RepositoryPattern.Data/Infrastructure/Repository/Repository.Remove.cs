namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity>
    {
        public virtual void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
