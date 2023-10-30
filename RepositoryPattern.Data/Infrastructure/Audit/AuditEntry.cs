using System.Text.Json;

namespace RepositoryPattern.Data.Infrastructure
{
    public class AuditEntry<TAudit, TAuditKey, TEntityKey>
        where TAudit : class, IGenericAudit<TAuditKey, TEntityKey>
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        public TAuditKey Id { get; set; }
        public string TableName { get; set; }
        public TEntityKey EntityId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Dictionary<string, object> Values { get; set; }

        public AuditEntry()
        {
            Values = new Dictionary<string, object>();
        }

        public TAudit ToAudit()
        {
            var audit = (TAudit)Activator.CreateInstance(typeof(TAudit));
            audit.TableName = TableName;
            audit.EntityId = EntityId;
            audit.ModifiedAt = ModifiedAt;
            audit.Values = JsonSerializer.Serialize(Values);
            return audit;
        }
    }
}
