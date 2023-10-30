namespace RepositoryPattern.Data.Infrastructure
{
    public abstract class Entity<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
