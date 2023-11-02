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
                throw new ArgumentNullException(nameof(context));

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
                throw new ArgumentNullException(nameof(context));

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
                    auditEntry.Values[propertyName] = property.CurrentValue;
                }

                audits.Add(auditEntry.ToAudit());
            }

            if (audits.Count() > 0)
            {
                context.Set<TAudit>().AddRange(audits);
            }
        }

        //public void SaveAudit(DbContextEventData eventData)
        //{
        //    var context = eventData.Context;
        //    if (context == null)
        //        throw new ArgumentNullException(nameof(context));

        //    var audits = new List<TAudit>();
        //    var entries = context.ChangeTracker.Entries<TEntity>();
        //    var changes = entries.Where(x => x.State == EntityState.Modified).ToList();
        //    foreach (EntityEntry<TEntity> entry in changes)
        //    {
        //        var auditEntry = new AuditEntry<TAudit, TAuditKey, TEntityKey>();
        //        auditEntry.TableName = entry.Metadata.GetTableName();
        //        auditEntry.ModifiedAt = DateTime.UtcNow;

        //        var databaseValues = entry.GetDatabaseValues();
        //        auditEntry.EntityId = (TEntityKey)entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue;
        //        auditEntry.Values = databaseValues.Properties.Select(p => new { Key = p.Name, Value = databaseValues[p.Name] }).ToDictionary(i => i.Key, i => i.Value);

        //        audits.Add(auditEntry.ToAudit());
        //    }

        //    if (audits.Count > 0)
        //    {
        //        context.Set<TAudit>().AddRange(audits);
        //    }
        //}

        //public void SaveAudit(DbContextEventData eventData)
        //{
        //    var context = eventData.Context;
        //    if (context == null)
        //        throw new ArgumentNullException(nameof(context));

        //    var audits = new List<TAudit>();
        //    var entries = context.ChangeTracker.Entries<TEntity>();
        //    foreach (EntityEntry<TEntity> entry in entries)
        //    {
        //        if (entry.State != EntityState.Modified)
        //            continue;
        //        //if (Context.Entry(entity).State == EntityState.Detached)
        //        //{
        //        //    Entities.Attach(entity);
        //        //}
        //        var auditEntry = new AuditEntry<TAudit, TAuditKey, TEntityKey>();
        //        auditEntry.TableName = entry.Metadata.GetTableName();
        //        auditEntry.ModifiedAt = DateTime.UtcNow;

        //        var aa = entry.GetDatabaseValues();
        //        //var originalValues = context.Entry(entry).OriginalValues;
        //        foreach (var property in entry.Properties)
        //        {
        //            if (property.IsTemporary) continue;

        //            if (property.Metadata.IsPrimaryKey())
        //            {
        //                auditEntry.EntityId = (TEntityKey)property.OriginalValue;
        //            }

        //            string propertyName = property.Metadata.Name;
        //            auditEntry.Values[propertyName] = property.OriginalValue;
        //        }
        //        audits.Add(auditEntry.ToAudit());
        //    }

        //    if (audits.Count > 0)
        //    {
        //        context.Set<TAudit>().AddRange(audits);
        //    }
        //}
    }
}