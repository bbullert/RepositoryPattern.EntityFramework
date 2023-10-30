namespace RepositoryPattern.Data.Infrastructure
{
    public interface IGenericAudit<TKey, TEntityKey>
        where TKey : IEquatable<TKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        TKey Id { get; set; }
        string TableName { get; set; }
        TEntityKey EntityId { get; set; }
        DateTime ModifyDateTime { get; set; }
        string Values { get; set; }
    }
}