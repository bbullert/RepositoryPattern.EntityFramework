using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Extensions
{
    public static partial class IQueryableExtensions
    {
        public static IPagination<T> ToPagination<T>(this IQueryable<T> source, int index, int size)
        {
            if (index <= 0) throw new ArgumentException($"Argument {nameof(index)} must be greater than 0.");
            if (size <= 0) throw new ArgumentException($"Argument {nameof(size)} must be greater than 0.");

            int skip = (index - 1) * size;
            var items = source.Skip(skip).Take(size).ToList();
            var count = source.Count();
            return new Pagination<T>(items, count, index, size);
        }

        public static async Task<IPagination<T>> ToPaginationAsync<T>(this IQueryable<T> source, int index, int size)
        {
            if (index <= 0) throw new ArgumentException($"Argument {nameof(index)} must be greater than 0.");
            if (size <= 0) throw new ArgumentException($"Argument {nameof(size)} must be greater than 0.");

            int skip = (index - 1) * size;
            var items = await source.Skip(skip).Take(size).ToListAsync();
            var count = await source.CountAsync();
            return new Pagination<T>(items, count, index, size);
        }
    }
}
