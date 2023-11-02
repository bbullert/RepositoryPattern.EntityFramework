namespace RepositoryPattern.Data.Infrastructure
{
    public class Pagination<T> : IPagination<T>
    {
        public Pagination(IEnumerable<T> items, int count, int index, int size)
        {
            Items = items;

            if (count < 0) throw new ArgumentException($"{nameof(count)} must be of equal or greater than 0.");
            Count = count;

            if (size <= 0) throw new ArgumentException($"{nameof(size)} must be greater than 0.");
            Size = size;
            Pages = (int)Math.Ceiling(count / (double)size);

            if (index <= 0) throw new IndexOutOfRangeException($"{nameof(index)} must be greater than 0.");
            if (index > Pages && Pages != 0) throw new IndexOutOfRangeException($"{nameof(index)} must be of equal or less than {nameof(Pages)}");
            Index = index;
        }

        public int Index { get; private set; }
        public int Size { get; private set; }
        public int Pages { get; private set; }
        public int Count { get; private set; }
        public IEnumerable<T> Items { get; private set; }
        public bool HasPrevious => Index > 1;
        public bool HasNext => Index < Pages;
    }
}
