using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Interceptors
{
    public class AuditInterceptor<TAudit, TAuditKey, TEntity, TEntityKey> : SaveChangesInterceptor
        where TAudit : class, IGenericAudit<TAuditKey, TEntityKey>
        where TEntity : class
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        public override InterceptionResult<int> SavingChanges
            (DbContextEventData eventData, 
            InterceptionResult<int> result)
        {
            OnSavingChanges(eventData);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            OnSavingChanges(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void OnSavingChanges(DbContextEventData eventData)
        {
            PropagateProperties(eventData);
            SaveAudit(eventData);
        }

        public void PropagateProperties(DbContextEventData eventData)
        {
            var context = eventData.Context;
            if (context == null)
                throw new ArgumentException($"{nameof(context)} was null.");

            var created = context.ChangeTracker.Entries<ICreatedAt>();
            foreach (EntityEntry<ICreatedAt> entry in created)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }

            var updated = context.ChangeTracker.Entries<ILastModifiedAt>();
            foreach (EntityEntry<ILastModifiedAt> entry in updated)
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                }
            }
        }

        public void SaveAudit(DbContextEventData eventData)
        {
            var context = eventData.Context;
            if (context == null)
                throw new ArgumentException($"{nameof(context)} was null.");

            var audits = new List<TAudit>();
            var entries = context.ChangeTracker.Entries<TEntity>();
            var changed = entries.Where(x => 
                    x.State == EntityState.Added || 
                    x.State == EntityState.Modified
                ).ToList();

            foreach (EntityEntry<TEntity> entry in changed)
            {
                var auditEntry = new AuditEntry<TAudit, TAuditKey, TEntityKey>();
                auditEntry.TableName = entry.Metadata.GetTableName();
                auditEntry.ModifiedAt = DateTime.UtcNow;

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary) continue;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.EntityId = (TEntityKey)property.CurrentValue;
                    }

                    string propertyName = property.Metadata.Name;
                    auditEntry.Changes[propertyName] = property.CurrentValue;
                }

                audits.Add(auditEntry.ToAudit());
            }

            if (audits.Count > 0)
            {
                context.Set<TAudit>().AddRange(audits);
            }
        }
    }
}
