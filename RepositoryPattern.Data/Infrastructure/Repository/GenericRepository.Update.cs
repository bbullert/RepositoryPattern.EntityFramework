using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class GenericRepository<TEntity>
    {
        public virtual void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
