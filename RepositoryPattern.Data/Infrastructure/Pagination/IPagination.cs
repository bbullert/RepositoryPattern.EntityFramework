namespace RepositoryPattern.Data.Infrastructure
{
    public interface IPagination<T>
    {
        int Index { get; }
        int Size { get; }
        int Pages { get; }
        int Count { get; }
        IEnumerable<T> Items { get; }
        public bool HasPrevious { get; }
        public bool HasNext { get; }
    }
}
