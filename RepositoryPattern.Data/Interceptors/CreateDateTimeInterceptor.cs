using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Interceptors
{
    public class CreateDateTimeInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges
            (DbContextEventData eventData, 
            InterceptionResult<int> result)
        {
            OnSavingChanges(eventData);
            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            OnSavingChanges(eventData);
            return new ValueTask<InterceptionResult<int>>(result);
        }

        public void OnSavingChanges(DbContextEventData eventData)
        {
            PropagateProperties(eventData);
        }

        public void PropagateProperties(DbContextEventData eventData)
        {
            var context = eventData.Context;
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var entries = context.ChangeTracker.Entries<ICreatedAt>();
            foreach (EntityEntry<ICreatedAt> entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
