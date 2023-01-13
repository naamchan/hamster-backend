using System.Linq.Expressions;
using System.Reflection;

public static class IQueryableExt
{
    // String.Contains(string)
    static MethodInfo containsMI = typeof(string).GetMethod("Contains", 0, new[] { typeof(string) })!;

    // generate r => r.{columnname}.Contains(value)
    static Expression<Func<T, bool>> WhereContainsExpr<T>(string columnname, string value)
    {
        // (T r)
        var rParm = Expression.Parameter(typeof(T), "r");
        // r.{columnname}
        var rColExpr = Expression.Property(rParm, columnname);
        // r.{columnname}.Contains(value)
        var bodyExpr = Expression.Call(rColExpr, containsMI, Expression.Constant(value));
        return Expression.Lambda<Func<T, bool>>(bodyExpr, rParm);
    }

    public static IQueryable<T> WhereContains<T>(this IQueryable<T> src, string columname, string value) => src.Where(WhereContainsExpr<T>(columname, value));
}