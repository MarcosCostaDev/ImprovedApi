using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace BaseApi.Infra.Extensions
{
    public static class QueryableExtensions
    {

        public static IQueryable<T> WhereIn<T, V>(this IQueryable<T> source, Expression<Func<T, V>> valueSelector, params V[] values)
        {
            var condition = Expression.Call(
                typeof(Enumerable), "Contains", new[] { typeof(V) },
                Expression.Constant(values), valueSelector.Body);
            var predicate = Expression.Lambda<Func<T, bool>>(condition, valueSelector.Parameters);
            return source.Where(predicate);
        }


        public static IQueryable Set(this DbContext context, Type T)
        {

            // Get the generic type definition
            MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

            // Build a method with the specific type argument you're interested in
            method = method.MakeGenericMethod(T);

            return method.Invoke(context, null) as IQueryable;
        }

        public static IQueryable<T> Set<T>(this DbContext context)
        {
            // Get the generic type definition 
            MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

            // Build a method with the specific type argument you're interested in 
            method = method.MakeGenericMethod(typeof(T));

            return method.Invoke(context, null) as IQueryable<T>;
        }

   
       

    }
}
