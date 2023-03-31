using System.Linq.Expressions;

namespace Wordstag.Services.Infrastructure
{
    public static class Extensions
    {
        public static IQueryable<T> OrderByDynamic<T>(
        this IQueryable<T> query,
        string orderByMember,
        string direction)
        {
            var queryElementTypeParam = Expression.Parameter(typeof(T));

            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);

            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
                typeof(Queryable),
                !string.IsNullOrEmpty(direction) && direction.ToLower() == "asc" ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), memberAccess.Type },
                query.Expression,
                Expression.Quote(keySelector));

            return query.Provider.CreateQuery<T>(orderBy);
        }
    }
}
