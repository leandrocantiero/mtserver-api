using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace mtvendors_api.Models
{
    public static class SortingHelper
    {
        private class SortByInfo
        {
            public SortDirection Direction { get; set; }
            public string PropertyName { get; set; }
            public bool Initial { get; set; }
        }

        private enum SortDirection
        {
            Ascending = 0,
            Descending = 1
        }

        public static IEnumerable<T> SortBy<T>
               (this IEnumerable<T> enumerable, string orderBy)
        {
            return enumerable.AsQueryable().SortBy(orderBy).AsEnumerable();
        }

        public static IQueryable<T> SortBy<T>
               (this IQueryable<T> collection, string orderBy)
        {
            foreach (SortByInfo orderByInfo in ParseOrderBy(orderBy))
                collection = ApplyOrderBy<T>(collection, orderByInfo);

            return collection;
        }

        private static IEnumerable<SortByInfo> ParseOrderBy(string orderBy)
        {
            if (String.IsNullOrEmpty(orderBy))
                yield break;

            string[] items = orderBy.Split(',');
            bool initial = true;
            foreach (string item in items)
            {
                string[] pair = item.Trim().Split('-');

                if (pair.Length > 2)
                    throw new ArgumentException(String.Format
                    ("Invalid OrderBy string '{0}'. Order By Format: Property, Property2 - DESC, Property2 - ASC", item));

                string prop = pair[0].Trim();

                if (String.IsNullOrEmpty(prop))
                    throw new ArgumentException("Invalid Property. Order By Format: Property, Property2 - DESC, Property2 - ASC");


                SortDirection dir = SortDirection.Ascending;

                if (pair.Length == 2)
                    dir = ("desc".Equals(pair[1].Trim(),
                          StringComparison.OrdinalIgnoreCase) ?
                          SortDirection.Descending : SortDirection.Ascending);

                yield return new SortByInfo()
                {
                    PropertyName = prop,
                    Direction = dir,
                    Initial = initial
                };

                initial = false;
            }
        }

        private static IQueryable<T> ApplyOrderBy<T>
                (IQueryable<T> collection, SortByInfo orderByInfo)
        {
            string[] props = orderByInfo.PropertyName.Split('.');
            Type type = typeof(T);

            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
            string methodName = String.Empty;

            if (!orderByInfo.Initial && collection is IOrderedQueryable<T>)
            {
                if (orderByInfo.Direction == SortDirection.Ascending)
                    methodName = "ThenBy";
                else
                    methodName = "ThenByDescending";
            }
            else
            {
                if (orderByInfo.Direction == SortDirection.Ascending)
                    methodName = "OrderBy";
                else
                    methodName = "OrderByDescending";
            }

            return (IOrderedQueryable<T>)typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                        && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2
                        && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { collection, lambda });
        }
    }
}
