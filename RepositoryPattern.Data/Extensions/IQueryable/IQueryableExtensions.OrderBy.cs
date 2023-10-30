using System.Linq.Expressions;

namespace RepositoryPattern.Data.Extensions
{
    public static partial class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortOrder)
        {
            if (string.IsNullOrEmpty(sortOrder))
                return (IOrderedQueryable<T>)source;

            var sortOrderList = sortOrder.Split(',').ToList();
            var sortOrderDictionary = ToSortOrderDictionary(sortOrderList);

            var query = source.OrderBy(sortOrderDictionary.First());
            foreach (var item in sortOrderDictionary.Skip(1))
            {
                query = query.ThenBy(item);
            }

            return query;
        }

        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, KeyValuePair<string, string> keyValuePair)
        {
            return keyValuePair.Value == "asc" ?
                source.OrderBy(PropertyToExpression<T>(keyValuePair.Key)) :
                source.OrderByDescending(PropertyToExpression<T>(keyValuePair.Key));
        }

        private static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, KeyValuePair<string, string> keyValuePair)
        {
            return keyValuePair.Value == "asc" ?
                source.ThenBy(PropertyToExpression<T>(keyValuePair.Key)) :
                source.ThenByDescending(PropertyToExpression<T>(keyValuePair.Key));
        }

        private static IDictionary<string, string> ToSortOrderDictionary(IEnumerable<string> sortOrder)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var sortOrderItem in sortOrder)
            {
                if (string.IsNullOrEmpty(sortOrderItem))
                    throw new ArgumentNullException(nameof(sortOrderItem));

                var param = sortOrderItem.Trim().Split(' ').ToList();
                if (param.Count > 2)
                    throw new ArgumentException($"Invalid {nameof(sortOrder)} parameter syntax.");

                string sortProperty = param.ElementAt(0);
                string sortDirection = param.ElementAtOrDefault(1) == null ?
                    "asc" : param.ElementAt(1).ToLower();

                if (sortDirection != "asc" && sortDirection != "desc")
                    throw new ArgumentException($"Invalid {nameof(sortOrder)} parameter syntax.");

                dictionary.Add(sortProperty, sortDirection);
            }
            return dictionary;
        }

        private static Expression<Func<T, object>> PropertyToExpression<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
