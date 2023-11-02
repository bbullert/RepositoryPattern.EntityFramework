namespace RepositoryPattern.Data.Infrastructure
{
    public interface IGenericAudit<TAuditKey, TEntityKey>
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        TAuditKey Id { get; set; }
        string TableName { get; set; }
        DateTime ModifiedAt { get; set; }
        TEntityKey EntityId { get; set; }
        DateTime ModifyDateTime { get; set; }
        string Values { get; set; }

        TEntity ToEntity<TEntity>();
    }
}