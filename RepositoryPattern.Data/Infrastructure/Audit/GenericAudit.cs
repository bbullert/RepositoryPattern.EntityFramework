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
        public string Values { get; set; }

        public TEntity ToEntity<TEntity>()
        {
            if (Values == null)
                throw new ArgumentNullException(nameof(Values));
            return JsonSerializer.Deserialize<TEntity>(Values);
        }
    }
}
