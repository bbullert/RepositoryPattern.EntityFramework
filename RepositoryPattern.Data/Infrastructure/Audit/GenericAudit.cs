using System.Text.Json;

namespace RepositoryPattern.Data.Infrastructure
{
    public abstract class GenericAudit<TAuditKey, TEntityKey> : IGenericAudit<TAuditKey, TEntityKey> 
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        public TAuditKey Id { get; set; }
        public string TableName { get; set; }
        public DateTime ModifiedAt { get; set; }
        public TEntityKey EntityId { get; set; }
        public string Changes { get; set; }

        public TEntity ToEntity<TEntity>()
        {
            if (Changes == null)
                throw new ArgumentNullException(nameof(Changes));
            return JsonSerializer.Deserialize<TEntity>(Changes);
        }
    }
}
