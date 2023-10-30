using System.Text.Json;

namespace RepositoryPattern.Data.Infrastructure
{
    //public class AuditEntry
    //{
    //    public string TableName { get; set; }
    //    public string EntityId { get; set; }
    //    public DateTime ModifyDateTime { get; set; }
    //    public Dictionary<string, object> Values { get; set; }

    //    public AuditEntry()
    //    {
    //        Values = new Dictionary<string, object>();
    //    }

    //    public Audit ToAudit()
    //    {
    //        return new Audit()
    //        {
    //            TableName = TableName,
    //            EntityId = EntityId,
    //            ModifyDateTime = ModifyDateTime,
    //            Values = JsonSerializer.Serialize(Values)
    //        };
    //    }
    //}
}
