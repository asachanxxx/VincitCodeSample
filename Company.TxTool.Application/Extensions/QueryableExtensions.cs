namespace Company.TxTool.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> If<T>(
            this IQueryable<T> query,
            bool condition,
            params Func<IQueryable<T>, IQueryable<T>>[] transforms)
        {
            return condition
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }
    }
}