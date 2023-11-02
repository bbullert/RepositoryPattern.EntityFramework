namespace RepositoryPattern.Data.Infrastructure
{
    //public class Audit
    //{
    //    public string TableName { get; set; }
    //    public string EntityId { get; set; }
    //    public DateTime ModifyDateTime { get; set; }
    //    public string Values { get; set; }
    //}

    public class Audit : GenericAudit<Guid, Guid>
    {
    }
}
