using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure
{
    public partial class Repository<TEntity>
    {
        public virtual void Update(TEntity entity)
        {
            //Console.WriteLine(Context.Entry(entity).State);
            //if (Context.Entry(entity).State == EntityState.Detached)
            //{
            //    Entities.Attach(entity);
            //    Context.Entry(entity).State = EntityState.Added;
            //}
            //else
            //{
            //    Entities.Update(entity);
            //}
            ////Context.Entry(entity).State = EntityState.Modified;
            ////Entities.Update(entity);
            //Console.WriteLine(Context.Entry(entity).State);
            //if (Context.Entry(entity).State == EntityState.Modified)
            //{
            //}
            Entities.Update(entity);
        }
    }
}
