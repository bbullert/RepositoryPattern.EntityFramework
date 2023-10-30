namespace RepositoryPattern.Data.Infrastructure
{
    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
