using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GeorgeVlad.TicketingSystem.Extensions;

public static class DynamicQueryableExtensions
{
    #region OrderBy
    public static IEnumerable<TModel> OrderBy<TModel>(this IEnumerable<TModel> source, string ordering, string defaultValue = null)
    {
        var s = source.AsQueryable();
        return s.OrderBy(ordering, defaultValue);
        //if (!string.IsNullOrWhiteSpace(ordering))
        //    return System.Linq.Dynamic.Core.DynamicQueryableExtensions.OrderBy(source, ordering);
        //else if (!string.IsNullOrWhiteSpace(defaultValue))
        //    return System.Linq.Dynamic.Core.DynamicQueryableExtensions.OrderBy(source, defaultValue);
        //else
        //    return source;
    }
    public static IEnumerable<TModel> OrderBy<TModel>(this IEnumerable<TModel> source, string ordering, Func<IEnumerable<TModel>, IEnumerable<TModel>> defaultexpressions)
    {
        if (!string.IsNullOrWhiteSpace(ordering))
            return DynamicQueryableExtensions.OrderBy(source, ordering);
        else if (defaultexpressions != null)
        {
            return defaultexpressions(source);
        }
        return source;
    }
    public static IQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> source, string ordering, string defaultValue = null)
    {
        if (!string.IsNullOrWhiteSpace(ordering))
#if Kahanu_System_Linq_Dynamic && !(NET35 || SILVERLIGHT || NETFX_CORE || WINDOWS_APP || DOTNET5_1 || UAP10_0 || NETSTANDARD)
                return System.Linq.Dynamic.DynamicQueryable.OrderBy(source, ordering);
#endif
#if !Kahanu_System_Linq_Dynamic || NETSTANDARD2_0
            return System.Linq.Dynamic.Core.DynamicQueryableExtensions.OrderBy(source, ordering);
#endif
        else if (!string.IsNullOrWhiteSpace(defaultValue))
#if Kahanu_System_Linq_Dynamic && !(NET35 || SILVERLIGHT || NETFX_CORE || WINDOWS_APP || DOTNET5_1 || UAP10_0 || NETSTANDARD)
                return System.Linq.Dynamic.DynamicQueryable.OrderBy(source, defaultValue);
#endif
#if !Kahanu_System_Linq_Dynamic || NETSTANDARD2_0
            return System.Linq.Dynamic.Core.DynamicQueryableExtensions.OrderBy(source, defaultValue);
#endif
        else
            return source;
    }
    public static IQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> source, string ordering, Func<IQueryable<TModel>, IQueryable<TModel>> defaultexpressions)
    {
        if (!string.IsNullOrWhiteSpace(ordering))
            return DynamicQueryableExtensions.OrderBy(source, ordering);
        else if (defaultexpressions != null)
        {
            return defaultexpressions(source);
        }
        return source;
    }
    public static IQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> source, string ordering, params Expression<Func<TModel, object>>[] defaultexpressions)
    {
        if (!string.IsNullOrWhiteSpace(ordering))
            return DynamicQueryableExtensions.OrderBy(source, ordering);
        else if (defaultexpressions != null)
        {
            var ss = source;
            foreach (var item in defaultexpressions)
            {
                ss = ss.OrderBy(item);
            }
            return ss;
        }
        return source;
    }
    #endregion OrderBy

}