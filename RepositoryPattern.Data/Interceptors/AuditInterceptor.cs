using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RepositoryPattern.Data.Infrastructure;
using System.Text.Json;

namespace RepositoryPattern.Data.Interceptors
{
    public class AuditInterceptor<TAuditKey, TAudit, TEntityKey, TEntity> : SaveChangesInterceptor
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
            SaveAudit(eventData);
        }

        public void SaveAudit(DbContextEventData eventData)
        {
            var context = eventData.Context;
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var audits = new List<TAudit>();
            var entries = context.ChangeTracker.Entries<TEntity>();
            foreach (EntityEntry<TEntity> entry in entries)
            {
                //var auditEntry = new AuditEntry();
                //auditEntry.TableName = entry.Metadata.GetTableName();
                //auditEntry.ModifyDateTime = DateTime.UtcNow;
                var audit = (TAudit)Activator.CreateInstance(typeof(TAudit));
                audit.TableName = entry.Metadata.GetTableName();
                audit.ModifyDateTime = DateTime.UtcNow;
                var values = new Dictionary<string, object>();

                if (entry.State == EntityState.Added)
                {
                    //entityEntry.Entity.CreatedDate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    foreach (var property in entry.Properties)
                    {
                        if (property.IsTemporary) continue;

                        if (property.Metadata.IsPrimaryKey())
                        {
                            audit.EntityId = (TEntityKey)property.CurrentValue;
                        }

                        string propertyName = property.Metadata.Name;
                        //audit.Values[propertyName] = property.CurrentValue;
                        values.Add(propertyName, property.CurrentValue);
                    }
                    //audits.Add(auditEntry.ToAudit());
                    audit.Values = JsonSerializer.Serialize(values);
                    audits.Add(audit);
                }
            }

            if (audits.Count > 0)
            {
                context.Set<TAudit>().AddRange(audits);
            }
        }
    }
}
