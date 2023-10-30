namespace RepositoryPattern.Data.Infrastructure
{
    public class GenericAudit<TKey, TEntityKey> : IGenericAudit<TKey, TEntityKey> 
        where TKey : IEquatable<TKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        public TKey Id { get; set; }
        public string TableName { get; set; }
        public TEntityKey EntityId { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string Values { get; set; }
    }
}
